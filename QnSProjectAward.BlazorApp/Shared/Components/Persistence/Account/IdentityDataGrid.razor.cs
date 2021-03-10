//@QnSGeneratedCode
using Microsoft.AspNetCore.Components;
using Radzen;
using System.Linq;
using System.Threading.Tasks;
using TContract = QnSProjectAward.Contracts.Persistence.Account.IIdentity;
using TModel = QnSProjectAward.BlazorApp.Models.Persistence.Account.Identity;
namespace QnSProjectAward.BlazorApp.Shared.Components.Persistence.Account
{
    partial class IdentityDataGrid
    {
        [Parameter]
        public IdentityDataGridHandler DataGridHandler
        {
            get;
            set;
        }
        public override string ForPrefix => "Identity";
    }
}
