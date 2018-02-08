using System;
using System.Threading.Tasks;
using Narato.Libraries.POC.Application.Common;
using Narato.Libraries.POC.Domain.Models.Books;

namespace Narato.Libraries.POC.Application.UseCases.Books
{
    public class CreateBookUseCase : BaseUseCase<CreateBookRequest, CreateBookResponse>
    {

        private readonly IBookDataProvider _bookDataProvider;
        private readonly IAuthorDataProvider _authorDataProvider;

        public CreateBookUseCase(IBookDataProvider bookDataProvider, IAuthorDataProvider authorDataProvider)
        {
            _bookDataProvider = bookDataProvider;
            _authorDataProvider = authorDataProvider;
        }


        public override async Task<CreateBookResponse> Execute(CreateBookRequest request)
        {
            var newbook = new Book(request.Title)
            {
                Pages = request.Pages,
                Summary = request.Summary,
            };

            // if author 
            if (request.AuthorId != Guid.Empty)
            {
                // lookup author
                var author = await _authorDataProvider.GetByIdAsync(request.AuthorId);
                newbook.Author = author ?? throw new Exception("Author not found!");
            }
            
            // Add tot DB
            _bookDataProvider.AddNew(newbook);

            // Commit changes
            await _bookDataProvider.Commit();

            // return bookDTO
            return new CreateBookResponse()
            {
                Id = newbook.Id,
                Title = newbook.Title,
                Summary = newbook.Summary,
                Pages = newbook.Pages,
                AuthorId = newbook.Author?.Id ?? Guid.Empty
            };
        }
    }
}