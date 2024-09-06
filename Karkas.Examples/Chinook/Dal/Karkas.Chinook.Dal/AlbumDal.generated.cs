
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using Karkas.Core.Data.Sqlite;
using System.Text;
using Karkas.Core.DataUtil;
using Karkas.Core.DataUtil.BaseClasses;
using Karkas.Chinook.TypeLibrary;


namespace Karkas.Chinook.Dal
{
public partial class AlbumDal : BaseDalSqlite<Album, AdoTemplateSqlite, ParameterBuilderSqlite>
{
	
	public override string DatabaseName
	{
		get
		{
			return "Karkas.Chinook";
		}
	}
	protected override void setIdentityColumnValue(Album pTypeLibrary,long pIdentityColumnValue)
	{
		pTypeLibrary.AlbumId = (long )pIdentityColumnValue;
	}
	protected override string SelectCountString
	{
		get
		{
			return @"SELECT COUNT(*) FROM .Album";
		}
	}
	protected override string SelectString
	{
		get 
		{
			return @"SELECT AlbumId,Title,ArtistId FROM .Album";
		}
	}
	protected override string DeleteString
	{
		get 
		{
			return @"DELETE   FROM .Album WHERE AlbumId = @AlbumId ";
		}
	}
	protected override string UpdateString
	{
		get 
		{
			return @"UPDATE .Album
			 SET 
			Title = @Title
,ArtistId = @ArtistId
			
			WHERE 
			 AlbumId = @AlbumId
 ";
		}
	}
	protected override string InsertString
	{
		get 
		{
			return @"INSERT INTO .Album
 (Title,ArtistId) 
VALUES 
(@Title,@ArtistId);select last_insert_rowid();";
		}
	}
	public Album QueryByAlbumId(long pAlbumId )
	{
		List<Album> liste = new List<Album>();
		ExecuteQuery(liste,String.Format(" AlbumId = '{0}'",pAlbumId));		
		if (liste.Count > 0)
		{
			return liste[0];
		}
		else
		{
			return null;
		}
	}
	
	protected override bool IdentityExists
	{
		get
		{
			return true;
		}
	}
	
	protected override bool IsPkGuid
	{
		get
		{
			return false;
		}
	}
	
	
	public override string PrimaryKey
	{
		get
		{
			return "AlbumId";
		}
	}
	
	public virtual void Delete(long AlbumId)
	{
		Album row = new Album();
		row.AlbumId = AlbumId;
		base.Delete(row);
	}
	protected override void ProcessRow(IDataReader dr, Album row)
	{
		row.AlbumId = dr.GetInt64(0);
		row.Title = dr.GetString(1);
		row.ArtistId = dr.GetInt64(2);
	}
	protected override void InsertCommandParametersAdd(DbCommand cmd, Album row)
	{
		ParameterBuilderSqlite builder = (ParameterBuilderSqlite)Template.getParameterBuilder();
		builder.Command = cmd;
		builder.AddParameter("@Title",DbType.String, row.Title);
		builder.AddParameter("@ArtistId",DbType.Int64, row.ArtistId);
	}
	protected override void UpdateCommandParametersAdd(DbCommand cmd, 	Album	 row)
	{
		ParameterBuilderSqlite builder = (ParameterBuilderSqlite)Template.getParameterBuilder();
		builder.Command = cmd;
		builder.AddParameter("@AlbumId",DbType.Int64, row.AlbumId);
		builder.AddParameter("@Title",DbType.String, row.Title);
		builder.AddParameter("@ArtistId",DbType.Int64, row.ArtistId);
	}
	protected override void DeleteCommandParametersAdd(DbCommand cmd, 	Album	 row)
	{
		ParameterBuilderSqlite builder = (ParameterBuilderSqlite)Template.getParameterBuilder();
		builder.Command = cmd;
		builder.AddParameter("@AlbumId",DbType.Int64, row.AlbumId);
	}
	public override string DbProviderName
	{
		get
		{
			return "System.Data.SQLite";
		}
	}
}
}
