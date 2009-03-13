
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
	public partial class 	MusteriSiparisBsWrapper	: BaseBsWrapper<MusteriSiparis,MusteriSiparisDal,MusteriSiparisBs>	
	{
		
		MusteriSiparisBs _bs = new MusteriSiparisBs();
		public override MusteriSiparisBs bs
		{
			get
			{
				return _bs;
			}
		}
		public void Sil(Guid MusteriSiparisKey)
		{
			bs.Sil(MusteriSiparisKey);
		}
		[DataObjectMethod(DataObjectMethodType.Select)]
		public MusteriSiparis SorgulaMusteriSiparisKeyIle(Guid p1)
		{
			return bs.SorgulaMusteriSiparisKeyIle(p1);
		}
		
		
	}
}
