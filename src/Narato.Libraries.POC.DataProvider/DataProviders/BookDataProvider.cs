﻿using System;
using Narato.Libraries.POC.DataProvider.Common;
using Narato.Libraries.POC.Domain.Contracts;
using Narato.Libraries.POC.Domain.Models.Books;

namespace Narato.Libraries.POC.DataProvider.DataProviders
{
    public class BookDataProvider : DataProvider<Book, Guid>, IBookDataProvider
    {
        public BookDataProvider(IDataContext dataContext) : base(dataContext)
        {
        }

 
    }
}
