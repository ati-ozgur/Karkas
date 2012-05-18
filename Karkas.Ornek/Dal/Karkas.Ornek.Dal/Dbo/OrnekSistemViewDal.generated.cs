using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Karkas.Core.DataUtil;
using Karkas.Ornek.TypeLibrary;
using Karkas.Ornek.TypeLibrary.Dbo;
using System.Data.Common;


namespace Karkas.Ornek.Dal.Dbo
{
	public partial class OrnekSistemViewDal : BaseDal<OrnekSistemView>
	{
		
		public override string DatabaseName
		{
			get
			{
				return "KARKAS_ORNEK";
			}
		}
		protected override void identityKolonDegeriniSetle(OrnekSistemView pTypeLibrary,long pIdentityKolonValue)
		{
		}
		protected override string SelectCountString
		{
			get
			{
				return @"SELECT COUNT(*) FROM dbo.ORNEK_SISTEM_VIEW";
			}
		}
		protected override string SelectString
		{
			get 
			{
				return @"SELECT TableName,id,type FROM dbo.ORNEK_SISTEM_VIEW";
			}
		}
		protected override string DeleteString
		{
			get 
			{
				throw new NotSupportedException("VIEW ustunden Ekle/Guncelle/Sil desteklenmemektedir");
			}
		}
		protected override string UpdateString
		{
			get 
			{
				throw new NotSupportedException("VIEW ustunden Ekle/Guncelle/Sil desteklenmemektedir");
			}
		}
		protected override string InsertString
		{
			get 
			{
				throw new NotSupportedException("VIEW ustunden Ekle/Guncelle/Sil desteklenmemektedir");
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
				return "";
			}
		}
		
		protected override void ProcessRow(System.Data.IDataReader dr, OrnekSistemView row)
		{
			row.TableName = dr.GetString(0);
			row.Id = dr.GetInt32(1);
			if (!dr.IsDBNull(2))
			{
				row.Type = dr.GetString(2);
			}
		}
		protected override void InsertCommandParametersAdd(DbCommand cmd, OrnekSistemView row)
		{
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@TableName",DbType.AnsiString, row.TableName,128);
			builder.parameterEkle("@id",DbType.Int32, row.Id);
			builder.parameterEkle("@type",DbType.AnsiStringFixedLength, row.Type,2);
		}
        protected override void UpdateCommandParametersAdd(DbCommand cmd, OrnekSistemView row)
		{
			ParameterBuilder builder = new ParameterBuilder(cmd);
            builder.parameterEkle("@TableName", DbType.AnsiString, row.TableName, 128);
            builder.parameterEkle("@id", DbType.Int32, row.Id);
            builder.parameterEkle("@type", DbType.AnsiStringFixedLength, row.Type, 2);
        }
        protected override void DeleteCommandParametersAdd(DbCommand cmd, OrnekSistemView row)
		{
			ParameterBuilder builder = new ParameterBuilder(cmd);
		}
	}
}
