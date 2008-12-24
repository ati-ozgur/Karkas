using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Web.Script.Services;
using Karkas.Ornek.TypeLibrary.Ornekler;
using System.Collections.Generic;
using Karkas.Ornek.Dal.Ornekler;



/// <summary>
/// Summary description for MusteriWS
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[ScriptService]
public class MusteriWS : System.Web.Services.WebService
{

    public MusteriWS()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public List<Musteri> SorgulaTamAdiIle(string pTamAdi)
    {
        MusteriDal dal = new MusteriDal();
        return dal.SorgulaTamAdiIle(pTamAdi);
    }

}

