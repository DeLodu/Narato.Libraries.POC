using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Narato.Libraries.POC.Domain.Common
{
    public interface IDataProvider<TEntity,TKey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync(int page = 1, int pagesize = 10);

        Task<int> CountAllAsync();

        Task<TEntity> GetByIdAsync(TKey id);

        void New(TEntity book);

        void Delete(TEntity book);
    }
}