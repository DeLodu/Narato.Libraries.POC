using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Narato.Libraries.POC.Domain.Common
{
    public interface IDataProvider<TEntity,TKey>
    {
        Task<IEnumerable<TEntity>> Find(Predicate<TEntity> predicate, Pager pager);

        Task<TEntity> FindFirst(Predicate<TEntity> predicate);
            
        Task<Pager> Count(Predicate<TEntity> predicate, int page, int pagesize);

        Task<TEntity> GetById(TKey id);

        void AddNew(TEntity book);

        void Delete(TEntity book);

        Task Commit();
    }
}