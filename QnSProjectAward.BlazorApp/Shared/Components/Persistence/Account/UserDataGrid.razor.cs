//@QnSGeneratedCode
using CommonBase.Attributes;
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
        [DisposeField]
        protected Modules.DataGrid.DataGridAssociationItem<TModel, QnSProjectAward.Contracts.Persistence.Account.IIdentity> associationIdentity;
        protected override void BeforeInitialized()
        {
            base.BeforeInitialized();
            bool handled = false;
            BeforeInitAssociations(ref handled);
            if (handled == false)
            {
                associationIdentity = new Modules.DataGrid.DataGridAssociationItem<TModel, QnSProjectAward.Contracts.Persistence.Account.IIdentity>(this, DataGridHandler, "IdentityId", i =>i.ToString());
            }
            AfterInitAssosiations();
        }
        partial void BeforeInitAssociations(ref bool handled);
        partial void AfterInitAssosiations();
    }
}
