using System;
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

        public async Task<IEnumerable<TEntity>> GetAllAsync(Pager pager)
        {
            return await DataContext.FindPagedAsync<TEntity>(pager.page, pager.pagesize, null);
        }

        public async Task<Pager> CountAllAsync(int page, int pagesize)
        {
            var records = await DataContext.CountAsync<TEntity>(null);

            return new Pager(page, pagesize, records);
        }

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await DataContext.GetByIDAsync<TEntity, TKey>(id);
        }

        public void AddNew(TEntity entity)
        {
            DataContext.AddNew(entity);
        }

        public void Delete(TEntity entity)
        {
            DataContext.Delete(entity);
        }

        public async Task Commit()
        {
            await DataContext.CommitAsync();
        }
    }
}