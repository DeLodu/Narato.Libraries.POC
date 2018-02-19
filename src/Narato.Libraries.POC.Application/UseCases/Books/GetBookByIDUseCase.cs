using System;
using System.Threading.Tasks;
using Narato.Libraries.POC.Application.Common;
using Narato.Libraries.POC.Domain.Models.Books;

namespace Narato.Libraries.POC.Application.UseCases.Books
{
    public class GetBookByIDUseCase : BaseUseCase<GetBookByIDRequest, GetBookByIDResponse>
    {

        private readonly IBookDataProvider _bookDataProvider;

        public GetBookByIDUseCase(IBookDataProvider bookDataProvider)
        {
            _bookDataProvider = bookDataProvider;
        }

        public override async Task<GetBookByIDResponse> Execute(GetBookByIDRequest request)
        {
            var book = await _bookDataProvider.GetById(request.Id);

            if(book == null)
                throw new Exception("Book Not found!");

            return new GetBookByIDResponse()
            {
                Id = book.Id,
                Title = book.Title,
                Summary = book.Summary,
                Pages = book.Pages,
                AuthorId = book.Author?.Id ?? Guid.Empty,
            };

        }
    }
}