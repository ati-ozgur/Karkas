using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Diagnostics;

namespace Karkas.Core.Validation.ForPonos
{
    [Serializable]
    [DebuggerDisplay("PropertyIsmi={PropertyIsmi},HataMesaji={HataMesaji}")]
    public abstract class BaseOnaylayici
    {
        string propertyName;

        public string PropertyIsmi
        {
            get { return propertyName; }
            set { propertyName = value; }
        }
        public BaseOnaylayici(object uzerindeCalisilacakNesne, string pPropertyIsmi)
        {
            this.propertyName = pPropertyIsmi;
            Type t = uzerindeCalisilacakNesne.GetType();
            property = t.GetProperty(propertyName);
            HataMesaji = HataMesajlariniOlustur();
        }
        public BaseOnaylayici(object uzerindeCalisilacakNesne, string pPropertyIsmi, string pHataMesaji)
        {
            this.propertyName = pPropertyIsmi;
            Type t = uzerindeCalisilacakNesne.GetType();
            property = t.GetProperty(propertyName);
            HataMesaji = pHataMesaji;
        }


        private String hataMesaji;
        private PropertyInfo property;

        /// <summary>
        /// Implementors should perform any initialization logic
        /// </summary>
        /// <param name="property">The target property</param>
        public void baslangicDurumunaGetir(PropertyInfo property)
        {
            this.property = property;

            if (hataMesaji == null)
            {
                hataMesaji = HataMesajlariniOlustur();
            }
        }

        /// <summary>
        /// The target property
        /// </summary>
        public PropertyInfo Property
        {
            get { return property; }
        }

        /// <summary>
        /// The error message to be displayed if the validation fails
        /// </summary>
        public String HataMesaji
        {
            get { return hataMesaji; }
            set { hataMesaji = value; }
        }

        /// <summary>
        /// Implementors should perform the actual validation upon
        /// the property value
        /// </summary>
        /// <param name="instance"></param>
        /// <returns><c>true</c> if the field is OK</returns>
        public bool IslemYap(object instance)
        {
            return this.IslemYap(instance, Property.GetValue(instance, null));
        }

        /// <summary>
        /// Implementors should perform the actual validation upon
        /// the property value
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="fieldValue"></param>
        /// <returns><c>true</c> if the field is OK</returns>
        public abstract bool IslemYap(object instance, object fieldValue);

        protected abstract string HataMesajlariniOlustur();
    }

}
