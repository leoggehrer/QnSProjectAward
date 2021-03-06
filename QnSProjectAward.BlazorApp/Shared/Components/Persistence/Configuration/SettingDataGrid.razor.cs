//@QnSGeneratedCode
using CommonBase.Attributes;
using Microsoft.AspNetCore.Components;
using Radzen;
using System.Linq;
using System.Threading.Tasks;
using TContract = QnSProjectAward.Contracts.Persistence.Configuration.ISetting;
using TModel = QnSProjectAward.BlazorApp.Models.Persistence.Configuration.Setting;
namespace QnSProjectAward.BlazorApp.Shared.Components.Persistence.Configuration
{
    partial class SettingDataGrid
    {
        [Parameter]
        public SettingDataGridHandler DataGridHandler
        {
            get;
            set;
        }
        public override string ForPrefix => "Setting";
    }
}
