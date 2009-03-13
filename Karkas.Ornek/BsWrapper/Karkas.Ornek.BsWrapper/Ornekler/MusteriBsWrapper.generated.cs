
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
	public partial class 	MusteriBsWrapper	: BaseBsWrapper<Musteri,MusteriDal,MusteriBs>	
	{
		
		MusteriBs _bs = new MusteriBs();
		public override MusteriBs bs
		{
			get
			{
				return _bs;
			}
		}
		public void Sil(Guid MusteriKey)
		{
			bs.Sil(MusteriKey);
		}
		[DataObjectMethod(DataObjectMethodType.Select)]
		public Musteri SorgulaMusteriKeyIle(Guid p1)
		{
			return bs.SorgulaMusteriKeyIle(p1);
		}
		
		
	}
}
