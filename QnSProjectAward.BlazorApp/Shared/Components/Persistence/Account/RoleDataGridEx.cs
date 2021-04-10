//@QnSCodeCopy
using QnSProjectAward.BlazorApp.Models.Modules.Form;

namespace QnSProjectAward.BlazorApp.Shared.Components.Persistence.Account
{
    partial class RoleDataGrid
    {
        protected override void InitDisplayInfoContainer(DisplayInfoContainer displayProperties)
        {
            base.InitDisplayInfoContainer(displayProperties);

            displayProperties.AddOrSet(new DisplayInfo("Assigned") { ScaffoldItem = false });
        }
    }
}
