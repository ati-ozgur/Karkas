
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Karkas.Core.DataUtil;
using Karkas.Ornek.TypeLibrary;
using Karkas.Ornek.TypeLibrary.Ornekler;
using Karkas.Ornek.Dal.Ornekler;


namespace Karkas.Ornek.Bs.Ornekler
{
	public partial class 	IdentityTinyIntBs : BaseBs<IdentityTinyInt, IdentityTinyIntDal>
		{
			public override string DatabaseName
			{
				get
				{
					return "KARKAS_ORNEK";
				}
			}
			public void Sil(byte IdentityTinyIntKey)
			{
				dal.Sil(IdentityTinyIntKey);
			}
			public IdentityTinyInt SorgulaIdentityTinyIntKeyIle(byte p1)
			{
				return dal.SorgulaIdentityTinyIntKeyIle(p1);
			}
		}
	}

