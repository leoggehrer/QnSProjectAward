//@QnSGeneratedCode
using Microsoft.AspNetCore.Components;
using Radzen;
using System.Linq;
using System.Threading.Tasks;
using TContract = QnSProjectAward.Contracts.Persistence.Language.ITranslation;
using TModel = QnSProjectAward.BlazorApp.Models.Persistence.Language.Translation;
namespace QnSProjectAward.BlazorApp.Shared.Components.Persistence.Language
{
    partial class TranslationDataGrid
    {
        [Parameter]
        public TranslationDataGridHandler DataGridHandler
        {
            get;
            set;
        }
        public override string ForPrefix => "Translation";
    }
}
