//@QnSCodeCopy
//MdStart

using CommonBase.Extensions;
using System.Reflection;

namespace QnSProjectAward.BlazorApp.Models.Modules.Form
{
    public abstract partial class ModelMember : ModelDisplayProperty
    {
        public ModelObject Model { get; init; }

        public virtual object Value => PropertyInfo.GetValue(Model);

        public ModelMember(ModelObject model, PropertyInfo propertyInfo, DisplayInfo displayInfo)
            : base(model?.GetType(), propertyInfo, displayInfo)
        {
            model.CheckArgument(nameof(model));

            Model = model;
        }
    }
}
//MdEnd
