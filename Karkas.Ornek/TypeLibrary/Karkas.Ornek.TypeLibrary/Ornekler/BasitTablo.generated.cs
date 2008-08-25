using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Karkas.Core.TypeLibrary;
using Karkas.Core.Onaylama;
using Karkas.Core.Onaylama.ForPonos;

namespace Karkas.Ornek.TypeLibrary.Ornekler
{
	[Serializable]
	public partial class 	BasitTablo	
//::PRESERVE_BEGIN inheritance::// 
: BaseTypeLibrary 
//::PRESERVE_END inheritance:://
	{
		private Guid basitTabloKey;
		private string adi;
		private string soyadi;

		public Guid BasitTabloKey
		{
			get
			{
				return basitTabloKey;
			}
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (basitTabloKey!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				basitTabloKey = value;
			}
		}

		public string Adi
		{
			get
			{
				return adi;
			}
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (adi!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				adi = value;
			}
		}

		public string Soyadi
		{
			get
			{
				return soyadi;
			}
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (soyadi!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				soyadi = value;
			}
		}

		public BasitTablo ShallowCopy()
		{
			BasitTablo obj = new BasitTablo();
			obj.basitTabloKey = basitTabloKey;
			obj.adi = adi;
			obj.soyadi = soyadi;
			return obj;
		}
	
	public class PropertyIsimleri
	{
		public const string BasitTabloKey = "BasitTabloKey";
		public const string Adi = "Adi";
		public const string Soyadi = "Soyadi";
	}

	protected override void OnaylamaListesiniOlusturCodeGeneration()
	{
		
		this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "Adi"));		
		this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "Soyadi"));	}
	}
}
