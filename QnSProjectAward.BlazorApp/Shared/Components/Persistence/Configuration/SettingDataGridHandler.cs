//@QnSGeneratedCode
using QnSProjectAward.BlazorApp.Modules.DataGrid;
using TContract = QnSProjectAward.Contracts.Persistence.Configuration.ISetting;
using TModel = QnSProjectAward.BlazorApp.Models.Persistence.Configuration.Setting;
namespace QnSProjectAward.BlazorApp.Shared.Components.Persistence.Configuration
{
    public partial class SettingDataGridHandler : Modules.DataGrid.DataGridHandler<TContract, TModel>
    {
        public SettingDataGridHandler(Pages.ModelPage modelPage) : base(modelPage)
        {
        }
        public SettingDataGridHandler(Pages.ModelPage modelPage, DataAccess<TContract> dataAccess) : base(modelPage, dataAccess)
        {
        }
    }
}
