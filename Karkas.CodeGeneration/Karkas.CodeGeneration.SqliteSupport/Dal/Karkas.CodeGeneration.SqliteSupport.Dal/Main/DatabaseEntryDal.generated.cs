
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using Karkas.Core.DataUtil;
using Karkas.CodeGeneration.SqliteSupport.TypeLibrary;
using Karkas.CodeGeneration.SqliteSupport.TypeLibrary.Main;
using Karkas.Core.DataUtil.BaseClasses;


namespace Karkas.CodeGeneration.SqliteSupport.Dal.Main
{
public partial class DatabaseEntryDal : BaseDal<DatabaseEntry>
{
	
	public override string DatabaseName
	{
		get
		{
            return "Main";
		}
	}
	protected override void identityKolonDegeriniSetle(DatabaseEntry pTypeLibrary,long pIdentityKolonValue)
	{
	}
	protected override string SelectCountString
	{
		get
		{
			return @"SELECT COUNT(*) FROM DatabaseEntry";
		}
	}
	protected override string SelectString
	{
		get 
		{
			return @"SELECT ConnectionName,ConnectionDatabaseType,ConnectionDbProviderName,ConnectionString,DatabaseNamePhysical,DatabaseNameLogical,ProjectNameSpace,CodeGenerationDirectory,ViewCodeGenerate,StoredProcedureCodeGenerate,SequenceCodeGenerate,UseSchemaNameInSqlQueries,UseSchemaNameInFolders,IgnoreSystemTables,IgnoredSchemaList,AbbrevationsAsString,CreationTime,LastAccessTime,LastWriteTime FROM DatabaseEntry";
		}
	}
	protected override string DeleteString
	{
		get 
		{
			return @"DELETE   FROM DatabaseEntry WHERE ConnectionName = @ConnectionName ";
		}
	}
	protected override string UpdateString
	{
		get 
		{
			return @"UPDATE DatabaseEntry
			 SET 
			ConnectionDatabaseType = @ConnectionDatabaseType
,ConnectionDbProviderName = @ConnectionDbProviderName
,ConnectionString = @ConnectionString
,DatabaseNamePhysical = @DatabaseNamePhysical
,DatabaseNameLogical = @DatabaseNameLogical
,ProjectNameSpace = @ProjectNameSpace
,CodeGenerationDirectory = @CodeGenerationDirectory
,ViewCodeGenerate = @ViewCodeGenerate
,StoredProcedureCodeGenerate = @StoredProcedureCodeGenerate
,SequenceCodeGenerate = @SequenceCodeGenerate
,UseSchemaNameInSqlQueries = @UseSchemaNameInSqlQueries
,UseSchemaNameInFolders = @UseSchemaNameInFolders
,IgnoreSystemTables = @IgnoreSystemTables
,IgnoredSchemaList = @IgnoredSchemaList
,AbbrevationsAsString = @AbbrevationsAsString
,CreationTime = @CreationTime
,LastAccessTime = @LastAccessTime
,LastWriteTime = @LastWriteTime
			
			WHERE 
			 ConnectionName = @ConnectionName
 ";
		}
	}
	protected override string InsertString
	{
		get 
		{
			return @"INSERT INTO DatabaseEntry 
			 (ConnectionName,ConnectionDatabaseType,ConnectionDbProviderName,ConnectionString,DatabaseNamePhysical,DatabaseNameLogical,ProjectNameSpace,CodeGenerationDirectory,ViewCodeGenerate,StoredProcedureCodeGenerate,SequenceCodeGenerate,UseSchemaNameInSqlQueries,UseSchemaNameInFolders,IgnoreSystemTables,IgnoredSchemaList,AbbrevationsAsString,CreationTime,LastAccessTime,LastWriteTime) 
			 VALUES 
						(@ConnectionName,@ConnectionDatabaseType,@ConnectionDbProviderName,@ConnectionString,@DatabaseNamePhysical,@DatabaseNameLogical,@ProjectNameSpace,@CodeGenerationDirectory,@ViewCodeGenerate,@StoredProcedureCodeGenerate,@SequenceCodeGenerate,@UseSchemaNameInSqlQueries,@UseSchemaNameInFolders,@IgnoreSystemTables,@IgnoredSchemaList,@AbbrevationsAsString,@CreationTime,@LastAccessTime,@LastWriteTime)";
		}
	}
	public DatabaseEntry SorgulaConnectionNameIle(string p1)
	{
		List<DatabaseEntry> liste = new List<DatabaseEntry>();
		SorguCalistir(liste,String.Format(" ConnectionName = '{0}'", p1));		
		if (liste.Count > 0)
		{
			return liste[0];
		}
		else
		{
			return null;
		}
	}
	
	protected override bool IdentityVarMi
	{
		get
		{
			return false;
		}
	}
	
