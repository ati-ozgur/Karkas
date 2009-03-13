using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Karkas.Ornek.TypeLibrary.Ornekler;
using Karkas.Ornek.BsWrapper.Ornekler;
using Karkas.Web.Helpers.BaseClasses;

public partial class Ornekler_CRUD_AciklamaCrud : KarkasBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void KaydetButton_Click(object sender, EventArgs e)
    {
        Aciklama a = new Aciklama();
        a.AciklamaKey = Guid.NewGuid();
        a.AciklamaProperty = AciklamaTextBox.Text;
        
        AciklamaBsWrapper bsWrapper = new AciklamaBsWrapper();
        try
        {
            bsWrapper.Ekle(a);
            MessageBox("Acıklama Başarı ile Kayıt edildi");
        }
        catch(Exception ex)
        {

            MessageBox("Hata Oluştu :" + ex.Message);
        }

    }
}
