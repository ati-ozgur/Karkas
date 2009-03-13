
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
	public partial class 	IdentitySmallIntBsWrapper	: BaseBsWrapper<IdentitySmallInt,IdentitySmallIntDal,IdentitySmallIntBs>	
	{
		
		IdentitySmallIntBs _bs = new IdentitySmallIntBs();
		public override IdentitySmallIntBs bs
		{
			get
			{
				return _bs;
			}
		}
		public void Sil(short IdentitySmallIntKey)
		{
			bs.Sil(IdentitySmallIntKey);
		}
		[DataObjectMethod(DataObjectMethodType.Select)]
		public IdentitySmallInt SorgulaIdentitySmallIntKeyIle(short p1)
		{
			return bs.SorgulaIdentitySmallIntKeyIle(p1);
		}
		
		
	}
}
