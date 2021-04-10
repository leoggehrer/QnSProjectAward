//@QnSCodeCopy
//MdStart
using QnSProjectAward.BlazorApp.Services.Modules.Authentication;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace QnSProjectAward.BlazorApp.Services.Modules.Configuration
{
	public sealed partial class SettingService : SettingAccess, ISettingService
    {
        private static string CreatePredicate() => $"AppName.Equals(\"{nameof(QnSProjectAward)}\")";

        public SettingService(IAccountService accountService, IServiceAdapter serviceAdapter)
            : base(accountService, serviceAdapter)
        {
        }

        protected override async Task LoadDataAsync()
        {
            try
            {
                var authorizationSession = AccountService.CurrentAuthorizationSession;

                if (authorizationSession != null)
                {
                    var dataAccess = ServiceAdapter.Create<Contracts.Persistence.Configuration.ISetting>(authorizationSession.Token);
                    var items = await dataAccess.QueryAllAsync(CreatePredicate()).ConfigureAwait(false);

                    storedEntries = new Dictionary<string, string>();
                    foreach (var item in items)
                    {
                        storedEntries.Add(item.Key, item.Value);
                        if (UnstoredEntries.ContainsKey(item.Key))
                        {
                            UnstoredEntries.Remove(item.Key);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in {MethodBase.GetCurrentMethod().Name}: {ex.Message}");
            }
        }
    }
}
//MdEnd
