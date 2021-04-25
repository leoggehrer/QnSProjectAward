//@QnSGeneratedCode
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Radzen;
using QnSProjectAward.BlazorApp.Shared.Components.Persistence.Account;
using TMasterContract = QnSProjectAward.Contracts.Persistence.Account.IActionLog;
using TMaster = QnSProjectAward.BlazorApp.Models.Persistence.Account.ActionLog;
namespace QnSProjectAward.BlazorApp.Pages.Persistence.Account
{
    partial class ActionLogPage
    {
        [Inject]
        protected DialogService DialogService
        {
            get;
            private set;
        }
        protected override string PageRoot => "ActionLogs";
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
