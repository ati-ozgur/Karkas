
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
	public partial class 	MusteriBs : BaseBs<Musteri, MusteriDal>
		{
			public void Sil(Guid MusteriKey)
			{
				dal.Sil(MusteriKey);
			}
			public Musteri SorgulaMusteriKeyIle(Guid p1)
			{
				return dal.SorgulaMusteriKeyIle(p1);
			}
		}
	}
