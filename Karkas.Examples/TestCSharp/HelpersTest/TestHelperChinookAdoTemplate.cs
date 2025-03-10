namespace Karkas.Examples;

public partial class TestHelper
{
	public static void TestTemplateTopRows()
	{
		var template = ConnectionHelper.GetAdoTemplate();
		int count = 5;
		string testSqlForTop = "SELECT * FROM \"Album\"";
		List<Dictionary<string, object>> lAlbums = template.GetTopRows(testSqlForTop, count);

		if (lAlbums.Count == count)
		{
			System.Console.WriteLine("GetTopRows works");
		}

	}

	public static void TestTemplateOneRow()
	{
		var template = ConnectionHelper.GetAdoTemplate();
		string testSqlForTop = "SELECT * FROM \"Album\"";

		var d1 = template.GetOneRow(testSqlForTop);
		foreach (string key in d1.Keys)
		{
			object value = d1[key];
			Console.WriteLine($"{key} {value}");
		}

		if (d1 != null)
		{
			Console.WriteLine("GetOneRow works");
		}
	}

}
