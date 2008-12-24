
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Karkas.Ornek.TypeLibrary;
using Karkas.Ornek.TypeLibrary.Ornekler;
using Karkas.Ornek.Dal.Ornekler;
using Karkas.Core.DataUtil;


namespace Karkas.Ornek.Bs.Ornekler
{
    public partial class DenemeGuidIdentityBs
    {

        public void OrnekTransactionDataTableDondur()
        {
            DenemeGuidIdentity dgi = new DenemeGuidIdentity();
            dgi.DenemeKey = Guid.NewGuid();
            dgi.DenemeKolon = "Erkan";

            Aciklama aciklama = new Aciklama();
            aciklama.AciklamaKey = Guid.NewGuid();

            try
            {
                this.BeginTransaction();

                AciklamaDal aciklamaDal = this.GetDalInstance<AciklamaDal, Aciklama>();

                int no = (int )dal.Ekle(dgi);
                DataTable dt = dal.SatirGetir(no);
                aciklama.AciklamaProperty = dt.Rows[0]["DenemeKolon"].ToString();
                aciklamaDal.Ekle(aciklama);
                this.CommitTransaction();

            }
            finally
            {
                this.ClearTransactionInformation();
            }
        }

        public void OrnekTransactionTemplate()
        {
            DenemeGuidIdentity dgi = new DenemeGuidIdentity();
            dgi.DenemeKey = Guid.NewGuid();
            dgi.DenemeKolon = "Erkan";

            Aciklama aciklama = new Aciklama();
            aciklama.AciklamaKey = Guid.NewGuid();

            try
            {
                this.BeginTransaction();

                AciklamaDal aciklamaDal = this.GetDalInstance<AciklamaDal, Aciklama>();

                long no = dal.Ekle(dgi);
                long denemeNo = dal.DenemeNoBul(dgi.DenemeKey);
                aciklama.AciklamaProperty = "" + denemeNo + " " + dgi.DenemeKeyAsString;
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
