//@QnSCodeCopy
//MdStart
using CommonBase.Extensions;
using QnSProjectAward.BlazorApp.Services.Modules.Configuration;
using QnSProjectAward.Contracts.Client;
using QnSProjectAward.Contracts.Persistence.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace QnSProjectAward.BlazorApp.Pages.Persistence.Configuration
{
    public class SettingAdapterAccess : BlazorApp.Modules.DataGrid.DataAdapterAccess<ISetting>
	{
		public ISettingService Settings { get; init; }
		public SettingAdapterAccess(IAdapterAccess<ISetting> adapterAccess, ISettingService settingService) : base(adapterAccess)
		{
			settingService.CheckArgument(nameof(settingService));

			Settings = settingService;
		}
        public override async Task<int> CountAsync()
        {
			return (await GetSourceAsync().ConfigureAwait(false)).Count();
        }
        public override async Task<int> CountByAsync(string predicate)
        {
			return (await GetSourceAsync().ConfigureAwait(false)).AsQueryable().Where(ToCaseInsensitivPredicate(predicate)).Count();
		}
		public override Task<IEnumerable<ISetting>> GetAllAsync()
		{
			return GetSourceAsync();
		}
		public override async Task<IEnumerable<ISetting>> GetPageListAsync(int pageIndex, int pageSize)
		{
			return (await GetSourceAsync().ConfigureAwait(false)).Skip(pageIndex * pageSize).Take(pageSize);
		}
		public override async Task<IEnumerable<ISetting>> QueryAllAsync(string predicate)
		{
			return (await GetSourceAsync().ConfigureAwait(false)).AsQueryable().Where(ToCaseInsensitivPredicate(predicate));
		}
		public override async Task<IEnumerable<ISetting>> QueryPageListAsync(string predicate, int pageIndex, int pageSize)
		{
			return (await QueryAllAsync(predicate).ConfigureAwait(false)).Skip(pageIndex * pageSize).Take(pageSize);
		}

        public override async Task<ISetting> InsertAsync(ISetting entity)
        {
            var result = await base.InsertAsync(entity).ConfigureAwait(false);

			Settings.Reload();
			return result;
        }
        private async Task<IEnumerable<ISetting>> GetSourceAsync()
		{
			var result = new List<ISetting>(await base.GetAllAsync().ConfigureAwait(false));

			foreach (var item in Settings.GetUnstoredSettings())
			{
				var entity = await AdapterAccess.CreateAsync().ConfigureAwait(false);

				entity.Key = item.Key;
				entity.Value = item.Value;
				result.Add(entity);
			}
			return result;
		}
	}
}
//MdEnd
