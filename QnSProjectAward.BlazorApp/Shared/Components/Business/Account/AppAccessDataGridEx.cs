//QnSBaseCode
using QnSProjectAward.BlazorApp.Models.Modules.Form;
using QnSProjectAward.BlazorApp.Models.Persistence.Account;

namespace QnSProjectAward.BlazorApp.Shared.Components.Business.Account
{
    public partial class AppAccessDataGrid
    {
        protected override void InitDisplayProperties(DisplayPropertyContainer displayProperties)
        {
            base.InitDisplayProperties(displayProperties);

            displayProperties.Add(new DisplayProperty(nameof(Identity), nameof(Identity.Guid)) { ListVisible = false });
            displayProperties.Add(new DisplayProperty(nameof(Identity), nameof(Identity.Password)) { ListVisible = false });
        }
    }
}
