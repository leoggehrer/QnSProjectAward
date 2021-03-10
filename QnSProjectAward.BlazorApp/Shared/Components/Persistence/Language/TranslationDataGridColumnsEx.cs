//@QnSCodeCopy
//MdStart
using QnSProjectAward.BlazorApp.Models.Modules.Form;

namespace QnSProjectAward.BlazorApp.Shared.Components.Persistence.Language
{
    partial class TranslationDataGridColumns
    {
        protected override void InitDisplayProperties(DisplayPropertyContainer displayProperties)
        {
            base.InitDisplayProperties(displayProperties);

            displayProperties.Add(new DisplayProperty(nameof(Models.Persistence.Language.Translation.State))
            {
                Order = 1_000,
                IsModelItem = true,
            }); ;
        }
    }
}
//MdEnd
