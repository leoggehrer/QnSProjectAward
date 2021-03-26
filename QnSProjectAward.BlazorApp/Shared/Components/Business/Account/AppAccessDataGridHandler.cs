//@QnSGeneratedCode
using QnSProjectAward.BlazorApp.Modules.DataGrid;
using TContract = QnSProjectAward.Contracts.Business.Account.IAppAccess;
using TModel = QnSProjectAward.BlazorApp.Models.Business.Account.AppAccess;
namespace QnSProjectAward.BlazorApp.Shared.Components.Business.Account
{
    public partial class AppAccessDataGridHandler : Modules.DataGrid.DataGridHandler<TContract, TModel>
    {
        public AppAccessDataGridHandler(Pages.ModelPage modelPage) : base(modelPage)
        {
        }
        public AppAccessDataGridHandler(Pages.ModelPage modelPage, DataAccess<TContract> dataAccess) : base(modelPage, dataAccess)
        {
        }
    }
}
