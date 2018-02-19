using System;
using System.Collections.Generic;
using System.Linq;
using Narato.Libraries.POC.Domain.Common;

namespace Narato.Libraries.POC.Domain.Models.Books
{
    public class Author: Entity<Guid>
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";
        
        public ICollection<Book> Books { get; set; } = new List<Book>();

        public void AddBook(Book book)
        {
            // check if book is already in collection
            if (Books.Any(x => x.Id == book.Id))
                throw new Exception("Boek is al toegevoegd!");

            Books.Add(book);
        }
    }
}
