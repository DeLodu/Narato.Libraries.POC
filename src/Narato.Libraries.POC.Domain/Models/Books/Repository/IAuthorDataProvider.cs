using System;
using Narato.Libraries.POC.Domain.Common;

namespace Narato.Libraries.POC.Domain.Models.Books
{
    public interface IAuthorDataProvider : IDataProvider<Author, Guid>
    {
    }
}
