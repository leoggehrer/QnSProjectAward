//@QnSCodeCopy
//MdStart
using CommonBase.Extensions;
using QnSProjectAward.Contracts.Client;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QnSProjectAward.BlazorApp.Modules.DataGrid
{
    public class DataAdapterAccess<TContract> : DataAccess<TContract>
		where TContract : Contracts.IIdentifiable, Contracts.ICopyable<TContract>
	{
		protected IAdapterAccess<TContract> AdapterAccess { get; private set; }
		public override string SessionToken 
		{
			set => AdapterAccess.SessionToken = value; 
		}

		public DataAdapterAccess(IAdapterAccess<TContract> adapterAccess)
		{
			adapterAccess.CheckArgument(nameof(adapterAccess));

			AdapterAccess = adapterAccess;
		}
		public override Task<int> CountAsync()
		{
			return AdapterAccess.CountAsync();
		}
		public override Task<int> CountByAsync(string predicate)
		{
			return AdapterAccess.CountByAsync(predicate);
		}

		public override Task<IEnumerable<TContract>> GetAllAsync()
		{
			return AdapterAccess.GetAllAsync();
		}
		public override Task<TContract> GetByIdAsync(int id)
		{
			return AdapterAccess.GetByIdAsync(id);
		}
		public override Task<IEnumerable<TContract>> GetPageListAsync(int pageIndex, int pageSize)
		{
			return AdapterAccess.GetPageListAsync(pageIndex, pageSize);
		}
		public override Task<IEnumerable<TContract>> QueryAllAsync(string predicate)
		{
			return AdapterAccess.QueryAllAsync(predicate);
		}
		public override Task<IEnumerable<TContract>> QueryPageListAsync(string predicate, int pageIndex, int pageSize)
		{
			return AdapterAccess.QueryPageListAsync(predicate, pageIndex, pageSize);
		}

		public override Task<TContract> CreateAsync()
		{
			return AdapterAccess.CreateAsync();
		}
		public override Task<TContract> InsertAsync(TContract entity)
		{
			return AdapterAccess.InsertAsync(entity);
		}
		public override Task<TContract> UpdateAsync(TContract entity)
		{
			return AdapterAccess.UpdateAsync(entity);
		}
		public override Task DeleteAsync(int id)
		{
			return AdapterAccess.DeleteAsync(id);
		}

		public static string ToCaseInsensitivPredicate(string predicate)
		{
			var result = predicate;
			var tags = result.GetAllTags("Contains(", ")");

			result = result.Replace("Contains", "ToLower().Contains");

			foreach (var tag in tags)
			{
				result = result.Replace(tag.InnerText, tag.InnerText.ToLower());
			}
			return result;
		}

        protected override void Dispose(bool disposing)
        {
			if (disposing)
            {
				if (AdapterAccess != null)
                {
					AdapterAccess.Dispose();
                }
				AdapterAccess = null;
            }
			base.Dispose(disposing);
		}
	}
}
//MdEnd
