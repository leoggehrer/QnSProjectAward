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
    public class GridModelMember : ModelDisplayProperty
    {
        public bool ListVisible => (DisplayInfo.VisibilityMode & VisibilityMode.ListView) > 0;
        public bool ListSortable => DisplayInfo.ListSortable;
        public bool ListFilterable => DisplayInfo.ListFilterable;
        public string ListWidth => DisplayInfo.ListWidth;
        public bool IsIdColumn => OriginName.EndsWith("Id")
                               && (PropertyInfo.PropertyType.Equals(typeof(int)) || PropertyInfo.PropertyType.Equals(typeof(int?)));
        public bool IsEnumColumn => PropertyInfo.PropertyType.IsEnum;
        public bool IsCheckBoxColumn => (PropertyInfo.PropertyType.Equals(typeof(bool)) || PropertyInfo.PropertyType.Equals(typeof(bool?)));

        public GridModelMember(Type modelType, PropertyInfo propertyInfo, DisplayInfo displayInfo)
          : base(modelType, propertyInfo, displayInfo)
        {
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