	protected override bool PkGuidMi
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
			return "ConnectionName";
		}
	}
	
	public virtual void Sil(string ConnectionName)
	{
		DatabaseEntry row = new DatabaseEntry();
		row.ConnectionName = ConnectionName;
		base.Sil(row);
	}
	protected override void ProcessRow(IDataReader dr, DatabaseEntry row)
	{
		row.ConnectionName = dr.GetString(0);
		row.ConnectionDatabaseType = dr.GetString(1);
		row.ConnectionDbProviderName = dr.GetString(2);
		row.ConnectionString = dr.GetString(3);
		if (!dr.IsDBNull(4))
		{
			row.DatabaseNamePhysical = dr.GetString(4);
		}
		if (!dr.IsDBNull(5))
		{
			row.DatabaseNameLogical = dr.GetString(5);
		}
		row.ProjectNameSpace = dr.GetString(6);
		row.CodeGenerationDirectory = dr.GetString(7);
		row.ViewCodeGenerate = dr.GetString(8);
		row.StoredProcedureCodeGenerate = dr.GetString(9);
		row.SequenceCodeGenerate = dr.GetString(10);
		row.UseSchemaNameInSqlQueries = dr.GetString(11);
		row.UseSchemaNameInFolders = dr.GetString(12);
		row.IgnoreSystemTables = dr.GetString(13);
		row.IgnoredSchemaList = dr.GetString(14);
		if (!dr.IsDBNull(15))
		{
			row.AbbrevationsAsString = dr.GetString(15);
		}
		if (!dr.IsDBNull(16))
		{
			row.CreationTime = dr.GetString(16);
		}
		if (!dr.IsDBNull(17))
		{
			row.LastAccessTime = dr.GetString(17);
		}
		if (!dr.IsDBNull(18))
		{
			row.LastWriteTime = dr.GetString(18);
		}
	}
	protected override void InsertCommandParametersAdd(DbCommand cmd, DatabaseEntry row)
	{
		ParameterBuilder builder = Template.getParameterBuilder();
		builder.Command = cmd;
		builder.parameterEkle("@ConnectionName",DbType.String, row.ConnectionName);
		builder.parameterEkle("@ConnectionDatabaseType",DbType.String, row.ConnectionDatabaseType);
		builder.parameterEkle("@ConnectionDbProviderName",DbType.String, row.ConnectionDbProviderName);
		builder.parameterEkle("@ConnectionString",DbType.String, row.ConnectionString);
		builder.parameterEkle("@DatabaseNamePhysical",DbType.String, row.DatabaseNamePhysical);
		builder.parameterEkle("@DatabaseNameLogical",DbType.String, row.DatabaseNameLogical);
		builder.parameterEkle("@ProjectNameSpace",DbType.String, row.ProjectNameSpace);
		builder.parameterEkle("@CodeGenerationDirectory",DbType.String, row.CodeGenerationDirectory);
		builder.parameterEkle("@ViewCodeGenerate",DbType.String, row.ViewCodeGenerate);
		builder.parameterEkle("@StoredProcedureCodeGenerate",DbType.String, row.StoredProcedureCodeGenerate);
		builder.parameterEkle("@SequenceCodeGenerate",DbType.String, row.SequenceCodeGenerate);
		builder.parameterEkle("@UseSchemaNameInSqlQueries",DbType.String, row.UseSchemaNameInSqlQueries);
		builder.parameterEkle("@UseSchemaNameInFolders",DbType.String, row.UseSchemaNameInFolders);
		builder.parameterEkle("@IgnoreSystemTables",DbType.String, row.IgnoreSystemTables);
		builder.parameterEkle("@IgnoredSchemaList",DbType.String, row.IgnoredSchemaList);
		builder.parameterEkle("@AbbrevationsAsString",DbType.String, row.AbbrevationsAsString);
		builder.parameterEkle("@CreationTime",DbType.String, row.CreationTime);
		builder.parameterEkle("@LastAccessTime",DbType.String, row.LastAccessTime);
		builder.parameterEkle("@LastWriteTime",DbType.String, row.LastWriteTime);
	}
	protected override void UpdateCommandParametersAdd(DbCommand cmd, 	DatabaseEntry	 row)
	{
		ParameterBuilder builder = Template.getParameterBuilder();
		builder.Command = cmd;
		builder.parameterEkle("@ConnectionName",DbType.String, row.ConnectionName);
		builder.parameterEkle("@ConnectionDatabaseType",DbType.String, row.ConnectionDatabaseType);
		builder.parameterEkle("@ConnectionDbProviderName",DbType.String, row.ConnectionDbProviderName);
		builder.parameterEkle("@ConnectionString",DbType.String, row.ConnectionString);
		builder.parameterEkle("@DatabaseNamePhysical",DbType.String, row.DatabaseNamePhysical);
		builder.parameterEkle("@DatabaseNameLogical",DbType.String, row.DatabaseNameLogical);
		builder.parameterEkle("@ProjectNameSpace",DbType.String, row.ProjectNameSpace);
		builder.parameterEkle("@CodeGenerationDirectory",DbType.String, row.CodeGenerationDirectory);
		builder.parameterEkle("@ViewCodeGenerate",DbType.String, row.ViewCodeGenerate);
		builder.parameterEkle("@StoredProcedureCodeGenerate",DbType.String, row.StoredProcedureCodeGenerate);
		builder.parameterEkle("@SequenceCodeGenerate",DbType.String, row.SequenceCodeGenerate);
		builder.parameterEkle("@UseSchemaNameInSqlQueries",DbType.String, row.UseSchemaNameInSqlQueries);
		builder.parameterEkle("@UseSchemaNameInFolders",DbType.String, row.UseSchemaNameInFolders);
		builder.parameterEkle("@IgnoreSystemTables",DbType.String, row.IgnoreSystemTables);
		builder.parameterEkle("@IgnoredSchemaList",DbType.String, row.IgnoredSchemaList);
		builder.parameterEkle("@AbbrevationsAsString",DbType.String, row.AbbrevationsAsString);
		builder.parameterEkle("@CreationTime",DbType.String, row.CreationTime);
		builder.parameterEkle("@LastAccessTime",DbType.String, row.LastAccessTime);
		builder.parameterEkle("@LastWriteTime",DbType.String, row.LastWriteTime);
	}
	protected override void DeleteCommandParametersAdd(DbCommand cmd, 	DatabaseEntry	 row)
	{
		ParameterBuilder builder = Template.getParameterBuilder();
		builder.Command = cmd;
		builder.parameterEkle("@ConnectionName",DbType.String, row.ConnectionName);
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
