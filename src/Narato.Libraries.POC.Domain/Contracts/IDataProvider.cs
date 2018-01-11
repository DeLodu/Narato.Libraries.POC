using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Narato.Libraries.POC.Domain.Common
{
    public interface IDataProvider<TEntity,TKey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync(Pager pager);

        Task<Pager> CountAllAsync(int page, int pagesize);

        Task<TEntity> GetByIdAsync(TKey id);

        void AddNew(TEntity book);

        void Delete(TEntity book);

        Task Commit();
    }
}