using System;
using Microsoft.AspNetCore.Mvc;

namespace Narato.Libraries.POC.Application.UseCases.Author
{
    public class AddBookRequest
    {
        public Guid AuthorID { get; set; }

        public Guid BookID { get; set; }
    }
}