
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
	public partial class 	IsimlendirmeBozukBsWrapper	: BaseBsWrapper<IsimlendirmeBozuk,IsimlendirmeBozukDal,IsimlendirmeBozukBs>	
	{
		
		IsimlendirmeBozukBs _bs = new IsimlendirmeBozukBs();
		public override IsimlendirmeBozukBs bs
		{
			get
			{
				return _bs;
			}
		}
		public void Sil(int KISI_OID)
		{
			bs.Sil(KISI_OID);
		}
		[DataObjectMethod(DataObjectMethodType.Select)]
		public IsimlendirmeBozuk SorgulaKISI_OIDIle(int p1)
		{
			return bs.SorgulaKISI_OIDIle(p1);
		}
		
		
	}
}
