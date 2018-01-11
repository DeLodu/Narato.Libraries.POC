using System;
using Narato.Libraries.POC.Contracts.DTO;

namespace Narato.Libraries.POC.Application.UseCases.Books
{
    public class UpdateBookRequest
    {
        public Guid Id { get; set; }

        public BookDTO Book { get; set; }
    }
}