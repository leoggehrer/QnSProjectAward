//@QnSGeneratedCode
using Microsoft.AspNetCore.Components;
using TModel = QnSProjectAward.BlazorApp.Models.Persistence.Account.IdentityXRole;
namespace QnSProjectAward.BlazorApp.Shared.Components.Persistence.Account
{
    partial class IdentityXRoleDataGridDetail
    {
        [Parameter]
        public IdentityXRoleDataGridHandler MasterDataGridHandler
        {
            get;
            set;
        }
        public override string ForPrefix => "IdentityXRole";
        protected Pages.ModelPage ModelPage => MasterDataGridHandler.ModelPage;
        private TModel parentModel;
        protected TModel ParentModel
        {
            get
            {
                if (parentModel == null)
                {
                    parentModel = MasterDataGridHandler.ExpandModel;
                }
                return parentModel;
            }
        }
    }
}
