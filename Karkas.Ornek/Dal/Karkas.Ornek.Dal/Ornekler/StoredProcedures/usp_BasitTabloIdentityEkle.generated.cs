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
		public static int BasitTabloIdentityEkle
		(

			string @Adi
			,string @Soyadi
			, AdoTemplate template
			)
			{
				ParameterBuilder builder = new ParameterBuilder();
				
				 builder.parameterEkle( "@Adi",SqlDbType.VarChar,@Adi);
				 builder.parameterEkle( "@Soyadi",SqlDbType.VarChar,@Soyadi);
				SqlCommand cmd = new SqlCommand();
				cmd.CommandText = "ORNEKLER.BASIT_TABLO_IDENTITY_EKLE";
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddRange(builder.GetParameterArray());
				int tmp = Convert.ToInt32(template.TekDegerGetir(cmd));;
				return tmp;
			}
			public static int BasitTabloIdentityEkle
			(

				string @Adi
				,string @Soyadi
				)
				{
					AdoTemplate template = new AdoTemplate();
					template.Connection = new SqlConnection(ConnectionSingleton.Instance.getConnectionString("KARKAS_ORNEK"));
					return BasitTabloIdentityEkle(
						@Adi
						,@Soyadi
						,template
						);
					}
				}
			}

