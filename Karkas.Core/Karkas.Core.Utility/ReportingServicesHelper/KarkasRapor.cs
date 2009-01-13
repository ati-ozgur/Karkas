using System;
using System.Web.UI.WebControls;

using System.Collections;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Collections.Generic;


using Karkas.Core.Utility.ReportingServicesHelper.Generated;
using System.Configuration;
using System.Text.RegularExpressions;

namespace Karkas.Core.Utility.ReportingServicesHelper
{
    public delegate void BeforeRaporAl(KarkasRapor rapor);

    public partial class KarkasRapor
    {
        //rapor almadan (RaporAl() fonksiyonundan) once çaðýrýlacak event
        public event BeforeRaporAl OnBeforeRaporAl;

        ReportingService rs = new ReportingService();

        public ReportingService getInnerReportingService()
        {
            rs.Credentials = Credentials;
            return rs;
        }

        public KarkasRapor()
        {
            SetDefaults();
        }

        public KarkasRapor(string pRaporAd)
            : this()
        {
            RaporAd = pRaporAd;
        }

        /// <summary>
        /// OnBeforeRaporAl eventini tetikle
        /// </summary>
        private void fireOnBeforeRaporAl()
        {
            if (OnBeforeRaporAl != null)
                OnBeforeRaporAl(this);
        }

        private void SetDefaults()
        {
            // Rapor Sunucu Url gerekli eger yoksa exception at
            if (ConfigurationManager.AppSettings[RAPOR_SUNUCU_URL] == null)
            {
                throw new SettingsPropertyNotFoundException(RAPOR_SUNUCU_URL + " AppSettings icinde bulunamadi");
            }
            raporSunucuUrl = ConfigurationManager.AppSettings[RAPOR_SUNUCU_URL];


            // Default Credentials vermiyebilir. O zaman true kabul ederim.
            if (ConfigurationManager.AppSettings["UseDefaultCredentials"] != null)
            {
                useDefaultCredentials = Convert.ToBoolean(ConfigurationManager.AppSettings["UseDefaultCredentials"]);
            }
            else
            {
                useDefaultCredentials = true;
            }
            // Eger security Model yoksa NTLM
            if (ConfigurationManager.AppSettings[RAPOR_WEB_SERVICE_SECURITY_MODEL] != null)
            {
                webServiceSecurityModel = ConfigurationManager.AppSettings[RAPOR_WEB_SERVICE_SECURITY_MODEL].ToString();
            }
            else
            {
                webServiceSecurityModel = WebServiceSecurityModelConstants.NTLM;
            }

            if (
                (ConfigurationManager.AppSettings[RAPOR_USER] != null)
                &&
                (ConfigurationManager.AppSettings[RAPOR_PASSWORD] != null)
                &&
                (!useDefaultCredentials)
                )
            {
                raporUser = ConfigurationManager.AppSettings[RAPOR_USER];
                raporPassword = ConfigurationManager.AppSettings["RaporPassword"].ToString();
                raporCredentialsDomain = ConfigurationManager.AppSettings[RAPOR_CREDENTIALS_DOMAIN].ToString();
            }
        }


        private ICredentials credentials;
        private bool useDefaultCredentials;

        public bool UseDefaultCredentials
        {
            get
            {
                return useDefaultCredentials;
            }
            set
            {
                useDefaultCredentials = value;
            }

        }




        public ICredentials Credentials
        {
            get
            {
                if (credentials == null)
                {
                    if (useDefaultCredentials)
                    {
                        credentials = CredentialCache.DefaultCredentials;
                    }
                    else
                    {
                        CredentialCache cache = new CredentialCache();
                        cache.Add(new Uri(RaporSunucuUrl), WebServiceSecurityModel, new NetworkCredential(RaporUser, RaporPassword, RaporCredentialsDomain));
                        credentials = cache;
                    }
                }
                return credentials;
            }
            set { credentials = value; }
        }

        private string raporUser;

        public string RaporUser
        {
            get
            {
                return raporUser;
            }
            set
            {
                raporUser = value;
            }
        }
        private string raporPassword;

