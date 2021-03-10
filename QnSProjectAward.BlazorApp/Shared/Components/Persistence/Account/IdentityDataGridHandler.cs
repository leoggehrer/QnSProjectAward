//@QnSGeneratedCode
using TContract = QnSProjectAward.Contracts.Persistence.Account.IIdentity;
using TModel = QnSProjectAward.BlazorApp.Models.Persistence.Account.Identity;
namespace QnSProjectAward.BlazorApp.Shared.Components.Persistence.Account
{
    public partial class IdentityDataGridHandler : Modules.DataGrid.DataGridHandler<TContract, TModel>
    {
        public IdentityDataGridHandler(Pages.ModelPage modelPage) : base(modelPage)
        {
        }
    }
}
