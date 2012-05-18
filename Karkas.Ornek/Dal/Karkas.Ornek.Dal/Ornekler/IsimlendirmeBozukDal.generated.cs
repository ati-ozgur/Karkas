using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Karkas.Core.DataUtil;
using Karkas.Ornek.TypeLibrary;
using Karkas.Ornek.TypeLibrary.Ornekler;
using System.Data.Common;


namespace Karkas.Ornek.Dal.Ornekler
{
	public partial class IsimlendirmeBozukDal : BaseDal<IsimlendirmeBozuk>
	{
		
		public override string DatabaseName
		{
			get
			{
				return "KARKAS_ORNEK";
			}
		}
		protected override void identityKolonDegeriniSetle(IsimlendirmeBozuk pTypeLibrary,long pIdentityKolonValue)
		{
		}
		protected override string SelectCountString
		{
			get
			{
				return @"SELECT COUNT(*) FROM ORNEKLER.ISIMLENDIRME_BOZUK";
			}
		}
		protected override string SelectString
		{
			get 
			{
				return @"SELECT KISI_OID,ADI,SOYADI FROM ORNEKLER.ISIMLENDIRME_BOZUK";
			}
		}
		protected override string DeleteString
		{
			get 
			{
				return @"DELETE   FROM ORNEKLER.ISIMLENDIRME_BOZUK WHERE KISI_OID = @KISI_OID";
			}
		}
		protected override string UpdateString
		{
			get 
			{
				return @"UPDATE ORNEKLER.ISIMLENDIRME_BOZUK
				 SET 
				ADI = @ADI,SOYADI = @SOYADI				
				WHERE 
				 KISI_OID = @KISI_OID ";
			}
		}
		protected override string InsertString
		{
			get 
			{
				return @"INSERT INTO ORNEKLER.ISIMLENDIRME_BOZUK 
				 (KISI_OID,ADI,SOYADI) 
				 VALUES 
								(@KISI_OID,@ADI,@SOYADI)";
			}
		}
		public IsimlendirmeBozuk SorgulaKISI_OIDIle(int p1)
		{
			List<IsimlendirmeBozuk> liste = new List<IsimlendirmeBozuk>();
			SorguCalistir(liste,String.Format(" KISI_OID = '{0}'", p1));			
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
				return "KISI_OID";
			}
		}
		
		public virtual void Sil(int KisiOid)
		{
			IsimlendirmeBozuk row = new IsimlendirmeBozuk();
			row.KisiOid = KisiOid;
			base.Sil(row);
		}
		protected override void ProcessRow(System.Data.IDataReader dr, IsimlendirmeBozuk row)
		{
			row.KisiOid = dr.GetInt32(0);
			row.Adi = dr.GetString(1);
			row.Soyadi = dr.GetString(2);
		}
		protected override void InsertCommandParametersAdd(DbCommand cmd, IsimlendirmeBozuk row)
		{
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@KISI_OID",DbType.Int32, row.KisiOid);
			builder.parameterEkle("@ADI",DbType.String, row.Adi,50);
			builder.parameterEkle("@SOYADI",DbType.String, row.Soyadi,50);
		}
		protected override void UpdateCommandParametersAdd(DbCommand cmd, 		IsimlendirmeBozuk		 row)
		{
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@KISI_OID",DbType.Int32, row.KisiOid);
			builder.parameterEkle("@ADI",DbType.String, row.Adi,50);
			builder.parameterEkle("@SOYADI",DbType.String, row.Soyadi,50);
		}
		protected override void DeleteCommandParametersAdd(DbCommand cmd, 		IsimlendirmeBozuk		 row)
		{
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@KISI_OID",DbType.Int32, row.KisiOid);
		}
	}
}
