//@QnSGeneratedCode
using TContract = QnSProjectAward.Contracts.Business.Account.IIdentityUser;
using TModel = QnSProjectAward.BlazorApp.Models.Business.Account.IdentityUser;
namespace QnSProjectAward.BlazorApp.Shared.Components.Business.Account
{
    public partial class IdentityUserDataGridHandler : Modules.DataGrid.DataGridHandler<TContract, TModel>
    {
        public IdentityUserDataGridHandler(Pages.ModelPage modelPage) : base(modelPage)
        {
        }
    }
}
