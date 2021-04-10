//@QnSCodeCopy
//MdStart

using System;
using System.Reflection;

namespace QnSProjectAward.BlazorApp.Models.Modules.Form
{
    public partial class DisplayModelMember : ModelMember
    {
        public virtual bool Visible => (DisplayInfo.VisibilityMode & Common.VisibilityMode.ListDetailView) > 0;
        public virtual bool IsTextArea => DisplayValue.Length > 50 || DisplayValue.Contains(Environment.NewLine);

        public Func<object, string> ToDisplayValue = v => v != null ? v.ToString() : string.Empty;
        public virtual string DisplayValue => ToDisplayValue?.Invoke(Value);
        public DisplayModelMember(ModelObject model, PropertyInfo propertyInfo, DisplayInfo displayInfo) 
            : base(model, propertyInfo, displayInfo)
        {
        }
    }
}
//MdEnd
