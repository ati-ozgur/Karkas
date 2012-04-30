using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using AjaxControlToolkit;
using System.ComponentModel;

namespace Karkas.Web.Controls
{

    public class AutoCompleteControl : WebControl, INamingContainer
    {
        public AutoCompleteControl()
        {
            autoCompleteMain.ID = "autoCompleteMain";
            textBoxAutoComplete.ID = "textBoxAutoComplete";
            hiddenAutoCompletePk.ID = "hiddenAutoComplete";
        }



        private AutoCompleteExtender autoCompleteMain = new AutoCompleteExtender();
        private TextBox textBoxAutoComplete = new TextBox();
        private HiddenField hiddenAutoCompletePk = new HiddenField();

        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            this.autoCompleteMain.TargetControlID = this.textBoxAutoComplete.ID;

            Controls.Add(autoCompleteMain);
            Controls.Add(textBoxAutoComplete);
            Controls.Add(hiddenAutoCompletePk);
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            string pkAlanFonksiyonIsmi = String.Format("{0}_GetPk", this.ClientID);
            this.autoCompleteMain.OnClientItemSelected = pkAlanFonksiyonIsmi;
            string jsStringFull = string.Format(jsString, pkAlanFonksiyonIsmi, hiddenAutoCompletePk.ClientID);
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), pkAlanFonksiyonIsmi,
                jsStringFull);

        }



        public string OnClientItemSelected
        {
            get
            {
                return this.autoCompleteMain.OnClientItemSelected;
            }
            set
            {
                this.autoCompleteMain.OnClientItemSelected = value;
            }
        }

        public bool Enabled
        {
            get
            {
                return textBoxAutoComplete.Enabled;
            }
               
            set
            {
                textBoxAutoComplete.Enabled = value;
            }
        }


        public void Sifirla()
        {
            this.textBoxAutoComplete.Text = "";
            this.hiddenAutoCompletePk.Value = "";
        }

        /// <summary>
        /// onfocus'ta çalışacak olan javascript kodu.
        /// </summary>
        public String onfocus
        {
            set
            {
                this.textBoxAutoComplete.Attributes.Add("onfocus", value);
            }
        }

        public override void Focus()
        {
            this.textBoxAutoComplete.Focus();
        }


        [DefaultValue("250px")]
        public Unit Width
        {
            get
            {

                return textBoxAutoComplete.Width;
            }
            set
            {
                textBoxAutoComplete.Width = value;
            }
        }

        public string Text
        {
            get
            {
                return textBoxAutoComplete.Text;
            }
            set
            {
                textBoxAutoComplete.Text = value;
            }
        }

        public string PrimaryKey
        {
            get
            {
                if (String.IsNullOrEmpty(textBoxAutoComplete.Text))
                {
                    return null;

                }
                else
                {
                    return hiddenAutoCompletePk.Value;
                }
            }
            set
            {
                hiddenAutoCompletePk.Value = value;
            }
        }
        public int PrimaryKeyAsInt
        {
            get
            {
                return Convert.ToInt32(PrimaryKey);
            }
        }
        public int? PrimaryKeyAsIntNullable
        {
            get
            {
                int sonuc;
                if (Int32.TryParse(PrimaryKey, out sonuc))
                {
                    return sonuc;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                PrimaryKey = value.ToString();
            }
        }

        public Guid? PrimaryKeyAsGuidAsNullable
        {
            get
            {
                try
                {
                    return new Guid(PrimaryKey);
                }
                catch
                {
                    return null;
                }
            }
        }
        public Guid PrimaryKeyAsGuid
        {
            get
            {
                return new Guid(PrimaryKey);
            }
            set
            {
                PrimaryKey = value.ToString();
            }

        }

        public override short TabIndex
        {
            get
            {
                return textBoxAutoComplete.TabIndex;

            }
            set
            {
                textBoxAutoComplete.TabIndex = value;
            }
        }

        [Description("Hangi Methodu kullanacagini setleyin , ornegin AdIleAra")]
        public string ServiceMethod
        {
            get
            {
                return autoCompleteMain.ServiceMethod;

            }
            set
            {
                autoCompleteMain.ServiceMethod = value;
            }
        }

        public int CompletionSetCount
        {
            get
            {
                return autoCompleteMain.CompletionSetCount;

            }
            set
            {
                autoCompleteMain.CompletionSetCount = value;
            }
        }




        public int CompletionInterval
        {
            get
            {
                return autoCompleteMain.CompletionInterval;

            }
            set
            {
                autoCompleteMain.CompletionInterval = value;
            }
        }

        public int MinimumPrefixLength
        {
            get
            {
                return autoCompleteMain.MinimumPrefixLength;

            }
            set
            {
                autoCompleteMain.MinimumPrefixLength = value;
            }
        }

        public string ServicePath
        {
            get
            {
                return autoCompleteMain.ServicePath;

            }
            set
            {
                autoCompleteMain.ServicePath = value;
            }
        }
        private string jsString = @"<script type=""text/javascript""> 
//<![CDATA[
function {0}(source, eventArgs )
         {{
            document.getElementById('{1}').value = eventArgs.get_value();
        }}
//]]>
</script>
        ";


    }
}