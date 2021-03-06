//@QnSGeneratedCode
using Microsoft.AspNetCore.Components;
using TModel = QnSProjectAward.BlazorApp.Models.Persistence.Data.BinaryData;
namespace QnSProjectAward.BlazorApp.Shared.Components.Persistence.Data
{
    partial class BinaryDataDataGridDetail
    {
        [Parameter]
        public BinaryDataDataGridHandler MasterDataGridHandler
        {
            get;
            set;
        }
        public override string ForPrefix => "BinaryData";
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
