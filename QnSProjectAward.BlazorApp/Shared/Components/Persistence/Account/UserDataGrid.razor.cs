//@QnSGeneratedCode
using Microsoft.AspNetCore.Components;
using Radzen;
using System.Linq;
using System.Threading.Tasks;
using TContract = QnSProjectAward.Contracts.Persistence.Account.IUser;
using TModel = QnSProjectAward.BlazorApp.Models.Persistence.Account.User;
namespace QnSProjectAward.BlazorApp.Shared.Components.Persistence.Account
{
    partial class UserDataGrid
    {
        [Parameter]
        public UserDataGridHandler DataGridHandler
        {
            get;
            set;
        }
        public override string ForPrefix => "User";
    }
}
