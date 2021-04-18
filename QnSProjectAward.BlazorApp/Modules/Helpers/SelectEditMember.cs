//@QnSCodeCopy
//MdStart
using CommonBase.Extensions;
using QnSProjectAward.BlazorApp.Models;
using QnSProjectAward.BlazorApp.Models.Modules.Form;
using QnSProjectAward.BlazorApp.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace QnSProjectAward.BlazorApp.Modules.Helpers
{
    public class SelectEditMember<T> : EditModelMember where T : Contracts.IIdentifiable
    {
        public SelectEditMember(ModelPage page, ModelObject model, PropertyInfo propertyInfo, DisplayInfo displayInfo, Func<T, string> toText, Func<T, bool> selector)
            : base(page, model, propertyInfo, displayInfo)
        {
            var selectItems = new SelectItems<T>(page, toText, selector);

            if (propertyInfo.PropertyType.IsNullableType())
            {
                selectItems.Insert(0, new SelectItem
                {
                    Value = string.Empty,
                    Text = page.Translate("Select an entry..."),
                    Selected = false
                });
            }

            if (model is IdentityModel im)
            {
                if (selectItems.Any(e => e.Selected) == false)
                {
                    if (propertyInfo.PropertyType.IsNullableType())
                    {
                        EditValue = null;
                    }
                    else if (selectItems.Any())
                    {
                        EditValue = selectItems.ElementAt(0).Value;
                    }
                    else
                    {
                        EditValue = null;
                    }
                }
            }

            SelectItems = selectItems;
            EditCtrlType = Common.ControlType.Select;
        }
        public SelectEditMember(ModelPage page, ModelObject model, PropertyInfo propertyInfo, DisplayInfo displayInfo, IEnumerable<T> items, Func<T, string> toText, Func<T, bool> selector)
            : base(page, model, propertyInfo, displayInfo)
        {
            items.CheckArgument(nameof(items));

            var selectItems = new SelectItems<T>(items, toText, selector);

            if (propertyInfo.PropertyType.IsNullableType())
            {
                selectItems.Insert(0, new SelectItem
                {
                    Value = string.Empty,
                    Text = page.Translate("Select an entry..."),
                    Selected = false
                });
            }

            if (model is IdentityModel im)
            {
                if (selectItems.Any(e => e.Selected) == false)
                {
                    if (propertyInfo.PropertyType.IsNullableType())
                    {
                        EditValue = null;
                    }
                    else if (selectItems.Any())
                    {
                        EditValue = selectItems.ElementAt(0).Value;
                    }
                    else
                    {
                        EditValue = null;
                    }
                }
            }
            SelectItems = selectItems;
            EditCtrlType = Common.ControlType.Select;
        }
    }
}
//MdEnd
