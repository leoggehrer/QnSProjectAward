//@QnSCodeCopy
using QnSProjectAward.BlazorApp.Models.Modules.Form;

namespace QnSProjectAward.BlazorApp.Shared.Components.Persistence.Account
{
    partial class RoleDataGrid
    {
        protected override void InitDisplayProperties(DisplayPropertyContainer displayProperties)
        {
            base.InitDisplayProperties(displayProperties);

            displayProperties.AddOrSet(new DisplayProperty("Assigned") { ScaffoldItem = false });
        }
    }
}
