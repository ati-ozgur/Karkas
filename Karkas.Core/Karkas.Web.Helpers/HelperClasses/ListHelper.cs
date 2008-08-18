using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Web.UI.WebControls;

namespace Karkas.Web.Helpers.HelperClasses
{
    public class ListHelper
    {
        public void ListControlaBindEt(IList list, ListControl listControl, string valueField, string textField)
        {
            if (list.Count > 0)
            {
                listControlBindOrtak(list, listControl, valueField, textField);
            }
        }
        public void ListControlaBindEtLutfenEkle(IList list, ListControl listControl, string valueField, string textField)
        {
            if (list.Count > 0)
            {
                listControlBindOrtak(list, listControl, valueField, textField);
                listControl.Items.Insert(0, new ListItem("L�tfen Se�iniz", "0"));
            }
        }

        private static void listControlBindOrtak(IList list, ListControl listControl, string valueField, string textField)
        {
            listControl.DataSource = list;
            listControl.DataTextField = textField;
            listControl.DataValueField = valueField;
            listControl.DataBind();
        }
        public void ListControlaBindEtLutfenEkle(IList list, ListControl listControl
                        , string valueField, string textField
                        , string yazi)
        {
            if (list.Count > 0)
            {
                listControlBindOrtak(list, listControl, valueField, textField);
                listControl.Items.Insert(0, new ListItem(yazi, "0"));
            }
        }

        public void ListControlaBindEtLutfenEkle(IList list, ListControl listControl
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
