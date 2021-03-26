//@QnSGeneratedCode
using QnSProjectAward.BlazorApp.Modules.DataGrid;
using TContract = QnSProjectAward.Contracts.Persistence.Data.IBinaryData;
using TModel = QnSProjectAward.BlazorApp.Models.Persistence.Data.BinaryData;
namespace QnSProjectAward.BlazorApp.Shared.Components.Persistence.Data
{
    public partial class BinaryDataDataGridHandler : Modules.DataGrid.DataGridHandler<TContract, TModel>
    {
        public BinaryDataDataGridHandler(Pages.ModelPage modelPage) : base(modelPage)
        {
        }
        public BinaryDataDataGridHandler(Pages.ModelPage modelPage, DataAccess<TContract> dataAccess) : base(modelPage, dataAccess)
        {
        }
    }
}
