//@QnSGeneratedCode
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Radzen;
using QnSProjectAward.BlazorApp.Shared.Components.Persistence.Account;
using TMasterContract = QnSProjectAward.Contracts.Persistence.Account.ILoginSession;
using TMaster = QnSProjectAward.BlazorApp.Models.Persistence.Account.LoginSession;
namespace QnSProjectAward.BlazorApp.Pages.Persistence.Account
{
    partial class LoginSessionPage
    {
        [Inject]
        protected DialogService DialogService
        {
            get;
            private set;
        }
        protected override string PageRoot => "LoginSessions";
        private string[] detailNames;
        protected override string[] DetailNames
        {
            get
            {
                return detailNames ??= new string[]
                {
                }
                ;
            }
        }
    }
}
