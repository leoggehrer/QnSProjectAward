//@QnSGeneratedCode
using QnSProjectAward.BlazorApp.Modules.DataGrid;
using TContract = QnSProjectAward.Contracts.Persistence.Account.ILoginSession;
using TModel = QnSProjectAward.BlazorApp.Models.Persistence.Account.LoginSession;
namespace QnSProjectAward.BlazorApp.Shared.Components.Persistence.Account
{
    public partial class LoginSessionDataGridHandler : Modules.DataGrid.DataGridHandler<TContract, TModel>
    {
        public LoginSessionDataGridHandler(Pages.ModelPage modelPage) : base(modelPage)
        {
        }
        public LoginSessionDataGridHandler(Pages.ModelPage modelPage, DataAccess<TContract> dataAccess) : base(modelPage, dataAccess)
        {
        }
    }
}
