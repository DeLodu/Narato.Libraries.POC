using System;

namespace Narato.Libraries.POC.Contracts.DTO
{
    public class BookListDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string AuthorFullName { get; set; }
    }
}