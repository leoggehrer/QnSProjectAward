//@QnSCodeCopy
//MdStart

using CommonBase.Attributes;
using CommonBase.Extensions;
using System;
using System.Linq;
using System.Reflection;

namespace QnSProjectAward.BlazorApp.Models.Modules.Form
{
    public partial class ModelProperty
    {
        protected Type ModelInterface { get; private set; }
        protected ContractPropertyInfoAttribute PropertyAttribute { get; private set; }

        public Type ModelType { get; init; }
        public PropertyInfo PropertyInfo { get; init; }
        public Type PropertyType => PropertyInfo.PropertyType;
        public ContentType ContentType => PropertyAttribute != null ? PropertyAttribute.ContentType : ContentType.Undefined;
        public string ModelName => ModelType.Name;
        public string FullName => $"{ModelName}.{Name}";
        public string Name => PropertyInfo.Name;
        public bool IsNullable => PropertyType.IsNullableType();
        public string FormatValue { get; set; }

        public bool Required => PropertyAttribute != null && PropertyAttribute.Required;
        public int MaxLength => PropertyAttribute != null ? PropertyAttribute.MaxLength : -1;
        public int MinLength => PropertyAttribute != null ? PropertyAttribute.MinLength : -1;
        public bool HasImplementation => PropertyAttribute != null && PropertyAttribute.HasImplementation;
        
        public string Description => PropertyAttribute != null ? PropertyAttribute.Description : string.Empty;
        public ModelProperty(Type modelType, PropertyInfo propertyInfo)
        {
            modelType.CheckArgument(nameof(modelType));
            propertyInfo.CheckArgument(nameof(propertyInfo));

            ModelType = modelType;
            PropertyInfo = propertyInfo;
            InitMetaData();
        }
        private void InitMetaData()
        {
            ModelInterface = ModelType.GetInterfaces()
                                      .FirstOrDefault(i => i.Name.Equals($"I{ModelType.Name}"));
            if (ModelInterface != null)
            {
                var pi = ModelInterface.GetAllInterfacePropertyInfos()
                                       .FirstOrDefault(i => i.Name.Equals(PropertyInfo.Name));

                if (pi != null)
                {
                    PropertyAttribute = pi.GetCustomAttribute<ContractPropertyInfoAttribute>();
                }
            }
        }
    }
}
//MdEnd
