//@QnSGeneratedCode
using Microsoft.AspNetCore.Components;
using Radzen;
using System.Linq;
using System.Threading.Tasks;
using TContract = QnSProjectAward.Contracts.Business.Account.IIdentityUser;
using TModel = QnSProjectAward.BlazorApp.Models.Business.Account.IdentityUser;
namespace QnSProjectAward.BlazorApp.Shared.Components.Business.Account
{
    partial class IdentityUserDataGrid
    {
        [Parameter]
        public IdentityUserDataGridHandler DataGridHandler
        {
            get;
            set;
        }
        public override string ForPrefix => "IdentityUser";
    }
}
