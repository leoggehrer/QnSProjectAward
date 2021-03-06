//@QnSGeneratedCode
using CommonBase.Attributes;
using Microsoft.AspNetCore.Components;
using Radzen;
using System.Linq;
using System.Threading.Tasks;
using TContract = QnSProjectAward.Contracts.Persistence.Account.IRole;
using TModel = QnSProjectAward.BlazorApp.Models.Persistence.Account.Role;
namespace QnSProjectAward.BlazorApp.Shared.Components.Persistence.Account
{
    partial class RoleDataGrid
    {
        [Parameter]
        public RoleDataGridHandler DataGridHandler
        {
            get;
            set;
        }
        public override string ForPrefix => "Role";
    }
}
