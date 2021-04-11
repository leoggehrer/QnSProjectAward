using CommonBase.Attributes;
using QnSProjectAward.BlazorApp.Modules.DataGrid;
using QnSProjectAward.Contracts.Persistence.App;
using TModel = QnSProjectAward.BlazorApp.Models.Persistence.App.Project;

namespace QnSProjectAward.BlazorApp.Shared.Components.Persistence.App
{
    partial class ProjectDataGrid
    {
        [DisposeField]
        protected DataGridAssociationItem<TModel, IAward> associationAward;

        protected override void BeforeInitialized()
        {
            base.BeforeInitialized();

            associationAward = new DataGridAssociationItem<TModel, IAward>(this, DataGridHandler, nameof(TModel.AwardId), i => i.Title);
        }
    }
}
