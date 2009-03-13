
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
	public partial class 	ConcurrencyOrnekBsWrapper	: BaseBsWrapper<ConcurrencyOrnek,ConcurrencyOrnekDal,ConcurrencyOrnekBs>	
	{
		
		ConcurrencyOrnekBs _bs = new ConcurrencyOrnekBs();
		public override ConcurrencyOrnekBs bs
		{
			get
			{
				return _bs;
			}
		}
		public void Sil(Guid ConcurrencyOrnekKey)
		{
			bs.Sil(ConcurrencyOrnekKey);
		}
		[DataObjectMethod(DataObjectMethodType.Select)]
		public ConcurrencyOrnek SorgulaConcurrencyOrnekKeyIle(Guid p1)
		{
			return bs.SorgulaConcurrencyOrnekKeyIle(p1);
		}
		
		
	}
}
