using System;
using Narato.Libraries.POC.Domain.Common;

namespace Narato.Libraries.POC.Domain.Models.Books
{
    public class Book: Entity<Guid>
    {
        protected Book() { }

        public Book(string title)
        {
            Id = new Guid();
            Title = title;
        }

        public string Title { get; set; }

        public string Summary { get; set; }

        public int Pages { get; set; }

        // isbn number

        // Cover Pic

        public virtual Guid AuthorID { get; set; }
   
        public virtual Author Author { get; set; }


    }
}
