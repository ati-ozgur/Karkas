using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Karkas.Web.Helpers.BaseClasses;
using System.IO;

namespace Karkas.Web.Helpers.HelperClasses
{
    public partial class KarkasWebHelper
    {

        public class ExportHelper
        {
            KarkasBasePage calisanSayfa;
            public ExportHelper(KarkasBasePage pCalisanSayfa)
            {
                this.calisanSayfa = pCalisanSayfa;
            }
            public void ToCsv(DataTable kaynak)
            {
                ToCsv(kaynak, kaynak.TableName, "csv", true, Encoding.UTF8, ",");
            }
            public void ToCsv(DataTable kaynak, string dosyaAd)
            {
                ToCsv(kaynak, dosyaAd, "csv", true, Encoding.UTF8, ",", "\"");
            }
            public void ToCsv(DataTable kaynak, string dosyaAd, string uzanti)
            {
                ToCsv(kaynak, dosyaAd, uzanti, true, Encoding.UTF8, ",", "\"");
            }
            public void ToCsv(DataTable kaynak, string dosyaAd, string uzanti, bool baslikYaz)
            {
                ToCsv(kaynak, dosyaAd, uzanti, baslikYaz, Encoding.UTF8, ",", "\"");
            }
            public void ToCsv(DataTable kaynak, string dosyaAd, string uzanti, bool baslikYaz, Encoding encoding)
            {
                ToCsv(kaynak, dosyaAd, uzanti, baslikYaz, encoding, ",", "\"");
            }
            public void ToCsv(DataTable kaynak, string dosyaAd, string uzanti, bool baslikYaz, Encoding encoding, string ayrac)
            {
                ToCsv(kaynak, dosyaAd, uzanti, baslikYaz, encoding, ayrac, "\"");
            }

            public void ToCsv(DataTable kaynak, string dosyaAd, string uzanti, bool baslikYaz, Encoding encoding, string ayrac, string kolonbelirteci)
            {
                calisanSayfa.Response.Clear();
                calisanSayfa.Response.ClearHeaders();
                calisanSayfa.Response.Charset = encoding.WebName;
                calisanSayfa.Response.ContentEncoding = encoding;
                calisanSayfa.Response.AppendHeader("content-disposition", "attachment; filename=" + dosyaAd + "." + uzanti);
                calisanSayfa.Response.ContentType = "application/vnd.ms-excel";
                StringBuilder sw = new StringBuilder();
                if (baslikYaz)
                {
                    foreach (DataColumn column in kaynak.Columns)
                    {
                        sw.Append(column.Caption);
                        sw.Append(ayrac);
                    }

                    sw.Append("\n");
                }
                foreach (DataRow row in kaynak.Rows)
                {
                    foreach (DataColumn column in kaynak.Columns)
                    {
                        sw.Append(string.Format(kolonbelirteci + "{0}" + kolonbelirteci,row[column].ToString()));
                        sw.Append(ayrac);
                    }
                    sw.Append("\n");
                }




                calisanSayfa.Response.Write(sw.ToString());
                calisanSayfa.Response.End();

            }

            public void ToExcel(DataTable kaynak, string dosyaAd, bool baslikYaz)
            {
                ToExcel(kaynak, dosyaAd, baslikYaz, Encoding.UTF8);
            }

            public void ToExcel(DataTable kaynak, string dosyaAd, bool baslikYaz, Encoding encoding)
            {
                calisanSayfa.Response.Clear();
                calisanSayfa.Response.Charset = encoding.WebName;
                calisanSayfa.Response.ContentEncoding = encoding;

                calisanSayfa.Response.AppendHeader("content-disposition", "attachment; filename=" + dosyaAd + ".xls");
                calisanSayfa.Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                sw.Write("<table>");
                if (baslikYaz)
                {
                    sw.Write("<tr>");
                    foreach (DataColumn column in kaynak.Columns)
                    {
                        sw.Write("<td>");
                        sw.Write(column.Caption);
                        sw.Write("</td>");
                    }

                    sw.Write("</tr>");
                }
                foreach (DataRow row in kaynak.Rows)
                {
                    sw.Write("<tr>");
                    foreach (DataColumn column in kaynak.Columns)
                    {
                        sw.Write("<td>");
                        sw.Write(row[column].ToString());
                        sw.Write("</td>");
                    }

                    sw.Write("</tr>");
                }


                sw.Write("</table>");


                calisanSayfa.Response.Write(sw.ToString());
                calisanSayfa.Response.End();
            }


            public void ToExcel(DataView kaynak, string dosyaAd, bool baslikYaz)
            {
                ToExcel(kaynak.ToTable(), dosyaAd, baslikYaz);
            }
            public void ToExcel(DataView kaynak, string dosyaAd)
            {
                ToExcel(kaynak.ToTable(), dosyaAd, true);
            }
            public void ToExcel(DataView kaynak)
            {
                DataTable dt = kaynak.ToTable();
                ToExcel(dt, dt.TableName, true);
            }

            public void ToExcel(DataTable dt, string dosyaAd)
            {
                ToExcel(dt, dosyaAd, true);
            }
            public void ToExcel(DataTable dt)
            {
                ToExcel(dt, dt.TableName, true);
            }

        }
    }
}


