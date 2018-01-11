using System;
using System.Collections.Generic;
using Narato.Libraries.POC.Domain.Common;

namespace Narato.Libraries.POC.Domain.Models.Books
{
    public class Author: Entity<Guid>
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        // Profile pic

        public string FullName => $"{FirstName} {LastName}";

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
