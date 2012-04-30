using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace Karkas.Core.Utility
{
    public class ExportHelper
    {

        public void ToCsvFile(DataTable pSource,string pFileName)
        {
            string pCsvContents = ToCsvString(pSource, true, ";", "\"");
            File.WriteAllText(pFileName, pCsvContents);
        }
            


        public String ToCsvString(DataTable kaynak, bool baslikYaz,string ayrac, string kolonbelirteci)
        {
            StringBuilder sb = new StringBuilder();
            if (baslikYaz)
            {
                foreach (DataColumn column in kaynak.Columns)
                {
                    sb.Append(column.Caption);
                    sb.Append(ayrac);
                }

                sb.Append("\n");
            }
            foreach (DataRow row in kaynak.Rows)
            {
                foreach (DataColumn column in kaynak.Columns)
                {
                    sb.Append(string.Format(kolonbelirteci + "{0}" + kolonbelirteci, row[column].ToString()));
                    sb.Append(ayrac);
                }
                sb.Append("\n");
            }

            return sb.ToString();

        }


        public String ToExcelString(DataTable kaynak, string dosyaAd, bool baslikYaz, Encoding encoding)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("<html>");
            sb.Append("<head>");
            sb.Append(string.Format("<meta http-equiv=\"Content-Type\" content=\"text/html; charset={0}\">", encoding.BodyName));
            sb.Append("</head>");
            sb.Append("<body>");
            sb.Append("<table>");
            if (baslikYaz)
            {
                sb.Append("<tr>");
                foreach (DataColumn column in kaynak.Columns)
                {
                    sb.Append("<td>");
                    sb.Append(column.Caption);
                    sb.Append("</td>");
                }

                sb.Append("</tr>");
            }
            foreach (DataRow row in kaynak.Rows)
            {
                sb.Append("<tr>");
                foreach (DataColumn column in kaynak.Columns)
                {
                    sb.Append("<td>");
                    sb.Append(row[column].ToString());
                    sb.Append("</td>");
                }

                sb.Append("</tr>");
            }


            sb.Append("</table>");
            sb.Append("</body>");
            sb.Append("</html>");
            return sb.ToString();

        }




    }
}





