
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
	public partial class 	IdentityIntBsWrapper	: BaseBsWrapper<IdentityInt,IdentityIntDal,IdentityIntBs>	
	{
		
		IdentityIntBs _bs = new IdentityIntBs();
		public override IdentityIntBs bs
		{
			get
			{
				return _bs;
			}
		}
		public void Sil(int IdentityIntKey)
		{
			bs.Sil(IdentityIntKey);
		}
		[DataObjectMethod(DataObjectMethodType.Select)]
		public IdentityInt SorgulaIdentityIntKeyIle(int p1)
		{
			return bs.SorgulaIdentityIntKeyIle(p1);
		}
		
		
	}
}
