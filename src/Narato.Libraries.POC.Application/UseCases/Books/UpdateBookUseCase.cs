using System;
using System.Threading.Tasks;
using Narato.Libraries.POC.Application.Common;
using Narato.Libraries.POC.Application.UseCases.Books;
using Narato.Libraries.POC.Domain.Models.Books;

namespace Narato.Libraries.POC.Application.UseCases
{
    public class UpdateBookUseCase: BaseUseCase<UpdateBookRequest, UpdateBookResponse>
    {
        private readonly IBookDataProvider _bookDataProvider;
        private readonly IAuthorDataProvider _authorDataProvider;

        public UpdateBookUseCase(IBookDataProvider bookDataProvider, IAuthorDataProvider authorDataProvider)
        {
            _bookDataProvider = bookDataProvider;
            _authorDataProvider = authorDataProvider;
        }

        public override async Task<UpdateBookResponse> Execute(UpdateBookRequest request)
        {
            // Get book
            var book = await _bookDataProvider.GetByIdAsync(request.Id);

            if(book == null)
                throw new Exception("Book not found!");

            book.Title = request.Title;
            book.Summary = request.Summary;
            book.Pages = request.Pages;

            if (request.AuthorId != Guid.Empty)
            {
                var author = await _authorDataProvider.GetByIdAsync(request.AuthorId);

                if (author == null)
                    throw new Exception("Author not found!");

                book.Author = author;
            }
            
            // Commit changes
            await _bookDataProvider.Commit();

            return new UpdateBookResponse()
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