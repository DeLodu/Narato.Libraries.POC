using System.Collections.Generic;
using System.Threading.Tasks;
using Narato.Libraries.POC.Domain.Common;
using Narato.Libraries.POC.Domain.Contracts;

namespace Narato.Libraries.POC.DataProvider.Common
{
    public abstract class DataProvider<TEntity,TKey> : IDataProvider<TEntity,TKey>
        where TEntity : Entity<TKey>
    {

        protected readonly IDataContext DataContext;

        protected internal DataProvider(IDataContext dataContext)
        {
            DataContext = dataContext;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(int page = 0, int pagesize = 10)
        {
            return await DataContext.FindPagedAsync<TEntity>(page, pagesize, null);
        }

        public async Task<int> CountAllAsync()
        {
            return await DataContext.CountAsync<TEntity>(null);
        }

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await DataContext.GetByIDAsync<TEntity, TKey>(id);
        }

        public void New(TEntity entity)
        {
            DataContext.AddNew(entity);
        }

        public void Delete(TEntity entity)
        {
            DataContext.Delete(entity);
        }
    }
}