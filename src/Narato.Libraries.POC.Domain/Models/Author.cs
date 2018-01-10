﻿using System;
using System.Collections.Generic;
using Narato.Libraries.POC.Domain.Common;

namespace Narato.Libraries.POC.Domain.Models
{
    public class Author : Entity<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
