
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
                dal.Ekle(m);
                aciklamaDal.Ekle(acik);
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
            acik.AciklamaProperty = m.Adi + " " +  m.Soyadi;

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
    }
}
