//@QnSGeneratedCode
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Radzen;
using QnSProjectAward.BlazorApp.Modules.DataGrid;
using QnSProjectAward.BlazorApp.Shared.Components.Business.Account;
using TContract = QnSProjectAward.Contracts.Business.Account.IIdentityUser;
using TModel = QnSProjectAward.BlazorApp.Models.Business.Account.IdentityUser;
namespace QnSProjectAward.BlazorApp.Pages.Business.Account
{
    partial class IdentityUserPage
    {
        [Inject]
        protected DialogService DialogService
        {
            get;
            private set;
        }
        protected IdentityUserDataGridHandler DataGridHandler
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
                DataGridHandler = new IdentityUserDataGridHandler(this, new DataAdapterAccess<TContract>(AdapterAccess));
                InitDataGridHandler(DataGridHandler);
            }
            AfterFirstRender();
            return base.OnFirstRenderAsync();
        }
        partial void BeforeFirstRender(ref bool handled);
        partial void AfterFirstRender();
    }
}
