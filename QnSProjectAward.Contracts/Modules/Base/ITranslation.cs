//@QnSCodeCopy
//MdStart

using CommonBase.Attributes;
using QnSProjectAward.Contracts.Modules.Common;

namespace QnSProjectAward.Contracts.Modules.Base
{
	public partial interface ITranslation : IIdentifiable
    {
        [Mandatory(MaxLength = 128, DefaultValue = "nameof(QnSProjectAward)", HasUniqueIndexWithName = true, IndexName = "UX_Translation", IndexColumnOrder = 1)]
        string AppName { get; set; }
        [ContractPropertyInfo(DefaultValue = "Contracts.Modules.Common.LanguageCode.En", HasUniqueIndexWithName = true, IndexName = "UX_Translation", IndexColumnOrder = 2)]
        LanguageCode KeyLanguage { get; set; }
        [Mandatory(MaxLength = 512, HasUniqueIndexWithName = true, IndexName = "UX_Translation", IndexColumnOrder = 3)]
        string Key { get; set; }
        [ContractPropertyInfo(DefaultValue = "Contracts.Modules.Common.LanguageCode.De")]
        LanguageCode ValueLanguage { get; set; }
        [ContractPropertyInfo(MaxLength = 1024, DefaultValue = "string.Empty")]
        string Value { get; set; }
    }
}
//MdEnd
