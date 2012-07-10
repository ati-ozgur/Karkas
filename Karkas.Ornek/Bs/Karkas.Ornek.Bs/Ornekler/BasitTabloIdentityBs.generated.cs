﻿
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
	public partial class BasitTabloIdentityBs : BaseBs<BasitTabloIdentity, BasitTabloIdentityDal>
	{
		public override string DatabaseName
		{
			get
			{
				return "KARKAS_ORNEK";
			}
		}
		public void Sil(int pBasitTabloIdentityKey)
		{
			dal.Sil( pBasitTabloIdentityKey);
		}
		public BasitTabloIdentity SorgulaBasitTabloIdentityKeyIle(int p1)
		{
			return dal.SorgulaBasitTabloIdentityKeyIle(p1);
		}
	}
}
