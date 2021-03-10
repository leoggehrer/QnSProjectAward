//@QnSCodeCopy
//MdStart
using QnSProjectAward.Contracts.Persistence.Account;

namespace QnSProjectAward.Contracts.Business.Account
{
    public partial interface IAppAccess : IOneToMany<IIdentity, IRole>, ICopyable<IAppAccess>
    {

    }
}
//MdEnd
