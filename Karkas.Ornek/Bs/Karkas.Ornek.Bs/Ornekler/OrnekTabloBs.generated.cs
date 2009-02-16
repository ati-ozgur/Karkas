
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
	public partial class 	OrnekTabloBs : BaseBs<OrnekTablo, OrnekTabloDal>
		{
			public override string DatabaseName
			{
				get
				{
					return "KARKAS_ORNEK";
				}
			}
			public void Sil(Guid OrnekTabloKey)
			{
				dal.Sil(OrnekTabloKey);
			}
			public OrnekTablo SorgulaOrnekTabloKeyIle(Guid p1)
			{
				return dal.SorgulaOrnekTabloKeyIle(p1);
			}
		}
	}

