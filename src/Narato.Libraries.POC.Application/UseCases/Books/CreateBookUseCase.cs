using System;
using System.Threading.Tasks;
using Narato.Libraries.POC.Application.Common;
using Narato.Libraries.POC.Contracts.DTO;
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
            // lookup author
            var author = await _authorDataProvider.GetByIdAsync(request.Book.AuthorId);
            
            if(author == null)
                throw new Exception("Author not found!");

            var newbook = new Book(request.Book.Title)
            {
                Pages = request.Book.Pages,
                Summary = request.Book.Summary,
                Author = author
            };

            // Add tot DB
            _bookDataProvider.AddNew(newbook);

            // Commit changes
            await _bookDataProvider.Commit();

            // return bookDTO
            return new CreateBookResponse()
            {
                Book = new BookDTO()
                {
                    Id = newbook.Id,
                    Title = newbook.Title,
                    Summary = newbook.Summary,
                    Pages = newbook.Pages,
                    AuthorId = newbook.Author.Id
                }
            };
        }
    }
}