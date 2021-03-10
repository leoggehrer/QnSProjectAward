//@QnSGeneratedCode
using TContract = QnSProjectAward.Contracts.Persistence.Account.IUser;
using TModel = QnSProjectAward.BlazorApp.Models.Persistence.Account.User;
namespace QnSProjectAward.BlazorApp.Shared.Components.Persistence.Account
{
    public partial class UserDataGridHandler : Modules.DataGrid.DataGridHandler<TContract, TModel>
    {
        public UserDataGridHandler(Pages.ModelPage modelPage) : base(modelPage)
        {
        }
    }
}
