using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Karkas.Core.DataUtil;
namespace Karkas.Ornek.Dal.Ornekler
{
	public partial class StoredProcedures
	{
		public static DataTable MusteriSorgulaMusteriKeyIle
		(

			Guid? @MusteriKey
			, AdoTemplate template
			)
			{
				ParameterBuilder builder = new ParameterBuilder();
				
				 builder.parameterEkle( "@MusteriKey",SqlDbType.UniqueIdentifier,@MusteriKey);
				SqlCommand cmd = new SqlCommand();
				cmd.CommandText = "ORNEKLER.MUSTERI_SORGULA_MUSTERI_KEY_ILE";
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddRange(builder.GetParameterArray());
				DataTable _tmpDataTable = template.DataTableOlustur(cmd);
				return _tmpDataTable;
			}
			public static DataTable MusteriSorgulaMusteriKeyIle
			(

				Guid? @MusteriKey
				)
				{
					AdoTemplate template = new AdoTemplate();
                    template.Connection = ConnectionSingleton.Instance.getConnection("KARKAS_ORNEK");
                    return MusteriSorgulaMusteriKeyIle(
						@MusteriKey
						,template
						);
					}
				}
			}