        public string RaporPassword
        {
            get
            {
                if (String.IsNullOrEmpty(raporPassword))
                {

                }
                return raporPassword;
            }
            set
            {
                raporPassword = value;
            }
        }
        private string raporCredentialsDomain;

        public string RaporCredentialsDomain
        {
            get
            {
                if (String.IsNullOrEmpty(raporCredentialsDomain))
                {
                }
                return raporCredentialsDomain;
            }
            set
            {
                raporCredentialsDomain = value;
            }
        }
        private string raporSunucuUrl;



        /// <summary>
        /// Raporlarýn calýstýgý sunucunun adresi
        /// </summary>
        public string RaporSunucuUrl
        {
            get
            {
                if (String.IsNullOrEmpty(raporSunucuUrl))
                {
                    raporSunucuUrl = System.Configuration.ConfigurationManager.AppSettings["RaporSunucuURL"].ToString();
                }
                return raporSunucuUrl;
            }
            set
            {
                raporSunucuUrl = value;
            }
        }


        string raporAd;
        string raporDosyaAd;
        /// <summary>
        /// Raporun Sunucu Uzerindeki Adi, buranýn dizin ile beraber verilmesi
        /// gerekir. MODUL_ADI/RAPOR_ADI , .rdl verilmez
        /// Report Manager uzerinde gorulen adý veriniz.
        /// </summary>
        public string RaporAd
        {
            get
            {
                return raporAd;
            }
            set
            {
                raporAd = value;
            }
        }
        private RaporFormats raporFormat;
        /// <summary>
        /// Raporun cikti formati, ornek pdf,xml
        /// </summary>
        public RaporFormats RaporFormat
        {
            get
            {
                return raporFormat;
            }
            set
            {
                raporFormat = value;
            }
        }
        /// <summary>
        /// Raporun save as ile kayýt edilirken gosterildigi ad.
        /// </summary>
        public string RaporDosyaAd
        {
            get
            {
                return raporDosyaAd;
            }
            set
            {
                raporDosyaAd = value;
            }
        }

        private List<KarkasRaporParametre> ParametreListesi = new List<KarkasRaporParametre>();

        public void ParametreEkle(string pAdi, string pDegeri)
        {
            ParametreListesi.Add(new KarkasRaporParametre(pAdi, pDegeri));
        }
        public void ParametreEkle(string pAdi, DateTime pDegeri)
        {
            ParametreListesi.Add(new KarkasRaporParametre(pAdi, pDegeri));
        }
        public void ParametreEkle(string pAdi, float pDegeri)
        {
            ParametreListesi.Add(new KarkasRaporParametre(pAdi, pDegeri));
        }
        public void ParametreEkle(string pAdi, int pDegeri)
        {
            ParametreListesi.Add(new KarkasRaporParametre(pAdi, pDegeri));
        }
        public void ParametreEkle(string pAdi, bool pDegeri)
        {
            ParametreListesi.Add(new KarkasRaporParametre(pAdi, pDegeri));
        }



        /// <summary>
        /// raporun var olup olmadigini kontrol eder. 
        /// </summary>
        /// <param name="pRaporAdi">butceMuhasebe (.rdl yok)</param>
        /// <param name="pRaporYolu">ornek : /AritOzelIdare (son / yok)</param>
        /// <returns></returns>
        public bool RaporVarMi(string pRaporAdi, string pRaporYolu)
        {
            rs.Credentials = Credentials;
            CatalogItem[] items = null;
            SearchCondition condition = new SearchCondition();
            condition.Condition = ConditionEnum.Equals;
            condition.ConditionSpecified = true;
            condition.Name = "Name";
            condition.Value = pRaporAdi;

            SearchCondition[] conditions = new SearchCondition[1];
            conditions[0] = condition;

            items = rs.FindItems(pRaporYolu, BooleanOperatorEnum.And, conditions);
            if (items == null || items.Length == 0)
                return false;
            else
                return true;
        }

