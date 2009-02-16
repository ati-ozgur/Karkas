
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Karkas.Core.DataUtil;
using Karkas.Ornek.TypeLibrary;
using Karkas.Ornek.TypeLibrary.Ornekler;
using Karkas.Ornek.Dal.Ornekler;


namespace Karkas.Ornek.Bs.Ornekler
{
	public partial class 	IsimlendirmeBozukBs : BaseBs<IsimlendirmeBozuk, IsimlendirmeBozukDal>
		{
			public override string DatabaseName
			{
				get
				{
					return "KARKAS_ORNEK";
				}
			}
			public void Sil(int KISI_OID)
			{
				dal.Sil(KISI_OID);
			}
			public IsimlendirmeBozuk SorgulaKISI_OIDIle(int p1)
			{
				return dal.SorgulaKISI_OIDIle(p1);
			}
		}
	}

