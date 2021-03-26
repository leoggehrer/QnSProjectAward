//@QnSGeneratedCode
using QnSProjectAward.BlazorApp.Modules.DataGrid;
using TContract = QnSProjectAward.Contracts.Persistence.Account.IIdentityXRole;
using TModel = QnSProjectAward.BlazorApp.Models.Persistence.Account.IdentityXRole;
namespace QnSProjectAward.BlazorApp.Shared.Components.Persistence.Account
{
    public partial class IdentityXRoleDataGridHandler : Modules.DataGrid.DataGridHandler<TContract, TModel>
    {
        public IdentityXRoleDataGridHandler(Pages.ModelPage modelPage) : base(modelPage)
        {
        }
        public IdentityXRoleDataGridHandler(Pages.ModelPage modelPage, DataAccess<TContract> dataAccess) : base(modelPage, dataAccess)
        {
        }
    }
}
