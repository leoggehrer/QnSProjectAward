//@QnSGeneratedCode
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Radzen;
using QnSProjectAward.BlazorApp.Shared.Components.Persistence.Account;
using TMasterContract = QnSProjectAward.Contracts.Persistence.Account.IUser;
using TMaster = QnSProjectAward.BlazorApp.Models.Persistence.Account.User;
namespace QnSProjectAward.BlazorApp.Pages.Persistence.Account
{
    partial class UserPage
    {
        [Inject]
        protected DialogService DialogService
        {
            get;
            private set;
        }
        protected override string PageRoot => "Users";
    }
}
