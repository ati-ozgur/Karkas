
using System;
using System.Collections.Generic;
using System.Data;
using Karkas.Core.Data.Sqlite;
using System.Data.SQLite;
using Karkas.Core.Data.Sqlite;
using System.Text;
using Karkas.Core.DataUtil;
using Karkas.Core.DataUtil.BaseClasses;
using Karkas.Chinook.TypeLibrary;
using Karkas.Chinook.Dal;


namespace Karkas.Chinook.Bs
{
	public partial class AlbumBs : BaseBs<Album, AlbumDal,  AdoTemplateSqlite, ParameterBuilderSqlite>
	{
	public override string DatabaseName
	{
		get
		{
			return "Karkas.Chinook";
		}
	}
	public void Delete(long pAlbumId)
	{
		dal.Delete( pAlbumId);
	}
	public Album QueryByAlbumId(long pAlbumId)
	{
		return dal.QueryByAlbumId(pAlbumId);
	}
}
}
