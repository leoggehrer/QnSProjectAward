//@QnSGeneratedCode
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Radzen;
using QnSProjectAward.BlazorApp.Modules.DataGrid;
using QnSProjectAward.BlazorApp.Shared.Components.Business.Account;
using TContract = QnSProjectAward.Contracts.Business.Account.IAppAccess;
using TModel = QnSProjectAward.BlazorApp.Models.Business.Account.AppAccess;
namespace QnSProjectAward.BlazorApp.Pages.Business.Account
{
    partial class AppAccessPage
    {
        [Inject]
        protected DialogService DialogService
        {
            get;
            private set;
        }
        protected AppAccessDataGridHandler DataGridHandler
        {
            get;
            private set;
        }
        protected Contracts.Client.IAdapterAccess<TContract> AdapterAccess
        {
            get;
            private set;
        }
        protected override Task OnFirstRenderAsync()
        {
            bool handled = false;
            BeforeFirstRender(ref handled);
            if (handled == false)
            {
                AdapterAccess = ServiceAdapter.Create<TContract>();
                DataGridHandler = new AppAccessDataGridHandler(this, new DataAdapterAccess<TContract>(AdapterAccess));
                InitDataGridHandler(DataGridHandler);
            }
            AfterFirstRender();
            return base.OnFirstRenderAsync();
        }
        partial void BeforeFirstRender(ref bool handled);
        partial void AfterFirstRender();
    }
}
