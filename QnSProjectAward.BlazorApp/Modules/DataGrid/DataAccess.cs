//@QnSCodeCopy
//MdStart
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QnSProjectAward.BlazorApp.Modules.DataGrid
{
	public abstract class DataAccess<TContract> : IDisposable
		where TContract : Contracts.IIdentifiable, Contracts.ICopyable<TContract>
	{
        private bool disposedValue;

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

        #region Dispose pattern
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~DataAccess()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion Dispose pattern
    }
}
//MdEnd	
