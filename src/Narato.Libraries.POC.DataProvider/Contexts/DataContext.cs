using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Narato.Libraries.POC.Domain.Models.Books;

namespace Narato.Libraries.POC.DataProvider.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        #region Configs

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Book>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Author>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Book>()
                .HasOne(x => x.Author)
                .WithMany(x => x.Books);

        }

        #endregion

        #region Methods

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

        public async Task<TEntity> GetByID<TEntity, TKey>(TKey id)
            where TEntity : class
        {
            return await FindAsync<TEntity>(id);
        }

        public async Task<IEnumerable<TEntity>> FindPagedAsync<TEntity>(Predicate<TEntity> predicate, int page = 0, int pagesize = 20 )
            where TEntity : class
        {
            var query = Set<TEntity>()
                .AsNoTracking()
                .Skip(pagesize * page)
                .Take(pagesize);

            return await query.Where(x => predicate(x)).ToListAsync();
        }

        public async Task<TEntity> FindFirst<TEntity>(Predicate<TEntity> predicate)
            where TEntity : class
        {
            return await Set<TEntity>().FirstOrDefaultAsync(x => predicate(x));
        }

        public async Task<int> Count<TEntity>(Predicate<TEntity> predicate)
            where TEntity : class
        {
            return await Set<TEntity>().AsQueryable().Where(x => predicate(x)).CountAsync();
        }

        public async Task Commit()
        {
            try
            {
                await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        #endregion

    }
}
