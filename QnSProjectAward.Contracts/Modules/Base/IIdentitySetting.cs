//@QnSCodeCopy
//MdStart
using CommonBase.Attributes;

namespace QnSProjectAward.Contracts.Modules.Base
{
	public partial interface IIdentitySetting : IIdentifiable
	{
        [Mandatory(HasUniqueIndexWithName = true, IndexName = "UX_IDENTITYSETTING_APPNAME_KEY", IndexColumnOrder = 0)]
        int IdentityId { get; set; }
        [Mandatory(HasUniqueIndexWithName = true, IndexName = "UX_IDENTITYSETTING_APPNAME_KEY", IndexColumnOrder = 1, MaxLength = 128, DefaultValue = "nameof(QnSProjectAward)")]
        string AppName { get; set; }
        [Mandatory(HasUniqueIndexWithName = true, IndexName = "UX_IDENTITYSETTING_APPNAME_KEY", IndexColumnOrder = 2, MaxLength = 512)]
        string Key { get; set; }
        [ContractPropertyInfo(MaxLength = 4096, DefaultValue = "string.Empty")]
        string Value { get; set; }
    }
}
//MdEnd
