//@QnSCodeCopy
//MdStart
using QnSProjectAward.Contracts.Persistence.Account;

namespace QnSProjectAward.Contracts.Business.Account
{
    public partial interface IIdentityUser : IOneToAnother<IIdentity, IUser>, ICopyable<IIdentityUser>
    {
    }
}
//MdEnd
