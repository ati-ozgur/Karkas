
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Karkas.Ornek.TypeLibrary;
using Karkas.Ornek.TypeLibrary.Ornekler;
using Karkas.Ornek.Dal.Ornekler;


namespace Karkas.Ornek.Bs.Ornekler
{
    public partial class BasitTabloBs
    {
        public void TemplateTransactionOrnek()
        {
            BasitTablo bt = new BasitTablo();
            bt.Adi = "Deneme Ad";
            bt.Soyadi = "Deneme Soyad";
            bt.BasitTabloKey = Guid.NewGuid();

            Aciklama aciklama =new Aciklama();
            aciklama.AciklamaKey = Guid.NewGuid();
            aciklama.AciklamaProperty = bt.AdiAsString + " " + bt.SoyadiAsString;
            dal.Ekle(bt);
            try
            {
                this.BeginTransaction();
                AciklamaDal aciklamaDal = this.GetDalInstance<AciklamaDal, Aciklama>();
                dal.AdSoyadiBuyukHarfeCevir(bt.BasitTabloKey);
                aciklamaDal.Ekle(aciklama);
                this.CommitTransaction();
            }
            finally
            {
                this.ClearTransactionInformation();
            }
        }
    }
}
