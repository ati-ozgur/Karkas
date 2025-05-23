namespace Karkas.Examples.Chinook.Dal;
public partial class AlbumDal
{

    // This is not correct way to use SQL
    // please use parameterized queries.
    // this one is vulnerable to SQL Injection.
    // this is only for Testint Exists usage in databases
    private string SQL_TITLE = @"select * from ""Album"" where ""Title"" = '{0}'";
    public bool IsTitleExists(string title)
    {
        string sql = string.Format(SQL_TITLE,title);
        return Template.ExecuteAsExists(sql);
    }

    public int GetMaxAlbumId()
    {
        string sql = @"SELECT MAX(""AlbumId"") FROM ""Album""";
        return Template.GetOneValue<int>(sql);
    }


}
