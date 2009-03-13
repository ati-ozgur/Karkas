
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
	public partial class 	DenemeGuidIdentityBsWrapper	: BaseBsWrapper<DenemeGuidIdentity,DenemeGuidIdentityDal,DenemeGuidIdentityBs>	
	{
		
		DenemeGuidIdentityBs _bs = new DenemeGuidIdentityBs();
		public override DenemeGuidIdentityBs bs
		{
			get
			{
				return _bs;
			}
		}
		public void Sil(Guid DenemeKey)
		{
			bs.Sil(DenemeKey);
		}
		[DataObjectMethod(DataObjectMethodType.Select)]
		public DenemeGuidIdentity SorgulaDenemeKeyIle(Guid p1)
		{
			return bs.SorgulaDenemeKeyIle(p1);
		}
		
		
	}
}
