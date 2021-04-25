//@QnSGeneratedCode
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Radzen;
using QnSProjectAward.BlazorApp.Shared.Components.Persistence.Language;
using TMasterContract = QnSProjectAward.Contracts.Persistence.Language.ITranslation;
using TMaster = QnSProjectAward.BlazorApp.Models.Persistence.Language.Translation;
namespace QnSProjectAward.BlazorApp.Pages.Persistence.Language
{
    partial class TranslationPage
    {
        [Inject]
        protected DialogService DialogService
        {
            get;
            private set;
        }
        protected override string PageRoot => "Translations";
        private string[] detailNames;
        protected override string[] DetailNames
        {
            get
            {
                return detailNames ??= new string[]
                {
                }
                ;
            }
        }
    }
}
