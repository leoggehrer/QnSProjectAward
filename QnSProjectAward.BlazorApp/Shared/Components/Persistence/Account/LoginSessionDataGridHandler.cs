//@QnSGeneratedCode
using TContract = QnSProjectAward.Contracts.Persistence.Account.ILoginSession;
using TModel = QnSProjectAward.BlazorApp.Models.Persistence.Account.LoginSession;
namespace QnSProjectAward.BlazorApp.Shared.Components.Persistence.Account
{
    public partial class LoginSessionDataGridHandler : Modules.DataGrid.DataGridHandler<TContract, TModel>
    {
        public LoginSessionDataGridHandler(Pages.ModelPage modelPage) : base(modelPage)
        {
        }
    }
}
