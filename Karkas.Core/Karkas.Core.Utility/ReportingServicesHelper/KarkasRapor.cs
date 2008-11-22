using System;
using System.Web.UI.WebControls;

using System.Collections;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Collections.Generic;


using Karkas.Core.Utility.ReportingServicesHelper.Generated;

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

        public KarkasRapor()
        {
            rs.UseDefaultCredentials = UseDefaultCredentials;
        }

        public KarkasRapor(string pRaporAd)
            : this()
        {
            RaporAd = pRaporAd;
        }

        private ICredentials credentials;
        private bool useDefaultCredentials = false;

        public bool UseDefaultCredentials
        {
            get { return useDefaultCredentials; }
            set { useDefaultCredentials = value; }
        }

        private string webServiceSecurityModel;

        public string WebServiceSecurityModel
        {
            get
            {
                if (String.IsNullOrEmpty(webServiceSecurityModel))
                {
                    webServiceSecurityModel = System.Configuration.ConfigurationManager.AppSettings["RaporWebServiceSecurityModel"].ToString();
                }
                return webServiceSecurityModel;
            }
            set { webServiceSecurityModel = value; }
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
                        cache.Add(new Uri(RaporSunucuUrl), WebServiceSecurityModel, new NetworkCredential(RaporKullanici, RaporPassword, RaporCredentialsDomain));
                        credentials = cache;
                    }
                }
                return credentials;
            }
            set { credentials = value; }
        }

        private string raporUser;

        public string RaporKullanici
        {
            get
            {
                if (String.IsNullOrEmpty(raporUser))
                {
                    raporUser = System.Configuration.ConfigurationManager.AppSettings["RaporKullanici"].ToString();
                }
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
                    raporPassword = System.Configuration.ConfigurationManager.AppSettings["RaporPassword"].ToString();
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
                    raporCredentialsDomain = System.Configuration.ConfigurationManager.AppSettings["RaporCredentialsDomain"].ToString();
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
            ReportingService rs = new ReportingService();
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
                    buf = rs.Render(raporAd, "PDF", null, "", parameters, dsCredentials, "", out encoding, out mimeType, out paramatersUsed, out warnings, out streamids);
                    break;
                case RaporFormats.EXCEL:
                    buf = rs.Render(raporAd, "EXCEL", null, "", parameters, dsCredentials, "", out encoding, out mimeType, out paramatersUsed, out warnings, out streamids);
                    break;
                case RaporFormats.IMAGE:
                    buf = rs.Render(raporAd, "IMAGE", null, "", parameters, dsCredentials, "", out encoding, out mimeType, out paramatersUsed, out warnings, out streamids);
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
            }

            HttpContext.Current.Response.End();
        }


        public static void DDLRaporFormatDoldur(DropDownList ddl)
        {
            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("PDF", "PDF"));
            ddl.Items.Add(new ListItem("EXCEL", "EXCEL"));
            ddl.Items.Add(new ListItem("TIFF", "IMAGE"));
        }

    }


    public enum RaporFormats
    {
        PDF,
        EXCEL,
        IMAGE,
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