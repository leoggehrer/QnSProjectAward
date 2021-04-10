//@QnSGeneratedCode
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Radzen;
using QnSProjectAward.BlazorApp.Shared.Components.Persistence.Account;
using TMasterContract = QnSProjectAward.Contracts.Persistence.Account.IRole;
using TMaster = QnSProjectAward.BlazorApp.Models.Persistence.Account.Role;
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
        protected override string PageRoot => "Roles";
    }
}
