//@QnSGeneratedCode
using QnSProjectAward.BlazorApp.Modules.DataGrid;
using TContract = QnSProjectAward.Contracts.Persistence.Account.IActionLog;
using TModel = QnSProjectAward.BlazorApp.Models.Persistence.Account.ActionLog;
namespace QnSProjectAward.BlazorApp.Shared.Components.Persistence.Account
{
    public partial class ActionLogDataGridHandler : Modules.DataGrid.DataGridHandler<TContract, TModel>
    {
        public ActionLogDataGridHandler(Pages.ModelPage modelPage) : base(modelPage)
        {
        }
        public ActionLogDataGridHandler(Pages.ModelPage modelPage, DataAccess<TContract> dataAccess) : base(modelPage, dataAccess)
        {
        }
    }
}
