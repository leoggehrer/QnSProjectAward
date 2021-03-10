//@QnSCodeCopy
//MdStart
using Microsoft.EntityFrameworkCore;
using QnSProjectAward.Logic.Entities.Persistence.Account;
using System.Linq;
using System.Threading.Tasks;

namespace QnSProjectAward.Logic.Controllers.Persistence.Account
{
	partial class IdentityXRoleController
	{
		public Task<Role[]> QueryIdentityRolesAsync(int identityId)
		{
			return QueryableSet().Where(e => e.IdentityId == identityId)
								 .Include(e => e.Role)
								 .Select(e => e.Role)
								 .ToArrayAsync();
		}
	}
}
//MdEnd
