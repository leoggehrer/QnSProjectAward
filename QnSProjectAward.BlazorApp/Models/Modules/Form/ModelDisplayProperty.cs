//@QnSCodeCopy
//MdStart

using CommonBase.Extensions;
using System;
using System.Reflection;

namespace QnSProjectAward.BlazorApp.Models.Modules.Form
{
	public class ModelDisplayProperty : ModelProperty
	{
		public DisplayProperty DisplayProperty { get; init; }
		public string OriginName => DisplayProperty.OriginName;
		public bool CanRead => PropertyInfo.CanRead;
		public bool CanWrite => PropertyInfo.CanWrite;
		public int Order => DisplayProperty.Order;
		public ModelDisplayProperty(Type modelType, PropertyInfo propertyInfo, DisplayProperty displayProperty) 
			: base(modelType, propertyInfo)
		{
			displayProperty.CheckArgument(nameof(displayProperty));

			DisplayProperty = displayProperty;
		}
	}
}

//MdEnd