        /// <summary>
        /// varolan bir datasource itemine referans almak icin kullanilir. 
        /// Reporting Serviceden direkt datasource'u arayip bulamadigimiz icin yeni bir datasource objesi yaratilip ,varolan datasource objesinin referansi aktarilir.
        /// </summary>
        /// <param name="pVarOlaDataSourceAdi">shared datasourceun ismi (reporting service arayuzunde gorunen adi)</param>
        /// <param name="pVarOlanDataSourceYolu">shared datasourceun yolu (sonunda / karakteri olmaz) </param>
        /// <param name="pDondurulecekDataSourceAdi">Bu isim Reporting Service arayuzunde gorunen Datasource adi olmayabilir. Rapor Projesindeki Shared DataSource adidir.</param>
        /// <returns></returns>
        public DataSource VarOlanDataSourceReferansiniGetir(string pVarOlaDataSourceAdi, string pVarOlanDataSourceYolu, string pDondurulecekDataSourceAdi)
        {
            DataSourceReference reference = new DataSourceReference();
            reference.Reference = pVarOlanDataSourceYolu.TrimEnd('/') + "/" + pVarOlaDataSourceAdi;
            DataSource ds = new DataSource();
            ds.Item = (DataSourceDefinitionOrReference)reference;
            ds.Name = pDondurulecekDataSourceAdi;
            return ds;
        }

        /// <summary>
        /// RaporAd propertisi ile belirtilen raporu yeniRaporYolu ve yeniRaporAdi ile reporting services'e kopyalar
        /// ve datasource propertisini  pVarOlaDataSourceAdi ve pVarOlanDataSourceYolu parametrelerle belirtilen datasource olarak ayarlar.
        /// Datasource ayarlamasi icin VarOlanDataSourceReferansiniGetir metodunu kullanir.
        /// </summary>
        /// <param name="yeniRaporAdi">kopya raporun adi</param>
        /// <param name="yeniRaporYolu">kopya raporun yolu</param>
        /// <param name="pVarOlaDataSourceAdi">bknz : VarOlanDataSourceReferansiniGetir</param>
        /// <param name="pVarOlanDataSourceYolu">bknz : VarOlanDataSourceReferansiniGetir</param>
        /// <param name="pYeniDataSourceAdi">bknz : VarOlanDataSourceReferansiniGetir (pDondurulecekDataSourceAdi)</param>
        public void RaporKopyalaVeDataSourceunuAta(string yeniRaporAdi, string yeniRaporYolu, string pVarOlaDataSourceAdi, string pVarOlanDataSourceYolu, string pYeniDataSourceAdi)
        {
            rs.CreateReport(yeniRaporAdi, yeniRaporYolu, false, rs.GetReportDefinition(RaporAd), null);
            rs.SetReportDataSources(String.Format("{0}/{1}", yeniRaporYolu, yeniRaporAdi),
                new DataSource[] { VarOlanDataSourceReferansiniGetir(pVarOlaDataSourceAdi, pVarOlanDataSourceYolu, pYeniDataSourceAdi) });
        }
        /// <summary>
        /// Reporting Service'e Web Service kullanarak, rapor sonucunu byte[] olarak dondurur. bir console
        /// veya windows uygulamasinda, bu sonucu dosya olarak kullanabilirsiniz.
        /// </summary>
        /// <returns></returns>
        public byte[] RaporAl()
        {
            rs.Credentials = Credentials;

            //OnBeforeRaporAl eventini fire et
            fireOnBeforeRaporAl();

            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            ParameterValue[] paramatersUsed = null;
            ParameterValue[] parameters = null;
            DataSourceCredentials[] dsCredentials = null;
            byte[] buf = null;



            parameters = new ParameterValue[ParametreListesi.Count];
            for (int ix = 0; ix < ParametreListesi.Count; ix++)
            {

                KarkasRaporParametre oKarkasRaporParametre = new KarkasRaporParametre();


                oKarkasRaporParametre = (KarkasRaporParametre)ParametreListesi[ix];

                parameters[ix] = new ParameterValue();
                parameters[ix].Name = oKarkasRaporParametre.Adi;
                parameters[ix].Value = oKarkasRaporParametre.DegeriniAl();
            }
            switch (RaporFormat)
            {
                case RaporFormats.PDF:
                    buf = rs.Render(raporAd, RaporFormatAsString.PDF, null, "", parameters, dsCredentials, "", out encoding, out mimeType, out paramatersUsed, out warnings, out streamids);
                    break;
                case RaporFormats.EXCEL:
                    buf = rs.Render(raporAd, RaporFormatAsString.EXCEL, null, "", parameters, dsCredentials, "", out encoding, out mimeType, out paramatersUsed, out warnings, out streamids);
                    break;
                case RaporFormats.IMAGE:
                    buf = rs.Render(raporAd, RaporFormatAsString.IMAGE, null, "", parameters, dsCredentials, "", out encoding, out mimeType, out paramatersUsed, out warnings, out streamids);
                    break;
                case RaporFormats.XML:

                    buf = rs.Render(raporAd, RaporFormatAsString.XML, null, "", parameters, dsCredentials, "", out encoding, out mimeType, out paramatersUsed, out warnings, out streamids);
                    break;
            }
            return buf;

        }

