//@QnSGeneratedCode
using Microsoft.AspNetCore.Components;
using TModel = QnSProjectAward.BlazorApp.Models.Persistence.Account.LoginSession;
namespace QnSProjectAward.BlazorApp.Shared.Components.Persistence.Account
{
    partial class LoginSessionDataGridDetail
    {
        [Parameter]
        public LoginSessionDataGridHandler MasterDataGridHandler
        {
            get;
            set;
        }
        public override string ForPrefix => "LoginSession";
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
