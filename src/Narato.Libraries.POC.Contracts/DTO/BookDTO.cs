using System;

namespace Narato.Libraries.POC.Contracts.DTO
{
    public class BookDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public int Pages { get; set; }

        public string Summary { get; set; }

        public Guid AuthorId { get; set; }


    }
}