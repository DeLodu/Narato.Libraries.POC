using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Narato.Libraries.POC.Domain.Contracts;
using Narato.Libraries.POC.Domain.Models;

namespace Narato.Libraries.POC.DataProvider.Contexts
{
    public class DataContext : DbContext , IDataContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        #region DBSet properties

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Author { get; set; }

        #endregion

        #region IDataContext methods

        public void AddNew<TEntity>(TEntity entity)
            where TEntity : class
        {
            Entry<TEntity>(entity).State = EntityState.Added;
        }

        public void Delete<TEntity>(TEntity entity)
            where TEntity : class
        {
            Entry<TEntity>(entity).State = EntityState.Deleted;
        }

        public async Task<TEntity> GetByIDAsync<TEntity, TKey>(TKey id)
            where TEntity : class
        {
            return await FindAsync<TEntity>(id);
        }

        public async Task<IEnumerable<TEntity>> FindPagedAsync<TEntity>(int page = 0, int pagesize = 20, Dictionary<string, string> parameters = null)
            where TEntity : class
        {
            var query = Set<TEntity>().Skip(pagesize * page).Take(pagesize);

            if (parameters != null)
            {
                //query = query.Where(x => );
                // filter query
            }

            return await query.ToListAsync();
        }

        public async Task<int> CountAsync<TEntity>(Dictionary<string, string> parameters)
            where TEntity : class
        {
            var query = Set<TEntity>();

            if (parameters != null)
            {
                //query = query.Where(x => );
                // filter query
            }

            return await query.CountAsync();
        }

        public async Task CommitAsync()
        {
            await SaveChangesAsync();
        }

        #endregion

    }
}
