//@QnSGeneratedCode
using Microsoft.AspNetCore.Components;
using TModel = QnSProjectAward.BlazorApp.Models.Business.Account.IdentityUser;
namespace QnSProjectAward.BlazorApp.Shared.Components.Business.Account
{
    partial class IdentityUserDataGridDetail
    {
        [Parameter]
        public IdentityUserDataGridHandler MasterDataGridHandler
        {
            get;
            set;
        }
        public override string ForPrefix => "IdentityUser";
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
