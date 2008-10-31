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

            public void ToExcel(DataTable kaynak, string dosyaAd, bool baslikYaz)
            {
                calisanSayfa.Response.Clear();
                calisanSayfa.Response.Charset = "UTF-8";
                calisanSayfa.Response.ContentEncoding = Encoding.UTF8;
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


            public void ToExcel(DataView kaynak, string dosyaAd,bool baslikYaz)
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
                ToExcel(dt,dt.TableName, true);
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

