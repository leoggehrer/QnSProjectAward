//@QnSCodeCopy
//MdStart

using QnSProjectAward.BlazorApp.Models.Modules.Form;
using System;
using System.Reflection;
using TModel = QnSProjectAward.BlazorApp.Models.ModelObject;

namespace QnSProjectAward.BlazorApp.Shared.Components
{
    public partial class DataGridColumnsComponent : DataGridCommonComponent
    {
        protected virtual Type GetModelType()
        {
            var handled = false;
            var result = default(Type);

            BeforeGetModelType(ref result, ref handled);
            if (handled == false)
            {
                result = typeof(TModel);
            }
            AfterGetModelType(result);
            return result;
        }
        partial void BeforeGetModelType(ref Type modelType, ref bool handled);
        partial void AfterGetModelType(Type modelType);

        public virtual GridModelMember CreateGridModelMember(Type modelType, PropertyInfo propertyInfo)
        {
            var displayInfo = GetOrCreateDisplayInfo(modelType, propertyInfo);

            return new GridModelMember(modelType, propertyInfo, displayInfo);
        }
    }
}
//MdEnd
