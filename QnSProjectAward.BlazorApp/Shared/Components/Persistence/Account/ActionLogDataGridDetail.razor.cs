//@QnSGeneratedCode
using Microsoft.AspNetCore.Components;
using TModel = QnSProjectAward.BlazorApp.Models.Persistence.Account.ActionLog;
namespace QnSProjectAward.BlazorApp.Shared.Components.Persistence.Account
{
    partial class ActionLogDataGridDetail
    {
        [Parameter]
        public ActionLogDataGridHandler MasterDataGridHandler
        {
            get;
            set;
        }
        public override string ForPrefix => "ActionLog";
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