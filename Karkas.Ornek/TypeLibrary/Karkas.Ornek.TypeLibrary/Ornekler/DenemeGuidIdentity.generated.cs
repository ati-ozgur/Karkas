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
	public partial class 	DenemeGuidIdentity	
//::PRESERVE_BEGIN inheritance::// 
: BaseTypeLibrary 
//::PRESERVE_END inheritance:://
	{
		private Guid denemeKey;
		private int denemeNo;
		private string denemeKolon;

		public Guid DenemeKey
		{
			get
			{
				return denemeKey;
			}
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (denemeKey!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				denemeKey = value;
			}
		}

		public int DenemeNo
		{
			get
			{
				return denemeNo;
			}
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (denemeNo!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				denemeNo = value;
			}
		}

		public string DenemeKolon
		{
			get
			{
				return denemeKolon;
			}
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (denemeKolon!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				denemeKolon = value;
			}
		}

		public DenemeGuidIdentity ShallowCopy()
		{
			DenemeGuidIdentity obj = new DenemeGuidIdentity();
			obj.denemeKey = denemeKey;
			obj.denemeNo = denemeNo;
			obj.denemeKolon = denemeKolon;
			return obj;
		}
	
	public class PropertyIsimleri
	{
		public const string DenemeKey = "DenemeKey";
		public const string DenemeNo = "DenemeNo";
		public const string DenemeKolon = "DenemeKolon";
	}

	protected override void OnaylamaListesiniOlusturCodeGeneration()
	{
		
		this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "DenemeNo"));		
		this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "DenemeKolon"));	}
	}
}
