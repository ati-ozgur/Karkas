
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.ComponentModel;
using System.Web;
using System.Web.Caching;
using Karkas.Web.Helpers.HelperClasses;
using Karkas.Core.DataUtil.BaseClasses;
using Karkas.Ornek.TypeLibrary.Ornekler;
using Karkas.Ornek.Dal.Ornekler;
using Karkas.Ornek.Bs.Ornekler;
namespace Karkas.Ornek.BsWrapper.Ornekler
{
	[DataObject]
	public partial class 	IdentityBigIntBsWrapper	: BaseBsWrapper<IdentityBigInt,IdentityBigIntDal,IdentityBigIntBs>	
	{
		
		IdentityBigIntBs _bs = new IdentityBigIntBs();
		public override IdentityBigIntBs bs
		{
			get
			{
				return _bs;
			}
		}
		public void Sil(long IdentityBigIntKey)
		{
			bs.Sil(IdentityBigIntKey);
		}
		[DataObjectMethod(DataObjectMethodType.Select)]
		public IdentityBigInt SorgulaIdentityBigIntKeyIle(long p1)
		{
			return bs.SorgulaIdentityBigIntKeyIle(p1);
		}
		
		
	}
}
