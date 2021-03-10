//@QnSCodeCopy
//MdStart
using CommonBase.Attributes;

namespace QnSProjectAward.Contracts.Persistence.Language
{
    [ContractInfo]
    public interface ITranslation : Modules.Base.ITranslation, IVersionable, ICopyable<ITranslation>
    {
    }
}
//MdEnd
