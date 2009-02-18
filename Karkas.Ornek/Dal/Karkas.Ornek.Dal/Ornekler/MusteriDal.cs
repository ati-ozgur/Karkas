using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Karkas.Core.DataUtil;
using Karkas.Ornek.TypeLibrary;
using Karkas.Ornek.TypeLibrary.Ornekler;
using Karkas.Core.DataUtil.SorguYardimcisiSiniflari;
using System.Runtime.Remoting;
using System.Reflection;


namespace Karkas.Ornek.Dal.Ornekler
{
	public partial class MusteriDal
	{
        public List<Musteri> SorgulaTamAdiIle(string pTamAdi)
        {
            List<Musteri> liste = new List<Musteri>();
            string filtre = " TamAdi LIKE @TamAdi + '%'";
            ParameterBuilder builder = new ParameterBuilder();
            builder.parameterEkle("@TamAdi", SqlDbType.VarChar, pTamAdi);
            SorguCalistir(liste, filtre, builder.GetParameterArray());
            return liste;
        }

        public List<Musteri> SorgulaAdiVeSoyadiIle(string pAdi,string pSoyadi)
        {
            SorguYardimcisi sy = new SorguYardimcisi();
            sy.WhereKriterineTercihliEkle(Musteri.PropertyIsimleri.Adi, WhereOperatorEnum.Like);
            sy.WhereKriterineTercihliEkle(Musteri.PropertyIsimleri.Soyadi, WhereOperatorEnum.Like);
            List<Musteri> liste = new List<Musteri>();
			string filtre = sy.KriterSonucunuWhereOlmadanGetir();
			ParameterBuilder builder = new ParameterBuilder();
			builder.parameterEkle("@Adi", SqlDbType.VarChar, pAdi);
			builder.parameterEkle("@Soyadi", SqlDbType.VarChar, pSoyadi,50);
			SorguCalistir(liste, filtre,builder.GetParameterArray());
			return liste;
        }

        public DataTable SorgulaHepsiniGetirDataTable()
        {
            string sql = this.SelectString;
            return this.Template.DataTableOlustur(sql);
        }

        public List<T1> SorgulaMusteriKeyIleDetayTabloGetir<T1>(Guid pMusteriKey) where T1 :new()
        {
            T1 t = new T1();
            
            string typeLibrary = t.ToString();
            string dal = typeLibrary.Replace("TypeLibrary", "Dal") + "Dal" ;
            Type type = Type.GetType(dal);
            MethodInfo methodInfo = type.GetMethod("SorgulaForeingKeyIle");
            string assemblyName = dal.Remove(dal.IndexOf("Dal") + 3);
            ObjectHandle oh  = Activator.CreateInstance(assemblyName, dal);
            
            object sonuc = methodInfo.Invoke(oh.Unwrap(),new object[]{PrimaryKey,pMusteriKey});
            return (List<T1>) sonuc;
        }


        public string PrimaryKey
        {
            get
            {
                return "MusteriKey";
            }
        }
    }
}

