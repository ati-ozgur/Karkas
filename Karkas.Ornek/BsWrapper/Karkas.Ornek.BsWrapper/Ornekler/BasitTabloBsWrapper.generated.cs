
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
	public partial class 	BasitTabloBsWrapper	: BaseBsWrapper<BasitTablo,BasitTabloDal,BasitTabloBs>	
	{
		
		BasitTabloBs _bs = new BasitTabloBs();
		public override BasitTabloBs bs
		{
			get
			{
				return _bs;
			}
		}
		public void Sil(Guid BasitTabloKey)
		{
			bs.Sil(BasitTabloKey);
		}
		[DataObjectMethod(DataObjectMethodType.Select)]
		public BasitTablo SorgulaBasitTabloKeyIle(Guid p1)
		{
			return bs.SorgulaBasitTabloKeyIle(p1);
		}
		
		
	}
}
