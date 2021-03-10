//@QnSGeneratedCode
using TContract = QnSProjectAward.Contracts.Business.Account.IAppAccess;
using TModel = QnSProjectAward.BlazorApp.Models.Business.Account.AppAccess;
namespace QnSProjectAward.BlazorApp.Shared.Components.Business.Account
{
    public partial class AppAccessDataGridHandler : Modules.DataGrid.DataGridHandler<TContract, TModel>
    {
        public AppAccessDataGridHandler(Pages.ModelPage modelPage) : base(modelPage)
        {
        }
    }
}
