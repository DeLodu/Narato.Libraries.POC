using System;
using Narato.Libraries.POC.DataProvider.Common;
using Narato.Libraries.POC.DataProvider.Contexts;
using Narato.Libraries.POC.Domain.Models.Books;

namespace Narato.Libraries.POC.DataProvider.DataProviders
{
    public class AuthorDataProvider : DataProvider<Author, Guid>, IAuthorDataProvider
    {
        public AuthorDataProvider(DataContext dataContext) : base(dataContext)
        {
        }
    }
}