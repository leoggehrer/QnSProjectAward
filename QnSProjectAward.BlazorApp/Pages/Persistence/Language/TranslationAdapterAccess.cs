//@QnSCodeCopy
//MdStart
using CommonBase.Extensions;
using QnSProjectAward.BlazorApp.Services.Modules.Language;
using QnSProjectAward.Contracts.Client;
using QnSProjectAward.Contracts.Persistence.Language;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace QnSProjectAward.BlazorApp.Pages.Persistence.Configuration
{
    public class TranslationAdapterAccess : BlazorApp.Modules.DataGrid.DataAdapterAccess<ITranslation>
	{
		public ITranslatorService Translator { get; init; }
		public TranslationAdapterAccess(IAdapterAccess<ITranslation> adapterAccess, ITranslatorService translator) : base(adapterAccess)
		{
			translator.CheckArgument(nameof(translator));

			Translator = translator;
		}
        public override async Task<int> CountAsync()
        {
			return (await GetSourceAsync().ConfigureAwait(false)).Count();
        }
        public override async Task<int> CountByAsync(string predicate)
        {
			return (await GetSourceAsync().ConfigureAwait(false)).AsQueryable().Where(ToCaseInsensitivPredicate(predicate)).Count();
		}
		public override Task<IEnumerable<ITranslation>> GetAllAsync()
		{
			return GetSourceAsync();
		}
		public override async Task<IEnumerable<ITranslation>> GetPageListAsync(int pageIndex, int pageSize)
		{
			return (await GetSourceAsync().ConfigureAwait(false)).Skip(pageIndex * pageSize).Take(pageSize);
		}
		public override async Task<IEnumerable<ITranslation>> QueryAllAsync(string predicate)
		{
			return (await GetSourceAsync().ConfigureAwait(false)).AsQueryable().Where(ToCaseInsensitivPredicate(predicate));
		}
		public override async Task<IEnumerable<ITranslation>> QueryPageListAsync(string predicate, int pageIndex, int pageSize)
		{
			return (await QueryAllAsync(predicate).ConfigureAwait(false)).Skip(pageIndex * pageSize).Take(pageSize);
		}

        public override async Task<ITranslation> InsertAsync(ITranslation entity)
        {
            var result = await base.InsertAsync(entity).ConfigureAwait(false);

			Translator.Reload();
			return result;
        }
        private async Task<IEnumerable<ITranslation>> GetSourceAsync()
		{
			var result = new List<ITranslation>(await base.GetAllAsync().ConfigureAwait(false));

			foreach (var item in Translator.GetUnstoredTranslations())
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
