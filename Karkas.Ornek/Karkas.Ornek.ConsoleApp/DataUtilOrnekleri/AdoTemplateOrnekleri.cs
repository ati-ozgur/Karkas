using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.Core.DataUtil;

namespace Karkas.Ornek.ConsoleApp.DataUtilOrnekleri
{
    public class AdoTemplateOrnekleri
    {
        public void TekDegerGetirOrnek1()
        {
            AdoTemplate Template = OrneklerConnection.Template;
            int sayi = (int) Template.TekDegerGetir("SELECT COUNT(*) FROM ORNEK.KISI");

            
        }

    }
}
