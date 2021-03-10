//@QnSCodeCopy
//MdStart
using QnSProjectAward.Contracts.Business.Account;
using System.Threading.Tasks;

namespace QnSProjectAward.Logic.Controllers.Business.Account
{
    partial class IdentityUserController
    {
        public override async Task<IIdentityUser> CreateAsync()
        {
            var result = await base.CreateAsync().ConfigureAwait(false);

            result.OneItem.State = Contracts.Modules.Common.State.Active;
            return result;
        }
    }
}
//MdEnd
