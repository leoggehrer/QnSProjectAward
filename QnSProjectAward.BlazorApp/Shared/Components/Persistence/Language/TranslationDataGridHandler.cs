//@QnSGeneratedCode
using TContract = QnSProjectAward.Contracts.Persistence.Language.ITranslation;
using TModel = QnSProjectAward.BlazorApp.Models.Persistence.Language.Translation;
namespace QnSProjectAward.BlazorApp.Shared.Components.Persistence.Language
{
    public partial class TranslationDataGridHandler : Modules.DataGrid.DataGridHandler<TContract, TModel>
    {
        public TranslationDataGridHandler(Pages.ModelPage modelPage) : base(modelPage)
        {
        }
    }
}
