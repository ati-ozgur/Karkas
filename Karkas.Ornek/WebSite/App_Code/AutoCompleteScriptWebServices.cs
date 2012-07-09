using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using AjaxControlToolkit;

/// <summary>
/// Summary description for AutoCompleteScriptWebServices
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class AutoCompleteScriptWebServices : System.Web.Services.WebService {

    public AutoCompleteScriptWebServices () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string[] AdIleAra(String prefixText)
    {
        int length = 10;
        string[] stringDizi = new string[length];
        for (int i = 0; i < length; i++)
        {
            stringDizi[i] = AutoCompleteExtender.CreateAutoCompleteItem(
                prefixText + " " + i
                , i.ToString()
                );
        }
        return stringDizi;
    }
    
}
