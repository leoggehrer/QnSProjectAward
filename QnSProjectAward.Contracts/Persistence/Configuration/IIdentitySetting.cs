//@QnSCodeCopy
//MdStart

using CommonBase.Attributes;

namespace QnSProjectAward.Contracts.Persistence.Configuration
{
	[ContractInfo]
    public interface IIdentitySetting : Modules.Base.IIdentitySetting, IVersionable, ICopyable<IIdentitySetting>
    {
    }
}
//MdEnd
