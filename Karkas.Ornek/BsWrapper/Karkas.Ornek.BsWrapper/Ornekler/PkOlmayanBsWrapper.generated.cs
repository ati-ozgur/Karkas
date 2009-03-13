
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
	public partial class 	PkOlmayanBsWrapper	: BaseBsWrapper<PkOlmayan,PkOlmayanDal,PkOlmayanBs>	
	{
		
		PkOlmayanBs _bs = new PkOlmayanBs();
		public override PkOlmayanBs bs
		{
			get
			{
				return _bs;
			}
		}
		public void Sil( )
		{
			bs.Sil();
		}
		[DataObjectMethod(DataObjectMethodType.Select)]
		public PkOlmayan SorgulaIle( p1)
		{
			return bs.SorgulaIle(p1);
		}
		
		
	}
}
