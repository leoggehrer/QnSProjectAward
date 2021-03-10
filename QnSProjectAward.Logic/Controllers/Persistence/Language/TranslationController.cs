//@QnSCodeCopy
//MdStart

using QnSProjectAward.Contracts.Persistence.Language;
using QnSProjectAward.Logic.Modules.Security;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QnSProjectAward.Logic.Controllers.Persistence.Language
{
	partial class TranslationController
    {
        [AllowAnonymous]
        public override Task<IEnumerable<ITranslation>> QueryAllAsync(string predicate)
        {
            return ExecuteQueryAllAsync(predicate);
        }
    }
}
//MdEnd
