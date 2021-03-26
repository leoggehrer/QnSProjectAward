//@QnSCodeCopy
//MdStart

using CommonBase.Extensions;
using QnSProjectAward.BlazorApp.Models.Modules.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace QnSProjectAward.BlazorApp.Models.Modules.Form
{
    public class GridModelColumn : ModelProperty
    {
        public DisplayProperty DisplayInfo { get; init; }
        public string OriginName => DisplayInfo.OriginName;
        public string PropertyName => DisplayInfo.PropertyName;
        public bool ScaffoldItem => DisplayInfo.ScaffoldItem;
        public ReadonlyMode ReadonlyMode => DisplayInfo.ReadonlyMode;
        public VisibilityMode VisibilityMode => DisplayInfo.VisibilityMode;
        public bool ListVisible => (DisplayInfo.VisibilityMode & VisibilityMode.ListView) > 0;
        public bool ListSortable => DisplayInfo.ListSortable;
        public bool ListFilterable => DisplayInfo.ListFilterable;
        public bool CanRead => PropertyInfo.CanRead;
        public bool CanWrite => PropertyInfo.CanWrite;
        public int Order => DisplayInfo.Order;
        public string ListWidth => DisplayInfo.ListWidth;
        public bool IsIdColumn => OriginName.EndsWith("Id")
                               && (PropertyInfo.PropertyType.Equals(typeof(int)) || PropertyInfo.PropertyType.Equals(typeof(int?)));
        public bool IsEnumColumn => PropertyInfo.PropertyType.IsEnum;
        public bool IsCheckBoxColumn => (PropertyInfo.PropertyType.Equals(typeof(bool)) || PropertyInfo.PropertyType.Equals(typeof(bool?)));

        public GridModelColumn(Type modelType, PropertyInfo propertyInfo, DisplayProperty displayProperty)
          : base(modelType, propertyInfo)
        {
            displayProperty.CheckArgument(nameof(displayProperty));

            DisplayInfo = displayProperty;
        }
        public string ToDisplay(object model, object value) => DisplayInfo.ToDisplay(model, value);
        public string GetFooterText(string propertyName) => DisplayInfo.GetFooterText(propertyName);

        #region Enumerations
        public IEnumerable<SelectItem> CreateEnumSelectItems()
        {
            return CreateEnumSelectItems(s => s);
        }
        public IEnumerable<SelectItem> CreateEnumSelectItems(Func<string, string> translate)
        {
            var result = new List<SelectItem>();

            foreach (var item in Enum.GetValues(PropertyInfo.PropertyType).OfType<Enum>())
            {
                result.Add(new SelectItem { Value = $"{item.Description()}", Text = translate?.Invoke(item.Description()) });
            }
            return result.OrderBy(e => e.Text);
        }
        #endregion Enumerations
    }
}

//MdEnd
