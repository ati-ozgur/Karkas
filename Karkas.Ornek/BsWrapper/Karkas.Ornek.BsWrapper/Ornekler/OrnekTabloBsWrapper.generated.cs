
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
	public partial class 	OrnekTabloBsWrapper	: BaseBsWrapper<OrnekTablo,OrnekTabloDal,OrnekTabloBs>	
	{
		
		OrnekTabloBs _bs = new OrnekTabloBs();
		public override OrnekTabloBs bs
		{
			get
			{
				return _bs;
			}
		}
		public void Sil(Guid OrnekTabloKey)
		{
			bs.Sil(OrnekTabloKey);
		}
		[DataObjectMethod(DataObjectMethodType.Select)]
		public OrnekTablo SorgulaOrnekTabloKeyIle(Guid p1)
		{
			return bs.SorgulaOrnekTabloKeyIle(p1);
		}
		
		
	}
}
