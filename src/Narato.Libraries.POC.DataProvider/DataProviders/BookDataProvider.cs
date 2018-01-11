using System;
using Narato.Libraries.POC.DataProvider.Common;
using Narato.Libraries.POC.DataProvider.Contexts;
using Narato.Libraries.POC.Domain.Models.Books;

namespace Narato.Libraries.POC.DataProvider.DataProviders
{
    public class BookDataProvider : DataProvider<Book, Guid>, IBookDataProvider
    {
        public BookDataProvider(DataContext dataContext) : base(dataContext)
        {
        }

 
    }
}
