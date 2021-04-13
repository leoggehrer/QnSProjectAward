//@QnSGeneratedCode
using CommonBase.Attributes;
using Microsoft.AspNetCore.Components;
using Radzen;
using System.Linq;
using System.Threading.Tasks;
using TContract = QnSProjectAward.Contracts.Business.Account.IAppAccess;
using TModel = QnSProjectAward.BlazorApp.Models.Business.Account.AppAccess;
namespace QnSProjectAward.BlazorApp.Shared.Components.Business.Account
{
    partial class AppAccessDataGrid
    {
        [Parameter]
        public AppAccessDataGridHandler DataGridHandler
        {
            get;
            set;
        }
        public override string ForPrefix => "AppAccess";
    }
}
