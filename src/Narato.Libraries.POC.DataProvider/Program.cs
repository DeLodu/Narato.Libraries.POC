using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Narato.Libraries.POC.DataProvider.Contexts;

namespace Narato.Libraries.POC.DataProvider
{
    public class Program
    {
        // needed for EF toolings
        public static void Main(string[] args) { }
    }

    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();

            optionsBuilder.UseSqlServer("Data Source = (LocalDb)\\MSSQLLocalDB; Initial Catalog = LibPOC; Integrated Security = SSPI; AttachDBFilename = D:\\LibPOC.mdf");

            return new DataContext(optionsBuilder.Options);
        }
    }
}
