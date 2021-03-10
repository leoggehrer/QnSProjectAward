//@QnSGeneratedCode
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Radzen;
using QnSProjectAward.BlazorApp.Shared.Components.Persistence.Account;
using TContract = QnSProjectAward.Contracts.Persistence.Account.IRole;
using TModel = QnSProjectAward.BlazorApp.Models.Persistence.Account.Role;
namespace QnSProjectAward.BlazorApp.Pages.Persistence.Account
{
    partial class RolePage
    {
        [Inject]
        protected DialogService DialogService
        {
            get;
            private set;
        }
        protected RoleDataGridHandler DataGridHandler
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
            DataGridHandler = new RoleDataGridHandler(this);
            DataGridHandler.PageSize = Settings.GetValueTyped<int>($"{ComponentName}.{nameof(DataGridHandler.PageSize)}", DataGridHandler.PageSize);
            return base.OnFirstRenderAsync();
        }
    }
}