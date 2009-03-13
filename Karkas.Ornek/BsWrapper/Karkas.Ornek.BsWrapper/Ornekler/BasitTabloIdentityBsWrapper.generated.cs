
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
	public partial class 	BasitTabloIdentityBsWrapper	: BaseBsWrapper<BasitTabloIdentity,BasitTabloIdentityDal,BasitTabloIdentityBs>	
	{
		
		BasitTabloIdentityBs _bs = new BasitTabloIdentityBs();
		public override BasitTabloIdentityBs bs
		{
			get
			{
				return _bs;
			}
		}
		public void Sil(int BasitTabloIdentityKey)
		{
			bs.Sil(BasitTabloIdentityKey);
		}
		[DataObjectMethod(DataObjectMethodType.Select)]
		public BasitTabloIdentity SorgulaBasitTabloIdentityKeyIle(int p1)
		{
			return bs.SorgulaBasitTabloIdentityKeyIle(p1);
		}
		
		
	}
}
