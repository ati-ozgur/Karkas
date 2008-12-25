using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace Karkas.Web.Helpers.BaseClasses
{
    public class BaseKarkasUserControl : UserControl
    {
        public KarkasBasePage BasePage
        {
            get
            {
                return (KarkasBasePage)this.Page;
            }
        }

        public string BasePath
        {
            get
            {
                return this.BasePage.BasePath;
            }
        }
        public string Port
        {
            get
            {
                return this.BasePage.Port;
            }
        }
        public string Protocol
        {
            get
            {
                return this.BasePage.Protocol;
            }
        }
    }
}
