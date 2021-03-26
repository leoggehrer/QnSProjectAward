//@QnSGeneratedCode
using QnSProjectAward.BlazorApp.Modules.DataGrid;
using TContract = QnSProjectAward.Contracts.Persistence.Account.IRole;
using TModel = QnSProjectAward.BlazorApp.Models.Persistence.Account.Role;
namespace QnSProjectAward.BlazorApp.Shared.Components.Persistence.Account
{
    public partial class RoleDataGridHandler : Modules.DataGrid.DataGridHandler<TContract, TModel>
    {
        public RoleDataGridHandler(Pages.ModelPage modelPage) : base(modelPage)
        {
        }
        public RoleDataGridHandler(Pages.ModelPage modelPage, DataAccess<TContract> dataAccess) : base(modelPage, dataAccess)
        {
        }
    }
}
