using System.Collections.Generic;
using System.Threading.Tasks;

namespace Narato.Libraries.POC.Domain.Contracts
{
    public interface IDataContext
    {
        void AddNew<TEntity>(TEntity entity)
            where TEntity : class;

        void Delete<TEntity>(TEntity entity)
            where TEntity : class;

        Task<TEntity> GetByIDAsync<TEntity, TKey>(TKey id)
            where TEntity : class;

        Task<IEnumerable<TEntity>> FindPagedAsync<TEntity>(int page, int pagesize, Dictionary<string, string> parameters)
            where TEntity : class;

        Task<int> CountAsync<TEntity>(Dictionary<string, string> parameters)
            where TEntity : class;

        Task CommitAsync();
    }
}