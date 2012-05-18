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
		public static int Ornek
		(

			int? @SAYI1
			, AdoTemplate template
			)
			{
				ParameterBuilder builder = new ParameterBuilder();
				
				 builder.parameterEkle( "@SAYI1",SqlDbType.Int,@SAYI1);
				SqlCommand cmd = new SqlCommand();
				cmd.CommandText = "ORNEKLER.ORNEK";
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddRange(builder.GetParameterArray());
				int tmp = Convert.ToInt32(template.TekDegerGetir(cmd));;
				return tmp;
			}
			public static int Ornek
			(

				int? @SAYI1
				)
				{
					AdoTemplate template = new AdoTemplate();
					template.Connection = ConnectionSingleton.Instance.getConnection("KARKAS_ORNEK");
					return Ornek(
						@SAYI1
						,template
						);
					}
				}
			}
