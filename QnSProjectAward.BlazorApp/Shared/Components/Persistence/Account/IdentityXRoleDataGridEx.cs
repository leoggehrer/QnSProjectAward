//@QnSCodeCopy
//MdStart
using CommonBase.Attributes;
using QnSProjectAward.BlazorApp.Modules.DataGrid;
using QnSProjectAward.Contracts.Persistence.Account;
using TModel = QnSProjectAward.BlazorApp.Models.Persistence.Account.IdentityXRole;

namespace QnSProjectAward.BlazorApp.Shared.Components.Persistence.Account
{
    partial class IdentityXRoleDataGrid
    {
        [DisposeField]
        protected DataGridAssociationItem<TModel, IRole> associationRole;
        [DisposeField]
        protected DataGridAssociationItem<TModel, IIdentity> associationIdentity;

        protected override void BeforeInitialized()
        {
            base.BeforeInitialized();

            associationRole = new DataGridAssociationItem<TModel, IRole>(this, DataGridHandler, nameof(TModel.RoleId), i => i.Designation);
            associationIdentity = new DataGridAssociationItem<TModel, IIdentity>(this, DataGridHandler, nameof(TModel.IdentityId), i => i.Name);
        }
    }
}
//MdEnd
