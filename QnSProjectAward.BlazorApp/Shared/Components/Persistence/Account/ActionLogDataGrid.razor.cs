//@QnSGeneratedCode
using Microsoft.AspNetCore.Components;
using Radzen;
using System.Linq;
using System.Threading.Tasks;
using TContract = QnSProjectAward.Contracts.Persistence.Account.IActionLog;
using TModel = QnSProjectAward.BlazorApp.Models.Persistence.Account.ActionLog;
namespace QnSProjectAward.BlazorApp.Shared.Components.Persistence.Account
{
    partial class ActionLogDataGrid
    {
        [Parameter]
        public ActionLogDataGridHandler DataGridHandler
        {
            get;
            set;
        }
        public override string ForPrefix => "ActionLog";
    }
}
