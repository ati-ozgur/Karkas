using System;
using System.Data;
using System.Text;
using System.Configuration;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Collections.Generic;
using Karkas.Core.TypeLibrary;
using Karkas.Core.Onaylama;
using Karkas.Core.Onaylama.ForPonos;

namespace Karkas.Ornek.TypeLibrary.Dbo

{
		[Serializable]
		[DebuggerDisplay("")]
		public partial class 		OrnekSistemView		
//::PRESERVE_BEGIN inheritance::// 
: BaseTypeLibrary 
//::PRESERVE_END inheritance:://
		{
			private string tableName;
			private int id;
			private string type;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public string TableName
			{
				[DebuggerStepThrough]
				get
				{
					return tableName;
				}
				[DebuggerStepThrough]
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (tableName!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					tableName = value;
				}
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public int Id
			{
				[DebuggerStepThrough]
				get
				{
					return id;
				}
				[DebuggerStepThrough]
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (id!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					id = value;
				}
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public string Type
			{
				[DebuggerStepThrough]
				get
				{
					return type;
				}
				[DebuggerStepThrough]
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (type!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					type = value;
				}
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[XmlIgnore, SoapIgnore]
			public string TableNameAsString
			{
				[DebuggerStepThrough]
				get
				{
					 return tableName != null ? tableName.ToString() : ""; 
				}
				[DebuggerStepThrough]
				set
				{
					throw new ArgumentException("string'ten degisken tipine cevirim desteklenmemektedir");
				}
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[XmlIgnore, SoapIgnore]
			public string IdAsString
			{
				[DebuggerStepThrough]
				get
				{
					 return id.ToString(); 
				}
				[DebuggerStepThrough]
				set
				{
					try
					{
						int _a = Convert.ToInt32(value);
					Id = _a;
					}
					catch(Exception)
					{
						this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"Id","Ceviri islemi Başarısız oldu"));
					}
				}
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[XmlIgnore, SoapIgnore]
			public string TypeAsString
			{
				[DebuggerStepThrough]
				get
				{
					 return type != null ? type.ToString() : ""; 
				}
				[DebuggerStepThrough]
				set
				{
					Type = value;
				}
			}

		public class PropertyIsimleri
		{
			public const string TableName = "TableName";
			public const string Id = "id";
			public const string Type = "type";
		}
			public OrnekSistemView ShallowCopy()
			{
				OrnekSistemView obj = new OrnekSistemView();
				obj.tableName = tableName;
				obj.id = id;
				obj.type = type;
				return obj;
			}
		

		protected override void OnaylamaListesiniOlusturCodeGeneration()
		{
			
			this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "TableName"));			
			this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "Id"));		}
		public static class EtiketIsimleri
		{
			const string namespaceVeClass = "Karkas.Ornek.TypeLibrary.Dbo";
			public static string TableName
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".TableName"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "TableName";
					}
				}
			}
			public static string Id
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".Id"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "Id";
					}
				}
			}
			public static string Type
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".Type"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "Type";
					}
				}
			}
		}
	}
}
