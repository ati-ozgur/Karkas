using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Web.UI.WebControls;
using Karkas.Core.Utility;
using System.ComponentModel;

namespace Karkas.Web.Helpers.HelperClasses
{
    public partial class KarkasWebHelper
    {
        public class ListHelper
        {


            public void ListControlaBindEt(IListSource list, ListControl listControl, string valueField, string textField)
            {
                IList l = list.GetList();
                if (l != null)
                {
                    listControlBindOrtak(l, listControl, valueField, textField);
                }
            }


            public void ListControlaBindEt(IList list, ListControl listControl, string valueField, string textField)
            {
                if (list.Count > 0)
                {
                    listControlBindOrtak(list, listControl, valueField, textField);
                }
            }
            public void ListControlaBindEtLutfenEkle(IListSource list, ListControl listControl, string valueField, string textField)
            {
                IList l = list.GetList();
                if (l != null)
                {
                    listControlBindOrtak(l, listControl, valueField, textField);
                    listControl.Items.Insert(0, new ListItem("Lütfen Seçiniz", "0"));
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
            public void ListControlaBindEtLutfenEkle(IListSource list, ListControl listControl
                            , string valueField, string textField
                            , string yazi)
            {
                IList l = list.GetList();
                if (l != null)
                {
                    listControlBindOrtak(l, listControl, valueField, textField);
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

            public void ListControlaBindEtLutfenEkle(IListSource list, ListControl listControl
                            , string valueField, string textField
                            , string yazi, string deger)
            {
                if (list.ContainsListCollection)
                {
                    listControlBindOrtak(list.GetList(), listControl, valueField, textField);
                    listControl.Items.Insert(0, new ListItem(yazi, deger));
                }
            }

            /// <summary>
            /// verilen list controle'e son on yılı küçükten büyüğe doldurur
            /// </summary>
            public void ListYilDoldurArtarak(ListControl listControl)
            {
                for (int i = DateTime.Now.Year - 10; i <= DateTime.Now.Year; i++)
                {
                    listControl.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }

            }


            /// <summary>
            /// verilen list controle'e başlangıç yılından şimdiki yıla,  küçükten büyüğe doldurur
            /// </summary>
            public void ListYilDoldurArtarak(ListControl listControl, int BaslangicYil)
            {
                for (int i = BaslangicYil; i <= DateTime.Now.Year; i++)
                {
                    listControl.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }

            }

            /// <summary>
            /// verilen list controle'e başlangıç yılından bitiş yılına,  küçükten büyüğe doldurur
            /// </summary>
            public void ListYilDoldurArtarak(ListControl listControl, int BaslangicYil, int BitisYil)
            {
                for (int i = BaslangicYil; i <= BitisYil; i++)
                {
                    listControl.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }

            }
            /// <summary>
            /// verilen list controle'e başlangıç yılından şimdiki yıla,  büyükten küçüğe doğru doldurur
            /// </summary>

            public void ListYilDoldurAzalarak(ListControl listControl, int BaslangicYil)
            {
                for (int i = DateTime.Now.Year; i >= BaslangicYil ; i--)
                {
                    listControl.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }

            }
            /// <summary>
            /// verilen list controle'e son on yılı büyükten küçüğe doğru doldurur
            /// </summary>
            /// <param name="listControl"></param>
            public void ListYilDoldurAzalarak(ListControl listControl)
            {
                for (int i = DateTime.Now.Year; i >= DateTime.Now.Year-10; i--)
                {
                    listControl.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }

            }
            /// <summary>
            /// verilen list controle'e başlangıç yılından bitiş yılına,   büyükten küçüge doldurur
            /// </summary>
            public void ListYilDoldurAzalarak(ListControl listControl, int BaslangicYil, int BitisYil)
            {
                for (int i = BitisYil; i >= BaslangicYil; i--)
                {
                    listControl.Items.Add(new ListItem(i.ToString(), i.ToString()));
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

