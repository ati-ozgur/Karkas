using System;
using System.Reflection;

namespace Simetri.Core.Validation.ForPonos
{

	/// <summary>
	/// Define the basic contract for validators
	/// </summary>
	public interface IValidator
	{
		/// <summary>
		/// Implementors should perform any initialization logic
		/// </summary>
		/// <param name="property">The target property</param>
		void Initialize(PropertyInfo property);

		/// <summary>
		/// Implementors should perform the actual validation upon
		/// the property value
		/// </summary>
		/// <param name="instance"></param>
		/// <returns><c>true</c> if the field is OK</returns>
		bool Perform(object instance);

		/// <summary>
		/// Implementors should perform the actual validation upon
		/// the property value
		/// </summary>
		/// <param name="instance"></param>
		/// <param name="fieldValue"></param>
		/// <returns><c>true</c> if the field is OK</returns>
		bool Perform(object instance, object fieldValue);

		/// <summary>
		/// The target property
		/// </summary>
		PropertyInfo Property { get; }

		/// <summary>
		/// The error message to be displayed if the validation fails
		/// </summary>
		String ErrorMessage { get; set; }
	}

    }

