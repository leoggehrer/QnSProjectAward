//@QnSGeneratedCode
using Microsoft.AspNetCore.Components;
using TModel = QnSProjectAward.BlazorApp.Models.Persistence.Account.Role;
namespace QnSProjectAward.BlazorApp.Shared.Components.Persistence.Account
{
    partial class RoleDataGridDetail
    {
        [Parameter]
        public RoleDataGridHandler MasterDataGridHandler
        {
            get;
            set;
        }
        public override string ForPrefix => "Role";
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
