//@QnSCodeCopy
//MdStart

using CommonBase.Attributes;

namespace QnSProjectAward.Contracts.Persistence.Account
{
    [ContractInfo]
    public partial interface IIdentityXRole : IVersionable, ICopyable<IIdentityXRole>
    {
        int IdentityId { get; set; }
        int RoleId { get; set; }
    }
}
//MdEnd
