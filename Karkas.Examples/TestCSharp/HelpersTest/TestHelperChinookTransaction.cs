namespace Karkas.Examples;
public partial class TestHelper
{
	public static void TestTransactionWorks()
	{
		AlbumBs albumBs = new AlbumBs();
		ArtistBs artistBs = new ArtistBs();
		string artistName = "Atilla" + Guid.NewGuid().ToString(); ;
		string titleToInsert = $"{artistName}'s new Title" + Guid.NewGuid().ToString();

		albumBs.InsertNewArtistAndAlbum(artistName, titleToInsert);


		var result = albumBs.QueryUsingColumnName(Album.ColumnNames.Title, titleToInsert);

		if (result != null && result.Count == 1 && result[0].Title == titleToInsert)
		{
			var artistId = result[0].ArtistId;
			var artist = artistBs.QueryByArtistId(artistId);
			if (artist.Name == artistName)
			{
				Console.WriteLine("Simple Transaction works");
			}
		}

	}
	public static void TestTransactionRollback()
	{
		ArtistBs artistBs = new ArtistBs();
		AlbumBs albumBs = new AlbumBs();

		string artistName = "Atilla" + Guid.NewGuid().ToString(); ;
		string titleToInsert = $"{artistName}'s new Title" + Guid.NewGuid().ToString();

		try
		{
			albumBs.InsertNewArtistAndAlbumError(artistName, titleToInsert);
		}
		catch (System.Exception)
		{
			var artistResult = artistBs.QueryUsingColumnName(Artist.ColumnNames.Name, artistName);
			if (artistResult.Count == 0)
			{
				Console.WriteLine("Transaction Rollback works");
			}

		}

	}

}
