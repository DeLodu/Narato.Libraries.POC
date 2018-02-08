using System;

namespace Narato.Libraries.POC.Application.UseCases.Books
{
    public class BookListDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string AuthorFullName { get; set; }
    }
}