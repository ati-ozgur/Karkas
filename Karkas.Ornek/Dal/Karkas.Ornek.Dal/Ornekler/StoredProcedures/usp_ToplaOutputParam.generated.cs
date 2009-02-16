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
		public static int ToplaOutputParam
		(

			int @SAYI1
			,int @SAYI2
			,out int @SONUC
			, AdoTemplate template
			)
			{
				ParameterBuilder builder = new ParameterBuilder();
				 builder.parameterEkleReturnValue( "@RETURN_VALUE",SqlDbType.Int);
				 builder.parameterEkle( "@SAYI1",SqlDbType.Int,@SAYI1);
				 builder.parameterEkle( "@SAYI2",SqlDbType.Int,@SAYI2);
				 builder.parameterEkleOutput( "@SONUC",SqlDbType.Int);
				SqlCommand cmd = new SqlCommand();
				cmd.CommandText = "ORNEKLER.TOPLA_OUTPUT_PARAM";
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddRange(builder.GetParameterArray());
				template.SorguHariciKomutCalistir(cmd);
				@SONUC = (int)cmd.Parameters["@SONUC"].Value;
				return (int) cmd.Parameters["@RETURN_VALUE"].Value;
			}
			public static int ToplaOutputParam
			(

				int @SAYI1
				,int @SAYI2
				,out int @SONUC
				)
				{
					AdoTemplate template = new AdoTemplate();
					template.Connection = new SqlConnection(ConnectionSingleton.Instance.getConnectionString("KARKAS_ORNEK"));
					return ToplaOutputParam(
						@SAYI1
						,@SAYI2
						,out @SONUC
						,template
						);
					}
				}
			}

