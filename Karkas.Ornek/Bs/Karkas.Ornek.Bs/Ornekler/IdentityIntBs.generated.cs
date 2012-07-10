
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
	public partial class IdentityIntBs : BaseBs<IdentityInt, IdentityIntDal>
	{
		public override string DatabaseName
		{
			get
			{
				return "KARKAS_ORNEK";
			}
		}
		public void Sil(int pIdentityIntKey)
		{
			dal.Sil( pIdentityIntKey);
		}
		public IdentityInt SorgulaIdentityIntKeyIle(int p1)
		{
			return dal.SorgulaIdentityIntKeyIle(p1);
		}
	}
}
