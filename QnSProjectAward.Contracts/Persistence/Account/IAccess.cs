//@QnSCodeCopy
//MdStart
using CommonBase.Attributes;

namespace QnSProjectAward.Contracts.Persistence.Account
{
    [ContractInfo]
    public interface IAccess : IIdentifiable, ICopyable<IAccess>
    {
        int IdentityId { get; set; }
        [Mandatory(HasIndex = true, IsUnique = true, MaxLength = 512)]
        string Key { get; set; }
        [ContractPropertyInfo(MaxLength = 4096, DefaultValue = "string.Empty")]
        string Value { get; set; }
    }
}
//MdEnd
