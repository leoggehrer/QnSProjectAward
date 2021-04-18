//@QnSGeneratedCode
using CommonBase.Attributes;
using Microsoft.AspNetCore.Components;
using Radzen;
using System.Linq;
using System.Threading.Tasks;
using TContract = QnSProjectAward.Contracts.Persistence.Account.ILoginSession;
using TModel = QnSProjectAward.BlazorApp.Models.Persistence.Account.LoginSession;
namespace QnSProjectAward.BlazorApp.Shared.Components.Persistence.Account
{
    partial class LoginSessionDataGrid
    {
        [Parameter]
        public LoginSessionDataGridHandler DataGridHandler
        {
            get;
            set;
        }
        public override string ForPrefix => "LoginSession";
        [DisposeField]
        protected Modules.DataGrid.DataGridAssociationItem<TModel, QnSProjectAward.Contracts.Persistence.Account.IIdentity> dgaiIdentitiesByIdentityId;
        protected override void BeforeInitialized()
        {
            base.BeforeInitialized();
            bool handled = false;
            BeforeInitAssociations(ref handled);
            if (handled == false)
            {
                dgaiIdentitiesByIdentityId = new Modules.DataGrid.DataGridAssociationItem<TModel, QnSProjectAward.Contracts.Persistence.Account.IIdentity>(this, DataGridHandler, "IdentityId", i =>i.ToString());
            }
            AfterInitAssosiations();
        }
        partial void BeforeInitAssociations(ref bool handled);
        partial void AfterInitAssosiations();
    }
}
