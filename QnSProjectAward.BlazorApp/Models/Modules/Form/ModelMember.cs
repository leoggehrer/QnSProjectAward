//@QnSCodeCopy
//MdStart

using CommonBase.Extensions;
using System.Reflection;

namespace QnSProjectAward.BlazorApp.Models.Modules.Form
{
    public abstract partial class ModelMember : ModelProperty
    {
        private int order = -1;

        public ModelObject Model { get; init; }
        public DisplayProperty DisplayInfo { get; init; }
        public bool ScaffoldItem => DisplayInfo.ScaffoldItem;

        public int Order 
        {
            get => order < 0 ? DisplayInfo.Order : order; 
            set => order = value; 
        }
        public virtual object Value => PropertyInfo.GetValue(Model);

        public ModelMember(ModelObject model, PropertyInfo propertyInfo, DisplayProperty displayProperty)
            : base(model?.GetType(), propertyInfo)
        {
            model.CheckArgument(nameof(model));
            displayProperty.CheckArgument(nameof(displayProperty));

            Model = model;
            DisplayInfo = displayProperty;
        }
    }
}
//MdEnd
