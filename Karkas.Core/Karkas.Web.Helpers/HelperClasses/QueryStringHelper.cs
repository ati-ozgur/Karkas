using System;
using System.Collections.Generic;
using System.Text;

namespace Karkas.Web.Helpers.HelperClasses
{
    public partial class KarkasWebHelper
    {
        public class QueryStringHelper
        {
            private enum UrldenIstenenPathTipi
            {
                SadeceSayfaAdi,
                SadeceUstKlasorAdi,
                UstKlasorVeSayfaAdi
            }
            public string GetirUrldenSayfaAdi(string pUrl)
            {
                return GetirUrldenSayfaAdi(pUrl, UrldenIstenenPathTipi.SadeceSayfaAdi);
            }
            public string GetirUrldenUstKlasorAdi(string pUrl)
            {
                return GetirUrldenSayfaAdi(pUrl, UrldenIstenenPathTipi.SadeceUstKlasorAdi);
            }
            public string GetirUrldenUstKlasorVeSayfaAdi(string pUrl)
            {
                return GetirUrldenSayfaAdi(pUrl, UrldenIstenenPathTipi.UstKlasorVeSayfaAdi);
            }

            private string GetirUrldenSayfaAdi(string pUrl, UrldenIstenenPathTipi pTipi)
            {
                pUrl = pUrl.Replace("%3a", ":");
                pUrl = pUrl.Replace("%2f", "/");

                int slashSayfa = pUrl.LastIndexOf("/");
                string urlKlasor = pUrl.Substring(0, slashSayfa);
                string sayfaAdi = "";
                int slashKlasor = 0;
                string klasorAdi = "";

                switch (pTipi)
                {
                    case UrldenIstenenPathTipi.SadeceSayfaAdi:
                        sayfaAdi = pUrl.Substring(slashSayfa + 1);
                        return sayfaAdi;

                    case UrldenIstenenPathTipi.SadeceUstKlasorAdi:
                        slashKlasor = urlKlasor.LastIndexOf("/");
                        klasorAdi = urlKlasor.Substring(slashKlasor + 1);
                        return klasorAdi;

                    case UrldenIstenenPathTipi.UstKlasorVeSayfaAdi:
                        slashKlasor = urlKlasor.LastIndexOf("/");
                        klasorAdi = pUrl.Substring(slashKlasor + 1);
                        return klasorAdi;
                    default:
                        sayfaAdi = pUrl.Substring(slashSayfa + 1);
                        return sayfaAdi;
                }
            }


        }
    }
}
