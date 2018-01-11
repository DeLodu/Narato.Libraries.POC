using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Narato.Libraries.POC.Domain.Common;

namespace Narato.Libraries.POC.Domain.Models
{
    public class Author: Entity<Guid>
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public virtual ICollection<Book> Books { get; set; }
    }
}
