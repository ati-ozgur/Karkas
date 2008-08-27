using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Web.UI.WebControls;
using Karkas.Core.Utility;

namespace Karkas.Web.Helpers.HelperClasses
{
    public partial class KarkasWebHelper
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
                    listControl.Items.Insert(0, new ListItem("Lütfen Seçiniz", "0"));
                }
            }

            private void listControlBindOrtak(IList list, ListControl listControl, string valueField, string textField)
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




            public void ListAyDoldur(ListControl listControl)
            {
                ListControlaBindEt(Ay.AyListesi,listControl,Ay.PropertyIsimleri.AyDeger,Ay.PropertyIsimleri.AyIsmi);
            }
            public void ListAyDoldur(ListControl listControl, int piSecili)
            {
                ListAyDoldur(listControl);
                listControl.SelectedValue = piSecili.ToString();
            }

            public void ListAyDoldurLutfenEkle(ListControl listControl)
            {
                ListAyDoldur(listControl);
                listControl.Items.Insert(0, new ListItem("Lütfen Seçiniz","0" ));
            }
            public void ListAyDoldurLutfenEkle(ListControl listControl,string yazi)
            {
                ListAyDoldur(listControl);
                listControl.Items.Insert(0, new ListItem(yazi,"0"));
            }
            public void ListAyDoldurLutfenEkle(ListControl listControl, string yazi,string deger)
            {
                ListAyDoldur(listControl);
                listControl.Items.Insert(0, new ListItem(yazi, deger));
            }



        }
    }

}