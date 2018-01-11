using Narato.Libraries.POC.Contracts.DTO;

namespace Narato.Libraries.POC.Application.UseCases.Books
{
    public class CreateBookRequest
    {
        public BookDTO Book { get; set; }
    }
}