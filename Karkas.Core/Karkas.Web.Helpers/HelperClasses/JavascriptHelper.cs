namespace Karkas.Web.Helpers.HelperClasses
{
    using Karkas.Web.Helpers.BaseClasses;
    using System;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    public partial class KarkasWebHelper
    {

        public class JavascriptHelper
        {
            private readonly KarkasBasePage calisanSayfa;
            private const string popUpCloseScript = "javascript:window.opener.location=window.opener.location; window.close();";
            private const string ScriptFormat = "<script type=\"text/javascript\">\r\n                                    <!--\r\n                                    {0}\r\n                                    // -->\r\n                                    </script>";

            public JavascriptHelper(KarkasBasePage p)
            {
                this.calisanSayfa = p;
            }
            public void Alert(string message)
            {
                Alert(message, "Alert");
            }

            public void Alert(string message, string key)
            {
                Alert(this.calisanSayfa, message, key);
            }



            public void Alert(Page page, string message, string key)
            {
                message = alertIcinDuzgunMesajOlustur(message);
                JavascriptHelper.ScriptEkle(page, message, key);
            }

            public static string alertIcinDuzgunMesajOlustur(string message)
            {
                message = message.Replace("'", "\'");

                if (message.Contains("\n"))
                {
                    message = message.Replace("\r\n", "\n");
                    string[] satirlar = message.Split('\n');
                    string yeniMesaj = "var a = \"";
                    for (int i = 0; i < satirlar.Length - 1; i++)
                    {
                        string satir = satirlar[i];
                        yeniMesaj += string.Format("{0} \\n ", satir);
                    }
                    yeniMesaj = yeniMesaj.Remove(yeniMesaj.Length - 4);
                    yeniMesaj += "\"; alert(a);";
                    message = yeniMesaj;
                }
                else
                {
                    message = string.Format("alert('{0}');", message);
                }
                return message;
            }


            public static void ScriptEkle(Page page, string script, string key)
            {
                JavascriptHelper.ScriptRegister(page, script, key);
            }

            public void PopUpiKapat()
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Write(ScriptTaglariArasinaAl("javascript:window.close();"));
                HttpContext.Current.Response.End();
            }
            public void SayfaRefresh()
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Write(ScriptTaglariArasinaAl("javascript:window.opener.location=window.opener.location;"));
                HttpContext.Current.Response.End();
            }

            public void PopUpiKapatAcanPencereyiRefresh()
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Write(ScriptTaglariArasinaAl("javascript:window.opener.location=window.opener.location; window.close();"));
                HttpContext.Current.Response.End();
            }
            public void PopUpWindowBaslangictaAc(string pPageUrl)
            {
                PopUpWindowBaslangictaAc(pPageUrl, 640, 480, false);
            }
            public void PopUpWindowBaslangictaAc(string pPageUrl,int pWidth,int pHeight)
            {
                PopUpWindowBaslangictaAc(pPageUrl, pWidth, pHeight, false);
            }


            public void PopUpWindowBaslangictaAc(string pPageUrl, int pWidth, int pHeight, bool pResize)
            {
                if (!this.Page.ClientScript.IsStartupScriptRegistered(this.Page.GetType(), "PopUp"))
                {
                    string script = javascriptLinkiniBul(pPageUrl, pWidth, pHeight, pResize);
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "PopUp", ScriptTaglariArasinaAl(script));
                }
            }

            public void PopUpWindowBaslangictaMaximizeAc(string pPageUrl, int pWidth, int pHeight)
            {
                this.calisanSayfa.Session["maximizeWindow"] = "true";
                this.PopUpWindowBaslangictaAc(pPageUrl, pWidth, pHeight, true);
            }

            public void PopUpWindowEventiEkle(WebControl pControl, string pPageUrl)
            {
                this.PopUpWindowEventiEkle(pControl, pPageUrl, 600, 800);
            }

            public void PopUpWindowEventiEkle(WebControl pControl, string pPageUrl, int pWidth, int pHeight)
            {
                this.PopUpWindowEventiEkle(pControl, pPageUrl, pWidth, pHeight, false);
            }

            public void PopUpWindowEventiEkle(WebControl pControl, string pPageUrl, int pWidth, int pHeight, bool pResize)
            {
                string jsString = javascriptLinkiniBul(pPageUrl, pWidth, pHeight, pResize);
                if (pControl is LinkButton)
                {
                    (pControl as LinkButton).OnClientClick = jsString;
                }
                else if (pControl is HyperLink)
                {
                    (pControl as HyperLink).NavigateUrl = jsString;
                }
                else
                {
                    pControl.Attributes.Add("OnClick", jsString);
                }
            }


            private string javascriptLinkiniBul(string pPageUrl, int pWidth, int pHeight, bool pResize)
            {
                if (pPageUrl.Contains("~/"))
                {
                    if (this.calisanSayfa.BasePath.EndsWith("/"))
                    {
                        pPageUrl = pPageUrl.Replace("~/", this.calisanSayfa.BasePath);
                    }
                    else
                    {
                        pPageUrl = pPageUrl.Replace("~/", this.calisanSayfa.BasePath + "/");
                    }
                }

                string jsString = string.Format("javascript:CreateWnd('{0}', {1}, {2}, {3});", pPageUrl, pWidth, pHeight, pResize ? "true" : "false");
                return jsString;
            }

            public void PopUpWindowEventiEkleMaximizeAc(WebControl pControl, string pPageUrl)
            {
                this.calisanSayfa.Session["maximizeWindow"] = "true";
                this.PopUpWindowEventiEkle(pControl, pPageUrl, 600, 800);
            }

            public void ScriptRegister(string javascript, string key)
            {
                JavascriptHelper.ScriptRegister(this.calisanSayfa, javascript, key);
            }
            public void ScriptRegisterFile(string javascriptFileName, string key)
            {
                if (!Page.ClientScript.IsClientScriptIncludeRegistered(key))
                {
                    string url = Page.ResolveClientUrl(javascriptFileName);
                    this.Page.ClientScript.RegisterClientScriptInclude(key, url);
                }
            }



            private static void ScriptRegister(Page page, string javascript, string key)
            {
                if ((ScriptManager.GetCurrent(page) != null)
                    &&
                (ScriptManager.GetCurrent(page).IsInAsyncPostBack))
                {
                    ScriptManager.RegisterClientScriptBlock(page, page.GetType(), key, javascript, true);
                }

                if ((page != null) && !page.ClientScript.IsClientScriptBlockRegistered(key))
                {
                    javascript = ScriptTaglariArasinaAl(javascript);
                    page.ClientScript.RegisterClientScriptBlock(page.GetType(), key, javascript);
                }
            }



            public static string ScriptTaglariArasinaAl(string pYazi)
            {
                return string.Format("<script type=\"text/javascript\">\r\n                                    <!--\r\n                                    {0}\r\n                                    // -->\r\n                                    </script>", pYazi);
            }

            public Page Page
            {
                get
                {
                    return this.calisanSayfa;
                }
            }

        }



    }

}

