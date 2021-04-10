//@QnSCodeCopy
using QnSProjectAward.BlazorApp.Models.Modules.Form;
using QnSProjectAward.BlazorApp.Models.Persistence.Account;

namespace QnSProjectAward.BlazorApp.Shared.Components.Business.Account
{
    public partial class AppAccessDataGrid
    {
        protected override void InitDisplayInfoContainer(DisplayInfoContainer displayProperties)
        {
            base.InitDisplayInfoContainer(displayProperties);

            displayProperties.AddOrSet(new DisplayInfo(nameof(Identity), nameof(Identity.Guid)) { VisibilityMode = Models.Modules.Common.VisibilityMode.DetailCreateUpdateDeleteView });
            displayProperties.AddOrSet(new DisplayInfo(nameof(Identity), nameof(Identity.Password)) { VisibilityMode = Models.Modules.Common.VisibilityMode.DetailCreateUpdateDeleteView });
        }
    }
}
