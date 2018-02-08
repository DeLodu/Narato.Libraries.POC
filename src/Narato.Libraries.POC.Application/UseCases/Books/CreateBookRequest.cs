using System;

namespace Narato.Libraries.POC.Application.UseCases.Books
{
    public class CreateBookRequest
    {

        public string Title { get; set; }

        public int Pages { get; set; }

        public string Summary { get; set; }

        public Guid AuthorId { get; set; }
    }
}