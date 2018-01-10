using System;
using Narato.Libraries.POC.Domain.Common;

namespace Narato.Libraries.POC.Domain.Models
{
    public class Book : Entity<Guid>
    {
    public string Title { get; set; }
    public string Summary { get; set; }
    public Author Author { get; set; }
    }
}
