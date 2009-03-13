using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.Core.DataUtil;

namespace Karkas.Ornek.ConsoleApp.DataUtilOrnekleri
{
    public class OrneklerConnection
    {
        public static AdoTemplate Template
        {

            get
            {
                AdoTemplate template = new AdoTemplate();
                return template;
            }
        }
    }
}
