//@QnSCodeCopy
//MdStart
using System;

namespace QnSProjectAward.BlazorApp.Shared.Components.Business.Account
{
    partial class AppAccessDataGridColumns
    {
        static partial void BeforeGetModelType(ref Type modelType, ref bool handled)
        {
            handled = true;
            modelType = typeof(Models.Business.Account.AppAccess);
        }
    }
}
//MdEnd
