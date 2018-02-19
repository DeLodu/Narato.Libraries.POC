using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Narato.Libraries.POC.DataProvider.Contexts;
using Narato.Libraries.POC.Domain.Common;

namespace Narato.Libraries.POC.DataProvider.Common
{
    public abstract class DataProvider<TEntity,TKey> : IDataProvider<TEntity,TKey>
        where TEntity : Entity<TKey>
    {

        protected readonly DataContext DataContext;

        protected internal DataProvider(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public async Task<IEnumerable<TEntity>> Find(Predicate<TEntity> predicate, Pager pager)
        {
            return await DataContext.FindPagedAsync<TEntity>(predicate , pager.Page, pager.Pagesize);
        }

        public async Task<TEntity> FindFirst(Predicate<TEntity> predicate)
        {
            return await DataContext.FindFirst<TEntity>(predicate);
        }

        public async Task<Pager> Count(Predicate<TEntity> predicate, int page, int pagesize)
        {
            var records = await DataContext.Count<TEntity>(predicate);

            return new Pager(page, pagesize, records);
        }

        public async Task<TEntity> GetById(TKey id)
        {
            return await DataContext.GetByID<TEntity, TKey>(id);
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
            await DataContext.Commit();
        }
    }
}