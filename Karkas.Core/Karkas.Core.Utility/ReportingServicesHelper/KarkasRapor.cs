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
    public partial class KarkasRapor
    {



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

        bool dataSourceDegisecekMi = false;
        int? yil;
        string yeniDataSource = null;

        public KarkasRapor(string pRaporAd, int pYil)
            : this(pRaporAd)
        {
            dataSourceDegisecekMi = true;
            this.yil = pYil;

        }

        public KarkasRapor(string pRaporAd, string pDataSourceName)
            : this(pRaporAd)
        {
            rs.Credentials = Credentials;
            DataSource[] listeDataSource = rs.GetReportDataSources(pRaporAd);
            DataSource eskiDs = listeDataSource[0];
            DataSourceReference reference = new DataSourceReference();
            reference.Reference = pDataSourceName;
            DataSource[] dataSources = new DataSource[1];
            DataSource ds = new DataSource();
            ds.Item = (DataSourceDefinitionOrReference)reference;
            ds.Name = eskiDs.Name;
            dataSources[0] = ds;
            rs.SetReportDataSources(pRaporAd, listeDataSource);

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


        public void dataSourceDegistir()
        {
            rs.Credentials = Credentials;
            DataSource[] listeDataSource = rs.GetReportDataSources(RaporAd);
            DataSource eskiDs = listeDataSource[0];

            string refer = ((DataSourceReference)eskiDs.Item).Reference;
            string referYilYok = refer;
            Regex regex = new Regex("[0-9]+");
            Match m = regex.Match(refer);

            if (m.Success)
            {
                referYilYok = refer.Substring(0, m.Index);
            }



            DataSourceReference reference = new DataSourceReference();
            reference.Reference = referYilYok + yil.ToString();
            DataSource[] dataSources = new DataSource[1];
            DataSource ds = new DataSource();
            ds.Item = (DataSourceDefinitionOrReference)reference;
            ds.Name = eskiDs.Name;
            dataSources[0] = ds;
            rs.SetReportDataSources(RaporAd, listeDataSource);
        }


        public byte[] RaporAl()
        {
            rs.Credentials = Credentials;

            if (dataSourceDegisecekMi)
            {
                dataSourceDegistir();
            }

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





}