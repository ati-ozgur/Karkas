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
            public void ToExcel(DataTable dt, string dosyaAd)
            {
                calisanSayfa.Response.Clear();
                calisanSayfa.Response.Charset = "UTF-8";
                calisanSayfa.Response.ContentEncoding = System.Text.Encoding.Default;
                calisanSayfa.Response.AppendHeader("content-disposition", "attachment; filename=" + dosyaAd + ".xls");
                calisanSayfa.Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                sw.Write("<table>");

                foreach (DataRow row in dt.Rows)
                {
                    sw.Write("<tr>");
                    foreach (DataColumn column in dt.Columns)
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
        }
    }
}

