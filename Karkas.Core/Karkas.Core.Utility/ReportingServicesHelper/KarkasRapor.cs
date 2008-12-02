using System;
using System.Web.UI.WebControls;

using System.Collections;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Collections.Generic;


using Karkas.Core.Utility.ReportingServicesHelper.Generated;
using System.Configuration;

namespace Karkas.Core.Utility.ReportingServicesHelper
{
    public class KarkasRapor
    {
        // TODO NTLM ILE

        public class WebServiceSecurityModelConstants
        {
            public const string BASIC = "Basic";
            public const string DIGEST = "Digest";
            public const string NTLM = "NTLM";
            public const string NEGOTIATE = "Negotiate";
        }

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

            if  (
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

        private List<Parametre> ParametreListesi = new List<Parametre>();

        public void ParametreEkle(string pAdi, string pDegeri)
        {
            ParametreListesi.Add(new Parametre(pAdi, pDegeri));
        }
        public void ParametreEkle(string pAdi, DateTime pDegeri)
        {
            ParametreListesi.Add(new Parametre(pAdi, pDegeri));
        }
        public void ParametreEkle(string pAdi, float pDegeri)
        {
            ParametreListesi.Add(new Parametre(pAdi, pDegeri));
        }
        public void ParametreEkle(string pAdi, int pDegeri)
        {
            ParametreListesi.Add(new Parametre(pAdi, pDegeri));
        }
        public void ParametreEkle(string pAdi, bool pDegeri)
        {
            ParametreListesi.Add(new Parametre(pAdi, pDegeri));
        }





        public byte[] RaporAl()
        {
            rs.Credentials = Credentials;

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

                Parametre oParametre = new Parametre();


                oParametre = (Parametre)ParametreListesi[ix];

                parameters[ix] = new ParameterValue();
                parameters[ix].Name = oParametre.Adi;
                parameters[ix].Value = oParametre.DegeriniAl();
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

        public void RaporAc()
        {

            // rs.Timeout
            byte[] buf = RaporAl();
            HttpContext.Current.Response.Charset = "UTF-8";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.Default;

            switch (RaporFormat)
            {
                case RaporFormats.PDF:
                    HttpContext.Current.Response.AppendHeader("content-disposition", "attachment; filename=" + RaporDosyaAd + ".pdf");
                    HttpContext.Current.Response.ContentType = "application/pdf";
                    HttpContext.Current.Response.BinaryWrite(buf);
                    break;
                case RaporFormats.EXCEL:
                    HttpContext.Current.Response.AppendHeader("content-disposition", "attachment; filename=" + RaporDosyaAd + ".xls");
                    HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
                    HttpContext.Current.Response.BinaryWrite(buf);
                    break;
                case RaporFormats.IMAGE:
                    HttpContext.Current.Response.AppendHeader("content-disposition", "attachment; filename=" + RaporDosyaAd + ".tiff");
                    HttpContext.Current.Response.ContentType = "image/tiff";
                    HttpContext.Current.Response.BinaryWrite(buf);
                    break;
                case RaporFormats.XML:
                    HttpContext.Current.Response.AppendHeader("content-disposition", "attachment; filename=" + RaporDosyaAd + ".xml");
                    HttpContext.Current.Response.ContentType = "text/xml";
                    HttpContext.Current.Response.BinaryWrite(buf);
                    break;
            }

            HttpContext.Current.Response.End();
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
    public class RaporFormatAsString
    {
        public const string PDF = "PDF";
        public const string EXCEL = "EXCEL";
        public const string IMAGE = "IMAGE";
        public const string TIFF = "TIFF";
        public const string XML = "XML";
    }

    public enum RaporFormats
    {
        PDF,
        EXCEL,
        IMAGE,
        XML
    }
    public class Parametre
    {
        public Parametre()
        {

        }

        public Parametre(string pAdi, string pDegeri)
        {
            adi = pAdi;
            degeri = pDegeri;
            this.type = ParameterTypeEnum.String;
        }

        public Parametre(string pAdi, bool pDegeri)
        {
            this.adi = pAdi;
            this.degeri = pDegeri;
            this.type = ParameterTypeEnum.Boolean;
        }

        public Parametre(string pAdi, DateTime pDegeri)
        {
            this.adi = pAdi;
            this.degeri = pDegeri;
            this.type = ParameterTypeEnum.DateTime;
        }
        public Parametre(string pAdi, float pDegeri)
        {
            this.adi = pAdi;
            this.degeri = pDegeri;
            this.type = ParameterTypeEnum.Float;
        }
        public Parametre(string pAdi, int pDegeri)
        {
            this.adi = pAdi;
            this.degeri = pDegeri;
            this.type = ParameterTypeEnum.Integer;
        }



        private string adi;
        private object degeri;

        public string DegeriniAl()
        {
            string sonuc = null;
            switch (type)
            {
                case ParameterTypeEnum.String:
                    sonuc = degeri.ToString();
                    break;
                case ParameterTypeEnum.Integer:
                    sonuc = degeri.ToString();
                    break;
                case ParameterTypeEnum.DateTime:
                    DateTime d = Convert.ToDateTime(degeri);
                    sonuc = string.Format("{0:yyyy-MM-dd HH:mm:ss}", d);
                    break;
                case ParameterTypeEnum.Boolean:
                    sonuc = degeri.ToString();
                    break;
                case ParameterTypeEnum.Float:
                    sonuc = degeri.ToString();
                    break;
            }
            return sonuc;
        }


        public object Degeri
        {
            get
            {
                return degeri;
            }
            set
            {
                if (value is string)
                {
                    degeri = value;
                    this.type = ParameterTypeEnum.String;
                }
                else if (value is DateTime)
                {
                    degeri = value;
                    this.type = ParameterTypeEnum.DateTime;
                }
                else if (value is bool)
                {
                    degeri = value;
                    this.type = ParameterTypeEnum.Boolean;
                }
                else if (value is Int32)
                {
                    degeri = value;
                    this.type = ParameterTypeEnum.Integer;
                }
                else if (value is float)
                {
                    degeri = value;
                    this.type = ParameterTypeEnum.Float;
                }
                throw new ArgumentException("Desteklenmeyen Tip");
            }
        }
        private ParameterTypeEnum type;

        public ParameterTypeEnum ParameterType
        {
            get { return type; }
            set { type = value; }
        }


        public string Adi
        {
            get
            {
                return adi;
            }
            set
            {
                adi = value;
            }
        }



    }




}