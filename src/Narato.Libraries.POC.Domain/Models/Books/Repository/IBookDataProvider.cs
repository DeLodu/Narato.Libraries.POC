using System;
using System.Threading.Tasks;
using Narato.Libraries.POC.Domain.Common;

namespace Narato.Libraries.POC.Domain.Models.Books
{
    public interface IBookDataProvider : IDataProvider<Book, Guid>
    {

    }
}
