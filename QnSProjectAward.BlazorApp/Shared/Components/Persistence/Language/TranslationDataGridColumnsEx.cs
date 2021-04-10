//@QnSCodeCopy
//MdStart
using QnSProjectAward.BlazorApp.Models.Modules.Form;

namespace QnSProjectAward.BlazorApp.Shared.Components.Persistence.Language
{
    partial class TranslationDataGridColumns
    {
        protected override void InitDisplayInfoContainer(DisplayInfoContainer displayProperties)
        {
            base.InitDisplayInfoContainer(displayProperties);

            displayProperties.AddOrSet(nameof(Models.Persistence.Language.Translation.State), dp =>
            {
                dp.IsModelItem = true;
                dp.Order = 1_000;
            }); ;
        }
    }
}
//MdEnd
