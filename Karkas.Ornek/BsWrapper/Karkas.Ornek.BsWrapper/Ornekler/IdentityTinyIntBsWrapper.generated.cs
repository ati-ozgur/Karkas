
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
	public partial class 	IdentityTinyIntBsWrapper	: BaseBsWrapper<IdentityTinyInt,IdentityTinyIntDal,IdentityTinyIntBs>	
	{
		
		IdentityTinyIntBs _bs = new IdentityTinyIntBs();
		public override IdentityTinyIntBs bs
		{
			get
			{
				return _bs;
			}
		}
		public void Sil(byte IdentityTinyIntKey)
		{
			bs.Sil(IdentityTinyIntKey);
		}
		[DataObjectMethod(DataObjectMethodType.Select)]
		public IdentityTinyInt SorgulaIdentityTinyIntKeyIle(byte p1)
		{
			return bs.SorgulaIdentityTinyIntKeyIle(p1);
		}
		
		
	}
}
