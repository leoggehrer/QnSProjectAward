//@QnSCodeCopy
//MdStart
using QnSProjectAward.BlazorApp.Models.Modules.Form;

namespace QnSProjectAward.BlazorApp.Shared.Components.Persistence.Configuration
{
    partial class SettingDataGridColumns
    {
        protected override void InitDisplayInfoContainer(DisplayInfoContainer displayInfos)
        {
            base.InitDisplayInfoContainer(displayInfos);

            displayInfos.AddOrSet(nameof(Models.Persistence.Configuration.Setting.State), dp =>
            {
                dp.IsModelItem = true;
                dp.Order = 1_000;
            }); ;
        }
    }
}
//MdEnd
