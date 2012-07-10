
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
public partial class IdentityTinyIntDal : BaseDal<IdentityTinyInt>
{
	
	public override string DatabaseName
	{
		get
		{
			return "KARKAS_ORNEK";
		}
	}
	protected override void identityKolonDegeriniSetle(IdentityTinyInt pTypeLibrary,long pIdentityKolonValue)
	{
		pTypeLibrary.IdentityTinyIntKey = (byte )pIdentityKolonValue;
	}
	protected override string SelectCountString
	{
		get
		{
			return @"SELECT COUNT(*) FROM ORNEKLER.IDENTITY_TINY_INT";
		}
	}
	protected override string SelectString
	{
		get 
		{
			return @"SELECT IdentityTinyIntKey,Adi FROM ORNEKLER.IDENTITY_TINY_INT";
		}
	}
	protected override string DeleteString
	{
		get 
		{
			return @"DELETE   FROM ORNEKLER.IDENTITY_TINY_INT WHERE IdentityTinyIntKey = @IdentityTinyIntKey";
		}
	}
	protected override string UpdateString
	{
		get 
		{
			return @"UPDATE ORNEKLER.IDENTITY_TINY_INT
			 SET 
			Adi = @Adi			
			WHERE 
			 IdentityTinyIntKey = @IdentityTinyIntKey ";
		}
	}
	protected override string InsertString
	{
		get 
		{
			return @"INSERT INTO ORNEKLER.IDENTITY_TINY_INT 
			 (Adi) 
			 VALUES 
						(@Adi);SELECT scope_identity();";
		}
	}
	public IdentityTinyInt SorgulaIdentityTinyIntKeyIle(byte p1)
	{
		List<IdentityTinyInt> liste = new List<IdentityTinyInt>();
		SorguCalistir(liste,String.Format(" IdentityTinyIntKey = '{0}'", p1));		
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
			return true;
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
			return "IdentityTinyIntKey";
		}
	}
	
	public virtual void Sil(byte IdentityTinyIntKey)
	{
		IdentityTinyInt row = new IdentityTinyInt();
		row.IdentityTinyIntKey = IdentityTinyIntKey;
		base.Sil(row);
	}
	protected override void ProcessRow(IDataReader dr, IdentityTinyInt row)
	{
		row.IdentityTinyIntKey = dr.GetByte(0);
		if (!dr.IsDBNull(1))
		{
			row.Adi = dr.GetString(1);
		}
	}
	protected override void InsertCommandParametersAdd(DbCommand cmd, IdentityTinyInt row)
	{
		ParameterBuilder builder = new ParameterBuilder(cmd);
		builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi,50);
	}
	protected override void UpdateCommandParametersAdd(DbCommand cmd, 	IdentityTinyInt	 row)
	{
		ParameterBuilder builder = new ParameterBuilder(cmd);
		builder.parameterEkle("@IdentityTinyIntKey",SqlDbType.TinyInt, row.IdentityTinyIntKey);
		builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi,50);
	}
	protected override void DeleteCommandParametersAdd(DbCommand cmd, 	IdentityTinyInt	 row)
	{
		ParameterBuilder builder = new ParameterBuilder(cmd);
		builder.parameterEkle("@IdentityTinyIntKey",SqlDbType.TinyInt, row.IdentityTinyIntKey);
	}
}
}
