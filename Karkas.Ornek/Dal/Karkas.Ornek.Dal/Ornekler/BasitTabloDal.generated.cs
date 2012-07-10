
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using Karkas.Core.DataUtil;
using Karkas.Ornek.TypeLibrary;
using Karkas.Ornek.TypeLibrary.Ornekler;


namespace Karkas.Ornek.Dal.Ornekler
{
public partial class BasitTabloDal : BaseDal<BasitTablo>
{
	
	public override string DatabaseName
	{
		get
		{
			return "KARKAS_ORNEK";
		}
	}
	protected override void identityKolonDegeriniSetle(BasitTablo pTypeLibrary,long pIdentityKolonValue)
	{
	}
	protected override string SelectCountString
	{
		get
		{
			return @"SELECT COUNT(*) FROM ORNEKLER.BASIT_TABLO";
		}
	}
	protected override string SelectString
	{
		get 
		{
			return @"SELECT BasitTabloKey,Adi,Soyadi,GKullaniciKey,UTarihi FROM ORNEKLER.BASIT_TABLO";
		}
	}
	protected override string DeleteString
	{
		get 
		{
			return @"DELETE   FROM ORNEKLER.BASIT_TABLO WHERE BasitTabloKey = @BasitTabloKey";
		}
	}
	protected override string UpdateString
	{
		get 
		{
			return @"UPDATE ORNEKLER.BASIT_TABLO
			 SET 
			Adi = @Adi,Soyadi = @Soyadi,GKullaniciKey = @GKullaniciKey,UTarihi = @UTarihi			
			WHERE 
			 BasitTabloKey = @BasitTabloKey ";
		}
	}
	protected override string InsertString
	{
		get 
		{
			return @"INSERT INTO ORNEKLER.BASIT_TABLO 
			 (BasitTabloKey,Adi,Soyadi,GKullaniciKey,UTarihi) 
			 VALUES 
						(@BasitTabloKey,@Adi,@Soyadi,@GKullaniciKey,@UTarihi)";
		}
	}
	public BasitTablo SorgulaBasitTabloKeyIle(Guid p1)
	{
		List<BasitTablo> liste = new List<BasitTablo>();
		SorguCalistir(liste,String.Format(" BasitTabloKey = '{0}'", p1));		
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
			return true;
		}
	}
	
	
	public override string PrimaryKey
	{
		get
		{
			return "BasitTabloKey";
		}
	}
	
	public virtual void Sil(Guid BasitTabloKey)
	{
		BasitTablo row = new BasitTablo();
		row.BasitTabloKey = BasitTabloKey;
		base.Sil(row);
	}
	protected override void ProcessRow(IDataReader dr, BasitTablo row)
	{
		row.BasitTabloKey = dr.GetGuid(0);
		row.Adi = dr.GetString(1);
		row.Soyadi = dr.GetString(2);
		if (!dr.IsDBNull(3))
		{
			row.GkullaniciKey = dr.GetGuid(3);
		}
		if (!dr.IsDBNull(4))
		{
			row.Utarihi = dr.GetDateTime(4);
		}
	}
	protected override void InsertCommandParametersAdd(DbCommand cmd, BasitTablo row)
	{
		ParameterBuilder builder = new ParameterBuilder(cmd);
		builder.parameterEkle("@BasitTabloKey",SqlDbType.UniqueIdentifier, row.BasitTabloKey);
		builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi,50);
		builder.parameterEkle("@Soyadi",SqlDbType.VarChar, row.Soyadi,50);
		builder.parameterEkle("@GKullaniciKey",SqlDbType.UniqueIdentifier, row.GkullaniciKey);
		builder.parameterEkle("@UTarihi",SqlDbType.SmallDateTime, row.Utarihi);
	}
	protected override void UpdateCommandParametersAdd(DbCommand cmd, 	BasitTablo	 row)
	{
		ParameterBuilder builder = new ParameterBuilder(cmd);
		builder.parameterEkle("@BasitTabloKey",SqlDbType.UniqueIdentifier, row.BasitTabloKey);
		builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi,50);
		builder.parameterEkle("@Soyadi",SqlDbType.VarChar, row.Soyadi,50);
		builder.parameterEkle("@GKullaniciKey",SqlDbType.UniqueIdentifier, row.GkullaniciKey);
		builder.parameterEkle("@UTarihi",SqlDbType.SmallDateTime, row.Utarihi);
	}
	protected override void DeleteCommandParametersAdd(DbCommand cmd, 	BasitTablo	 row)
	{
		ParameterBuilder builder = new ParameterBuilder(cmd);
		builder.parameterEkle("@BasitTabloKey",SqlDbType.UniqueIdentifier, row.BasitTabloKey);
	}
}
}
