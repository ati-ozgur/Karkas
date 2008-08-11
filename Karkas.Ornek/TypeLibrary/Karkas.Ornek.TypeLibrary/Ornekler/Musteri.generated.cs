using System;
using System.Collections.Generic;
using System.Text;
using Karkas.Core.TypeLibrary;
using Karkas.Core.Validation.ForPonos;
using System.Data;

namespace Karkas.Ornek.TypeLibrary.Ornekler
{
	[Serializable]
	public partial class 	Musteri	
//::PRESERVE_BEGIN inheritance::// 
: BaseTypeLibrary 
//::PRESERVE_END inheritance:://
	{
		private Guid musteriKey;
		private string adi;
		private string soyadi;
		private string ikinciAdi;
		private Nullable<DateTime> dogumTarihi;
		private string tamAdi;

		public Guid MusteriKey
		{
			get
			{
				return musteriKey;
			}
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (musteriKey!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				musteriKey = value;
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

		public string IkinciAdi
		{
			get
			{
				return ikinciAdi;
			}
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (ikinciAdi!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				ikinciAdi = value;
			}
		}

		public Nullable<DateTime> DogumTarihi
		{
			get
			{
				return dogumTarihi;
			}
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (dogumTarihi!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				dogumTarihi = value;
			}
		}

		public string TamAdi
		{
			get
			{
				return tamAdi;
			}
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (tamAdi!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				tamAdi = value;
			}
		}

		public Musteri ShallowCopy()
		{
			Musteri obj = new Musteri();
			obj.musteriKey = musteriKey;
			obj.adi = adi;
			obj.soyadi = soyadi;
			obj.ikinciAdi = ikinciAdi;
			obj.dogumTarihi = dogumTarihi;
			obj.tamAdi = tamAdi;
			return obj;
		}
	

	protected override void ValidationListesiniOlusturCodeGeneration()
	{			
			this.Validator.ValidatorList.Add(new RequiredFieldValidator(this, "Adi"));			
			this.Validator.ValidatorList.Add(new RequiredFieldValidator(this, "Soyadi"));		
		}
	}
}
