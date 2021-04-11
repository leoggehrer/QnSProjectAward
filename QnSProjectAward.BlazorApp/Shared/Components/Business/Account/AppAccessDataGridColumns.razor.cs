//@QnSGeneratedCode
using Microsoft.AspNetCore.Components;
using Radzen;
using System;
using System.Linq;
using System.Threading.Tasks;
using TContract = QnSProjectAward.Contracts.Business.Account.IAppAccess;
using TModel = QnSProjectAward.BlazorApp.Models.Business.Account.AppAccess;
namespace QnSProjectAward.BlazorApp.Shared.Components.Business.Account
{
    partial class AppAccessDataGridColumns
    {
        [Parameter]
        public AppAccessDataGridHandler DataGridHandler
        {
            get;
            set;
        }
        public override string ForPrefix => "AppAccess";
        protected override Task OnFirstRenderAsync()
        {
            DataGridHandler.ModelItems = DataGridHandler.ModelItems.Union(GetAllDisplayInfos().Where(e => e.ScaffoldItem && (e.VisibilityMode & Models.Modules.Common.VisibilityMode.ListView) > 0 && e.IsModelItem).Select(e => e.PropertyName)).Distinct().ToArray();
            return base.OnFirstRenderAsync();
        }
        protected override Type GetModelType()
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
        static partial void BeforeGetModelType(ref Type modelType, ref bool handled);
        static partial void AfterGetModelType(Type modelType);
    }
}
