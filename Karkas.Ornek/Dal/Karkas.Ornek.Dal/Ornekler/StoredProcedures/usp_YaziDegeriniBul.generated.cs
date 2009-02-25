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
		public static int YaziDegeriniBul
		(

			int? @SAYI
			,out string @SAYI_YAZI
			, AdoTemplate template
			)
			{
				ParameterBuilder builder = new ParameterBuilder();
				 builder.parameterEkleReturnValue( "@RETURN_VALUE",SqlDbType.Int);
				 builder.parameterEkle( "@SAYI",SqlDbType.Int,@SAYI);
				 builder.parameterEkleOutput( "@SAYI_YAZI",SqlDbType.VarChar,255);
				SqlCommand cmd = new SqlCommand();
				cmd.CommandText = "ORNEKLER.YAZI_DEGERINI_BUL";
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddRange(builder.GetParameterArray());
				template.SorguHariciKomutCalistir(cmd);
				@SAYI_YAZI = (string)cmd.Parameters["@SAYI_YAZI"].Value;
				return (int) cmd.Parameters["@RETURN_VALUE"].Value;
			}
			public static int YaziDegeriniBul
			(

				int? @SAYI
				,out string @SAYI_YAZI
				)
				{
					AdoTemplate template = new AdoTemplate();
					template.Connection = new SqlConnection(ConnectionSingleton.Instance.getConnectionString("KARKAS_ORNEK"));
					return YaziDegeriniBul(
						@SAYI
						,out @SAYI_YAZI
						,template
						);
					}
				}
			}
