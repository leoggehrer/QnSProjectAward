//@QnSCodeCopy
//MdStart

using CommonBase.Attributes;

namespace QnSProjectAward.Contracts.Persistence.Configuration
{
	[ContractInfo]
    public interface ISetting : Modules.Base.ISetting, IVersionable, ICopyable<ISetting>
    {
    }
}
//MdEnd
