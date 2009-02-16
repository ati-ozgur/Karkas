
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
	public partial class 	IdentityBigIntBs : BaseBs<IdentityBigInt, IdentityBigIntDal>
		{
			public override string DatabaseName
			{
				get
				{
					return "KARKAS_ORNEK";
				}
			}
			public void Sil(long IdentityBigIntKey)
			{
				dal.Sil(IdentityBigIntKey);
			}
			public IdentityBigInt SorgulaIdentityBigIntKeyIle(long p1)
			{
				return dal.SorgulaIdentityBigIntKeyIle(p1);
			}
		}
	}

