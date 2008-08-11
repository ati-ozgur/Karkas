using System;
using System.Collections.Generic;
using System.Text;
using Karkas.Core.TypeLibrary;
using Karkas.Core.Validation.ForPonos;
using System.Data;

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
	

	protected override void ValidationListesiniOlusturCodeGeneration()
	{			
			this.Validator.ValidatorList.Add(new RequiredFieldValidator(this, "Adi"));			
			this.Validator.ValidatorList.Add(new RequiredFieldValidator(this, "Soyadi"));		
		}
	}
}
