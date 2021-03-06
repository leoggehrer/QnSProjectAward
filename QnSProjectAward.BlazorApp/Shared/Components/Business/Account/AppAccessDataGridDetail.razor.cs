//@QnSGeneratedCode
using Microsoft.AspNetCore.Components;
using TModel = QnSProjectAward.BlazorApp.Models.Business.Account.AppAccess;
namespace QnSProjectAward.BlazorApp.Shared.Components.Business.Account
{
    partial class AppAccessDataGridDetail
    {
        [Parameter]
        public AppAccessDataGridHandler MasterDataGridHandler
        {
            get;
            set;
        }
        public override string ForPrefix => "AppAccess";
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
