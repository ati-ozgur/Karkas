using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Diagnostics;

namespace Karkas.Core.Validation.ForPonos
{
    [Serializable]
    [DebuggerDisplay("PropertyName={PropertyName},ErrorMessage={ErrorMessage}")]
    public abstract class BaseValidator
    {
        string propertyName;

        public string PropertyName
        {
            get { return propertyName; }
            set { propertyName = value; }
        }
        public BaseValidator(object uzerindeCalisilacakNesne, string pPropertyName)
        {
            this.propertyName = pPropertyName;
            Type t = uzerindeCalisilacakNesne.GetType();
            property = t.GetProperty(propertyName);
            ErrorMessage = BuildErrorMessage();
        }
        public BaseValidator(object uzerindeCalisilacakNesne, string pPropertyName, string pErrorMessage)
        {
            this.propertyName = pPropertyName;
            Type t = uzerindeCalisilacakNesne.GetType();
            property = t.GetProperty(propertyName);
            ErrorMessage = pErrorMessage;
        }


        private String errorMessage;
        private PropertyInfo property;

        /// <summary>
        /// Implementors should perform any initialization logic
        /// </summary>
        /// <param name="property">The target property</param>
        public void Initialize(PropertyInfo property)
        {
            this.property = property;

            if (errorMessage == null)
            {
                errorMessage = BuildErrorMessage();
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
        public String ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }

        /// <summary>
        /// Implementors should perform the actual validation upon
        /// the property value
        /// </summary>
        /// <param name="instance"></param>
        /// <returns><c>true</c> if the field is OK</returns>
        public bool Perform(object instance)
        {
            return this.Perform(instance, Property.GetValue(instance, null));
        }

        /// <summary>
        /// Implementors should perform the actual validation upon
        /// the property value
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="fieldValue"></param>
        /// <returns><c>true</c> if the field is OK</returns>
        public abstract bool Perform(object instance, object fieldValue);

        protected abstract string BuildErrorMessage();
    }

}
