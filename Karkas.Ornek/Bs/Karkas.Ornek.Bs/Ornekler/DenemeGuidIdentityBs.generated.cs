
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
	public partial class DenemeGuidIdentityBs : BaseBs<DenemeGuidIdentity, DenemeGuidIdentityDal>
	{
		public override string DatabaseName
		{
			get
			{
				return "KARKAS_ORNEK";
			}
		}
		public void Sil(Guid pDenemeKey)
		{
			dal.Sil( pDenemeKey);
		}
		public DenemeGuidIdentity SorgulaDenemeKeyIle(Guid p1)
		{
			return dal.SorgulaDenemeKeyIle(p1);
		}
	}
}
