using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using Karkas.Web.Helpers.BaseClasses;
using System.IO;

namespace Karkas.Web.Helpers.HelperClasses
{
    public partial class KarkasWebHelper
    {
        public class GridHelper
        {
            public static void GridViewBind(GridView grv, object oDataSource)
            {
                grv.DataSource = oDataSource;
                grv.DataBind();
            }

            KarkasBasePage calisanSayfa;
            public GridHelper(KarkasBasePage pBasePage)
            {
                this.calisanSayfa = pBasePage;
            }
            /// <summary>
            /// Verilen GridView'ý Excel'e import eder.
            /// Bu class'ýn kullanýldýðý sayfada
            /// public override void VerifyRenderingInServerForm(Control control){}
            /// Metodunun eklenmesi Gerekmektedir.
            /// </summary>
            /// <param name="Pg"></param>
            /// <param name="gv"></param>
            /// <param name="DosyaAd"></param>
            public static void GridViewToExcel(Page Pg, GridView gv, string DosyaAd)
            {
                Pg.Response.Clear();
                Pg.Response.Charset = "UTF-8";
                Pg.Response.ContentEncoding = System.Text.Encoding.Default;
                Pg.Response.AppendHeader("content-disposition", "attachment; filename=" + DosyaAd + ".xls");
                Pg.Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                gv.RenderControl(htw);
                Pg.Response.Write(sw.ToString());
                Pg.Response.End();
            }
            /// <summary>
            /// Verilen GridView'ý Word'e import eder.
            /// Bu class'ýn kullanýldýðý sayfada
            /// public override void VerifyRenderingInServerForm(Control control){}
            /// Metodunun eklenmesi Gerekmektedir.
            /// </summary>
            /// <param name="Pg"></param>
            /// <param name="gv"></param>
            /// <param name="DosyaAd"></param>
            public static void GridViewToWord(Page Pg, GridView gv, string DosyaAd)
            {
                Pg.Response.Clear();
                Pg.Response.Charset = "UTF-8";
                Pg.Response.ContentEncoding = System.Text.Encoding.Default;
                Pg.Response.AppendHeader("content-disposition", "attachment; filename=" + DosyaAd + ".doc");
                Pg.Response.ContentType = "application/vnd.ms-word";
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                gv.RenderControl(htw);
                Pg.Response.Write(sw.ToString());
                Pg.Response.End();
            }

            public void GridViewToExcel(GridView gv, string DosyaAd)
            {
                GridViewToExcel(this.calisanSayfa, gv, DosyaAd);
            }

            public  void GridViewToWord(GridView gv, string DosyaAd)
            {
                GridViewToWord(this.calisanSayfa, gv, DosyaAd);
            }
        }
    }
}
