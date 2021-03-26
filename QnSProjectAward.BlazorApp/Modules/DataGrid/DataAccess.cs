//@QnSCodeCopy
//MdStart
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QnSProjectAward.BlazorApp.Modules.DataGrid
{
	public abstract class DataAccess<TContract>
		where TContract : Contracts.IIdentifiable, Contracts.ICopyable<TContract>
	{
		public abstract string SessionToken { set; }
		public abstract Task<int> CountAsync();
		public abstract Task<int> CountByAsync(string predicate);
		public abstract Task<TContract> GetByIdAsync(int id);
		public abstract Task<IEnumerable<TContract>> GetAllAsync();
		public abstract Task<IEnumerable<TContract>> GetPageListAsync(int pageIndex, int pageSize);
		public abstract Task<IEnumerable<TContract>> QueryPageListAsync(string predicate, int pageIndex, int pageSize);
		public abstract Task<IEnumerable<TContract>> QueryAllAsync(string predicate);
		public abstract Task<TContract> CreateAsync();
		public abstract Task<TContract> InsertAsync(TContract entity);
		public abstract Task<TContract> UpdateAsync(TContract entity);
		public abstract Task DeleteAsync(int id);
	}
}
//MdEnd	
