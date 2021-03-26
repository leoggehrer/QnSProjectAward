//@QnSGeneratedCode
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Radzen;
using QnSProjectAward.BlazorApp.Modules.DataGrid;
using QnSProjectAward.BlazorApp.Shared.Components.Persistence.Account;
using TContract = QnSProjectAward.Contracts.Persistence.Account.IIdentityXRole;
using TModel = QnSProjectAward.BlazorApp.Models.Persistence.Account.IdentityXRole;
namespace QnSProjectAward.BlazorApp.Pages.Persistence.Account
{
    partial class IdentityXRolePage
    {
        [Inject]
        protected DialogService DialogService
        {
            get;
            private set;
        }
        protected IdentityXRoleDataGridHandler DataGridHandler
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
                DataGridHandler = new IdentityXRoleDataGridHandler(this, new DataAdapterAccess<TContract>(AdapterAccess));
                InitDataGridHandler(DataGridHandler);
            }
            AfterFirstRender();
            return base.OnFirstRenderAsync();
        }
        partial void BeforeFirstRender(ref bool handled);
        partial void AfterFirstRender();
    }
}
