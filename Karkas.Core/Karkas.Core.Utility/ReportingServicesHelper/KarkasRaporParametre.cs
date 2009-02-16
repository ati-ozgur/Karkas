using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.Core.Utility.ReportingServicesHelper.Generated;

namespace Karkas.Core.Utility.ReportingServicesHelper
{
    public class KarkasRaporParametre
    {
        public KarkasRaporParametre()
        {

        }

        public KarkasRaporParametre(string pAdi, string pDegeri)
        {
            adi = pAdi;
            degeri = pDegeri;
            this.type = ParameterTypeEnum.String;
        }

        public KarkasRaporParametre(string pAdi, bool pDegeri)
        {
            this.adi = pAdi;
            this.degeri = pDegeri;
            this.type = ParameterTypeEnum.Boolean;
        }

        public KarkasRaporParametre(string pAdi, DateTime pDegeri)
        {
            this.adi = pAdi;
            this.degeri = pDegeri;
            this.type = ParameterTypeEnum.DateTime;
        }
        public KarkasRaporParametre(string pAdi, float pDegeri)
        {
            this.adi = pAdi;
            this.degeri = pDegeri;
            this.type = ParameterTypeEnum.Float;
        }
        public KarkasRaporParametre(string pAdi, int pDegeri)
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

