using Karkas.Data.Tracing;

namespace Karkas.Examples;

public partial class TestHelper
{
	/// <summary>
	/// Checks query ids on a real database: generated queries are named DalName.MethodName,
	/// the tagged SQL runs (including identity inserts), and errors carry the ids.
	/// Expects KarkasTracing.TagMode to be QueryId (set at the start of the program).
	/// </summary>
	public static void TestQueryTracing()
	{
		if (KarkasTracing.TagMode != QueryTagMode.QueryId)
		{
			throw new Exception("TestQueryTracing expects KarkasTracing.TagMode = QueryId");
		}

		List<Activity> activities = new List<Activity>();
		using ActivityListener listener = new ActivityListener
		{
			ShouldListenTo = source => source.Name == KarkasTracing.ActivitySourceName,
			Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
			ActivityStopped = activity => activities.Add(activity),
		};
		ActivitySource.AddActivityListener(listener);

		AlbumDal dal = new AlbumDal(ConnectionHelper.CreateConnection());
		List<Album> albums = dal.QueryAll();
		Album first = dal.QueryByAlbumId(albums[0].AlbumId);
		dal.QueryByArtistId(first.ArtistId);

		Album newAlbum = new Album();
		newAlbum.Title = "Tracing " + Guid.NewGuid().ToString();
		newAlbum.ArtistId = first.ArtistId;
		dal.Insert(newAlbum);
		dal.Delete(newAlbum);

		string[] expected =
		{
			"AlbumDal.QueryAll", "AlbumDal.QueryByAlbumId", "AlbumDal.QueryByArtistId",
			"AlbumDal.Insert", "AlbumDal.Delete",
		};
		for (int i = 0; i < expected.Length; i++)
		{
			string queryId = activities[i].GetTagItem("karkas.query_id") as string ?? "";
			string text = activities[i].GetTagItem("db.query.text") as string ?? "";
			assertEquals(expected[i], queryId, "query id");
			if (!text.StartsWith("/* karkas:" + expected[i] + " */ "))
			{
				throw new Exception($"SQL text is not tagged: {text}");
			}
		}

		activities.Clear();
		try
		{
			dal.Template.GetRows(@"SELECT X FROM ""Album""");
			throw new Exception("Query with a wrong column did not throw");
		}
		catch (KarkasDataException ex)
		{
			string executionId = activities[0].GetTagItem("karkas.execution_id") as string ?? "";
			assertEquals(executionId, KarkasTracing.GetExecutionId(ex) ?? "", "execution id on exception");
			if (!(KarkasTracing.GetQueryId(ex) ?? "").StartsWith("AdoTemplate"))
			{
				throw new Exception($"Unexpected query id on exception: {KarkasTracing.GetQueryId(ex)}");
			}
		}

		Console.WriteLine("Query tracing works");
	}
}
