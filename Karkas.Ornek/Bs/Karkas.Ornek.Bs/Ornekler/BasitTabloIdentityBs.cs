
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
public partial class BasitTabloIdentityBs
{
    public void TransactionBasarili()
    {
        BasitTabloIdentity bti = new BasitTabloIdentity();
        bti.Adi = "atilla";
        bti.Soyadi = "ozgur";

        Aciklama acik = new Aciklama();
        acik.AciklamaKey = Guid.NewGuid();
        acik.AciklamaProperty = bti.Adi + " " + bti.Soyadi;

        try
        {
            this.BeginTransaction();
            AciklamaDal aciklamaDal = this.GetDalInstance<AciklamaDal, Aciklama>();
            dal.Ekle(bti);
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