        /// <summary>
        /// Rapor ac, raporunuzun tarayici icinde acilmasi icindir. Arka tarafta RaporAl'i kullanir. 
        /// </summary>
        public void RaporAc()
        {
            switch (TarayiciDavranisi)
            {
                case TarayiciDavranisiEnum.DosyaIndir:
                    RaporAc(FileDownloadHelper.httpHeaderFileDownload);
                    break;
                case TarayiciDavranisiEnum.TarayiciIcindeGoster:
                    RaporAc(FileDownloadHelper.httpHeaderTarayiciIcinde);
                    break;
            }
            
        }

        private void RaporAc(string[] yapisi)
        {
            FileDownloadHelper helper = new FileDownloadHelper();
            helper.FileFormat = (FileFormats)RaporFormat;
            helper.FileName = raporDosyaAd;
            helper.TarayiciDavranisi = TarayiciDavranisi;
            // rs.Timeout
            byte[] buf = RaporAl();

            helper.FileDownload(yapisi, buf);

        }

        private TarayiciDavranisiEnum tarayiciDavranisi = TarayiciDavranisiEnum.DosyaIndir;
        public TarayiciDavranisiEnum TarayiciDavranisi
        {
            get
            {
                return tarayiciDavranisi;
            }
            set
            {
                tarayiciDavranisi = value;
            }
        }







        public RaporFormats RaporFormatiniAl(string pRaporFormatAdi)
        {
            RaporFormats rfs = RaporFormats.PDF;
            switch (pRaporFormatAdi)
            {
                case RaporFormatAsString.PDF:
                    rfs = RaporFormats.PDF;
                    break;
                case RaporFormatAsString.EXCEL:
                    rfs = RaporFormats.EXCEL;
                    break;
                case RaporFormatAsString.IMAGE:
                    rfs = RaporFormats.IMAGE;
                    break;
                case RaporFormatAsString.TIFF:
                    rfs = RaporFormats.IMAGE;
                    break;
                case RaporFormatAsString.XML:
                    rfs = RaporFormats.XML;
                    break;

            }
            return rfs;
        }
        public static void DDLRaporFormatDoldur(DropDownList ddl)
        {
            ddl.Items.Clear();
            ddl.Items.Add(new ListItem(RaporFormatAsString.PDF, RaporFormatAsString.PDF));
            ddl.Items.Add(new ListItem(RaporFormatAsString.EXCEL, RaporFormatAsString.EXCEL));
            ddl.Items.Add(new ListItem(RaporFormatAsString.TIFF, RaporFormatAsString.IMAGE));
            ddl.Items.Add(new ListItem(RaporFormatAsString.XML, RaporFormatAsString.XML));
        }




        public const string RAPOR_SUNUCU_URL = "RaporSunucuURL";
        public const string RAPOR_WEB_SERVICE_SECURITY_MODEL = "RaporWebServiceSecurityModel";
        public const string RAPOR_USER = "RaporUser";
        public const string RAPOR_PASSWORD = "RaporPassword";
        public const string RAPOR_CREDENTIALS_DOMAIN = "RaporCredentialsDomain";




        private string webServiceSecurityModel;

        public string WebServiceSecurityModel
        {
            get
            {
                return webServiceSecurityModel;
            }
            set
            {
                webServiceSecurityModel = value;
            }
        }


    }





}