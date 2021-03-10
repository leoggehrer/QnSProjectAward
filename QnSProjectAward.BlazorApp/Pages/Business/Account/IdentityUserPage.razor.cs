//@QnSGeneratedCode
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Radzen;
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
            DataGridHandler = new IdentityUserDataGridHandler(this);
            DataGridHandler.PageSize = Settings.GetValueTyped<int>($"{ComponentName}.{nameof(DataGridHandler.PageSize)}", DataGridHandler.PageSize);
            return base.OnFirstRenderAsync();
        }
    }
}
