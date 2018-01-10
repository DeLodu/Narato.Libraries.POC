using System;
using Narato.Libraries.POC.Domain.Models;
using Narato.Libraries.POC.Domain.Common;

namespace Narato.Libraries.POC.Domain.Contracts.DataProviders
{
    public interface IBookDataProvider : IDataProvider<Book, Guid>
    {
       
    }
}
