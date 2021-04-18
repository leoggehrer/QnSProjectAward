//@QnSGeneratedCode
using CommonBase.Attributes;
using Microsoft.AspNetCore.Components;
using Radzen;
using System.Linq;
using System.Threading.Tasks;
using TContract = QnSProjectAward.Contracts.Persistence.Account.IIdentityXRole;
using TModel = QnSProjectAward.BlazorApp.Models.Persistence.Account.IdentityXRole;
namespace QnSProjectAward.BlazorApp.Shared.Components.Persistence.Account
{
    partial class IdentityXRoleDataGrid
    {
        [Parameter]
        public IdentityXRoleDataGridHandler DataGridHandler
        {
            get;
            set;
        }
        public override string ForPrefix => "IdentityXRole";
        [DisposeField]
        protected Modules.DataGrid.DataGridAssociationItem<TModel, QnSProjectAward.Contracts.Persistence.Account.IIdentity> dgaiIdentitiesByIdentityId;
        [DisposeField]
        protected Modules.DataGrid.DataGridAssociationItem<TModel, QnSProjectAward.Contracts.Persistence.Account.IRole> dgaiRolesByRoleId;
        protected override void BeforeInitialized()
        {
            base.BeforeInitialized();
            bool handled = false;
            BeforeInitAssociations(ref handled);
            if (handled == false)
            {
                dgaiIdentitiesByIdentityId = new Modules.DataGrid.DataGridAssociationItem<TModel, QnSProjectAward.Contracts.Persistence.Account.IIdentity>(this, DataGridHandler, "IdentityId", i =>i.ToString());
                dgaiRolesByRoleId = new Modules.DataGrid.DataGridAssociationItem<TModel, QnSProjectAward.Contracts.Persistence.Account.IRole>(this, DataGridHandler, "RoleId", i =>i.ToString());
            }
            AfterInitAssosiations();
        }
        partial void BeforeInitAssociations(ref bool handled);
        partial void AfterInitAssosiations();
    }
}
