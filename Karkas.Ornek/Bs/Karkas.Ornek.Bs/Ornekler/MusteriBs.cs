
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Karkas.Ornek.TypeLibrary;
using Karkas.Ornek.TypeLibrary.Ornekler;
using Karkas.Ornek.Dal.Ornekler;
using Karkas.Core.DataUtil;
using Karkas.Core.TypeLibrary;


namespace Karkas.Ornek.Bs.Ornekler
{
    public partial class MusteriBs
    {



        public void TransactionRollBackBekliyoruz()
        {
            Musteri m = new Musteri();
            m.Adi = "atilla";
            m.Soyadi = "ozgur";
            m.MusteriKey = Guid.NewGuid();

            Aciklama acik = new Aciklama();
            acik.AciklamaKey = Guid.NewGuid();

            try
            {
                this.BeginTransaction();
                AciklamaDal aciklamaDal = this.GetDalInstance<AciklamaDal, Aciklama>();
                BasitTabloDal btDal = this.GetDalInstance<BasitTabloDal, BasitTablo>();
                dal.Ekle(m);
                aciklamaDal.Ekle(acik);
                btDal.Guncelle(null);
                this.CommitTransaction();

            }
            finally
            {
                this.ClearTransactionInformation();
            }

        }

        public void TransactionBasarili()
        {
            Musteri m = new Musteri();
            m.Adi = "atilla";
            m.Soyadi = "ozgur";
            m.MusteriKey = Guid.NewGuid();

            Aciklama acik = new Aciklama();
            acik.AciklamaKey = Guid.NewGuid();
            acik.AciklamaProperty = m.Adi + " " + m.Soyadi;

            try
            {
                this.BeginTransaction();
                AciklamaDal aciklamaDal = this.GetDalInstance<AciklamaDal, Aciklama>();
                dal.Ekle(m);
                aciklamaDal.Ekle(acik);
                this.CommitTransaction();
            }
            finally
            {
                this.ClearTransactionInformation();
            }

        }

        public DataTable SorgulaHepsiniGetirDataTable()
        {
            return dal.SorgulaHepsiniGetirDataTable();
        }

        public void TransactionRollBackBekliyoruzAdoTemplateConnectionYonetimiIle()
        {
            AdoTemplate adotemplate = new AdoTemplate();
            adotemplate.Connection = new SqlConnection(ConnectionSingleton.Instance.getConnectionString("KARKAS_ORNEK"));

            Musteri m = new Musteri();
            m.Adi = "Erkan";
            m.Soyadi = "UYGUN";
            m.MusteriKey = Guid.NewGuid();

            Aciklama acik = new Aciklama();
            acik.AciklamaKey = Guid.NewGuid();
            // bilerek aciklama yazmiyoruzki transaction veritabaninda rollback etsin.
            //acik.AciklamaPropertyAsString = "Aciklama";

            try
            {
                adotemplate.OtomatikConnectionYonetimi = false;
                adotemplate.Connection.Open();
                adotemplate.CurrentTransaction = adotemplate.Connection.BeginTransaction();

                AciklamaDal aciklamaDal = this.GetDalInstance<AciklamaDal, Aciklama>();
                dal.Connection = adotemplate.Connection;
                dal.OtomatikConnectionYonetimi = adotemplate.OtomatikConnectionYonetimi;
                dal.CurrentTransaction = adotemplate.CurrentTransaction;

                aciklamaDal.Connection = adotemplate.Connection;
                aciklamaDal.OtomatikConnectionYonetimi = adotemplate.OtomatikConnectionYonetimi;
                aciklamaDal.CurrentTransaction = adotemplate.CurrentTransaction;

                dal.Ekle(m);
                aciklamaDal.Ekle(acik);

                adotemplate.CurrentTransaction.Commit();
            }
            finally
            {
                //adotemplate.Connection.Close();
                this.ClearTransactionInformation();
            }
        }

        public void TransactionBasariliAdoTemplateConnectionYonetimiIle()
        {
            AdoTemplate adotemplate = new AdoTemplate();
            adotemplate.Connection = new SqlConnection(ConnectionSingleton.Instance.getConnectionString("KARKAS_ORNEK"));

            Musteri m = new Musteri();
            m.Adi = "Erkan";
            m.Soyadi = "UYGUN";
            m.MusteriKey = Guid.NewGuid();

            Aciklama acik = new Aciklama();
            acik.AciklamaKey = Guid.NewGuid();
            acik.AciklamaProperty = m.Adi + " " + m.Soyadi;

            try
            {
                adotemplate.OtomatikConnectionYonetimi = false;
                adotemplate.Connection.Open();
                adotemplate.CurrentTransaction = adotemplate.Connection.BeginTransaction();

                AciklamaDal aciklamaDal = this.GetDalInstance<AciklamaDal, Aciklama>();
                dal.Connection = adotemplate.Connection;
                dal.OtomatikConnectionYonetimi = adotemplate.OtomatikConnectionYonetimi;
                dal.CurrentTransaction = adotemplate.CurrentTransaction;

                aciklamaDal.Connection = adotemplate.Connection;
                aciklamaDal.OtomatikConnectionYonetimi = adotemplate.OtomatikConnectionYonetimi;
                aciklamaDal.CurrentTransaction = adotemplate.CurrentTransaction;

                dal.Ekle(m);
                aciklamaDal.Ekle(acik);
                adotemplate.CurrentTransaction.Commit();
            }
            finally
            {
                //adotemplate.Connection.Close();
                this.ClearTransactionInformation();
            }
        }

    }
}
