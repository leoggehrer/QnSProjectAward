//@QnSCodeCopy
//MdStart

using CommonBase.Extensions;
using QnSProjectAward.BlazorApp.Models.Modules.Common;
using System;
using System.Reflection;

namespace QnSProjectAward.BlazorApp.Models.Modules.Form
{
    public class ModelDisplayProperty : ModelProperty
	{
		public DisplayInfo DisplayInfo { get; init; }
		public string OriginName => DisplayInfo.OriginName;
		public string PropertyName => DisplayInfo.PropertyName;
		public bool ScaffoldItem => DisplayInfo.ScaffoldItem;
		public ReadonlyMode ReadonlyMode => DisplayInfo.ReadonlyMode;
		public VisibilityMode VisibilityMode => DisplayInfo.VisibilityMode;
		public bool CanRead => PropertyInfo.CanRead;
		public bool CanWrite => PropertyInfo.CanWrite;
		public virtual int Order
		{
			get => DisplayInfo.Order;
			set => DisplayInfo.Order = value;
		}
		public ModelDisplayProperty(Type modelType, PropertyInfo propertyInfo, DisplayInfo displayInfo) 
			: base(modelType, propertyInfo)
		{
			displayInfo.CheckArgument(nameof(displayInfo));

			DisplayInfo = displayInfo;
		}
	}
}

//MdEnd
