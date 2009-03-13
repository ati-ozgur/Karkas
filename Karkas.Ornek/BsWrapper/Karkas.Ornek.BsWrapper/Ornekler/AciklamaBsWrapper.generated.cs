
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
	public partial class 	AciklamaBsWrapper	: BaseBsWrapper<Aciklama,AciklamaDal,AciklamaBs>	
	{
		
		AciklamaBs _bs = new AciklamaBs();
		public override AciklamaBs bs
		{
			get
			{
				return _bs;
			}
		}
		public void Sil(Guid AciklamaKey)
		{
			bs.Sil(AciklamaKey);
		}
		[DataObjectMethod(DataObjectMethodType.Select)]
		public Aciklama SorgulaAciklamaKeyIle(Guid p1)
		{
			return bs.SorgulaAciklamaKeyIle(p1);
		}
		
		
	}
}
