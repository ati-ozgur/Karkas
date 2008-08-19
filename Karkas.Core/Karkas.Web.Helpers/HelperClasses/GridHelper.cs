using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using Karkas.Web.Helpers.BaseClasses;

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

            public static void GridViewToExcel(Page Pg, GridView gv, string DosyaAd)
            {

            }

            public static void GridViewToWord(Page Pg, GridView gv, string DosyaAd)
            {

            }

            public static void GridViewToExcel(GridView gv, string DosyaAd)
            {

            }

            public static void GridViewToWord(GridView gv, string DosyaAd)
            {

            }


        }
    }
}
