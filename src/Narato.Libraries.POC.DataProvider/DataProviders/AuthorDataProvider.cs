using System;
using Narato.Libraries.POC.DataProvider.Common;
using Narato.Libraries.POC.Domain.Contracts;
using Narato.Libraries.POC.Domain.Models.Books;

namespace Narato.Libraries.POC.DataProvider.DataProviders
{
    public class AuthorDataProvider : DataProvider<Author, Guid>, IAuthorDataProvider
    {
        public AuthorDataProvider(IDataContext dataContext) : base(dataContext)
        {
        }
    }
}