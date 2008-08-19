using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Web.UI.WebControls;

namespace Karkas.Web.Helpers.HelperClasses
{
    public partial class KarkasWebHelper
    {
        public class ListHelper
        {
            public static void ListControlaBindEt(IList list, ListControl listControl, string valueField, string textField)
            {
                if (list.Count > 0)
                {
                    listControlBindOrtak(list, listControl, valueField, textField);
                }
            }
            public static void ListControlaBindEtLutfenEkle(IList list, ListControl listControl, string valueField, string textField)
            {
                if (list.Count > 0)
                {
                    listControlBindOrtak(list, listControl, valueField, textField);
                    listControl.Items.Insert(0, new ListItem("Lütfen Seçiniz", "0"));
                }
            }

            private static void listControlBindOrtak(IList list, ListControl listControl, string valueField, string textField)
            {
                listControl.DataSource = list;
                listControl.DataTextField = textField;
                listControl.DataValueField = valueField;
                listControl.DataBind();
            }
            public static void ListControlaBindEtLutfenEkle(IList list, ListControl listControl
                            , string valueField, string textField
                            , string yazi)
            {
                if (list.Count > 0)
                {
                    listControlBindOrtak(list, listControl, valueField, textField);
                    listControl.Items.Insert(0, new ListItem(yazi, "0"));
                }
            }

            public static void ListControlaBindEtLutfenEkle(IList list, ListControl listControl
                            , string valueField, string textField
                            , string yazi, string deger)
            {
                if (list.Count > 0)
                {
                    listControlBindOrtak(list, listControl, valueField, textField);
                    listControl.Items.Insert(0, new ListItem(yazi, deger));
                }
            }


        }
    }

}