using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.IO;
using System.Text.RegularExpressions;

namespace Karkas.Core.Utility
{
    /// <summary>
    ///  Email gondermek icin gerekli yardimci sinif. Bu sinifin duzgun calismasi icin asagidaki
    /// config'in yapilmasi gereklidir.
    ///  
    ///  Bu sınıf eğer Web Sunucusu (Istemci) tarafında çalışacaksa Web kodunun olduğu yerde
    /// web.config dosyasına aşağıdaki
    /// satırları eklemek gerekiyor.
    ///  Bu sınıf eğer Uygulama Sunucusu tarafında çalışacaksa onun web.config veya app.config 
    /// dosyasına aşağıdaki
    /// satırları eklemek gerekiyor.
    ///        <configuration>
    ///  <system.net>
    ///    <mailSettings>
    ///      <smtp>
    ///        <network 
    ///             host="relayServerHostname" 
    ///             port="portNumber"
    ///             userName="username"
    ///             password="password" />
    ///      </smtp>
    ///    </mailSettings>
    ///  </system.net>
    ///  <system.web>
    ///    ...
    ///  </system.web>
    ///</configuration>
    /// </summary>
    public class EPostaYardimcisi
    {
        //TODO -- Exception Handling'i ekle ne yapilacagina karar verilsin.
        private string kimden;
        private string kime = null;
        private string[] gonderileceklerinListesi = null;
        private string konu;
        private string ePostaYazisi;


        /// <param name="pKimden"></param>
        /// <param name="pKime"></param>
        /// <param name="pKonu"></param>
        /// <param name="pEPostaYazisi"></param>
        public EPostaYardimcisi(string pKimden,string pKime,string pKonu,string pEPostaYazisi)
        {
            this.kimden = pKimden;
            this.kime = pKime;
            this.konu = pKonu;
            this.ePostaYazisi = pEPostaYazisi;
        }

        public EPostaYardimcisi(string pKimden, string[] pGonderileceklerinListesi, string pKonu, string pEPostaYazisi)
        {
            this.kimden = pKimden;
            this.gonderileceklerinListesi = pGonderileceklerinListesi;
            this.konu = pKonu;
            this.ePostaYazisi = pEPostaYazisi;
        }

        
        public void NormalEPostaGonder()
        {
            if (gonderileceklerinListesi == null)
            {
                tekKisiyeEPostaGonder();
            }
            else
            {
                foreach (string kime in gonderileceklerinListesi)
                {
                    tekKisiyeEPostaGonder(kime);
                }
            }
        }
        private List<Attachment> ekDosyaListesi = null;

        public void ekDosyaEkle(string pDosyaIsmi, byte[] pDosyaIcerigi)
        {
            MemoryStream stream = new MemoryStream(pDosyaIcerigi);
            ekDosyaListesi.Add(new Attachment(stream, pDosyaIsmi));
        }

        private void tekKisiyeEPostaGonder()
        {
            try
            {
                tekKisiyeEPostaGonder(kime);

            }
            catch (SmtpException)
            {
                
                throw;
            }
        }
        private void tekKisiyeEPostaGonder(string pKime)
        {
            MailMessage msg = new MailMessage(kimden, pKime, konu, ePostaYazisi);
            if (ekDosyaListesi != null)
            {
                foreach (Attachment ekDosya in ekDosyaListesi)
                {
                    msg.Attachments.Add(ekDosya);
                }
            }
            SmtpClient smtp = new SmtpClient();
            smtp.Send(msg);
        }

        public bool GecerliMail(string eMail)
        {
            return Regex.IsMatch(eMail, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
        
        public void HtmlEPostaGonder()
        {
            MailMessage msg = new MailMessage(kimden, kime, konu, ePostaYazisi);
            msg.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Send(msg);
        }

    }
}

