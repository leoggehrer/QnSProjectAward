//@QnSGeneratedCode
using TContract = QnSProjectAward.Contracts.Persistence.Account.IActionLog;
using TModel = QnSProjectAward.BlazorApp.Models.Persistence.Account.ActionLog;
namespace QnSProjectAward.BlazorApp.Shared.Components.Persistence.Account
{
    public partial class ActionLogDataGridHandler : Modules.DataGrid.DataGridHandler<TContract, TModel>
    {
        public ActionLogDataGridHandler(Pages.ModelPage modelPage) : base(modelPage)
        {
        }
    }
}
