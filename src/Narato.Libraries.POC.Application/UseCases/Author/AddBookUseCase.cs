using System;
using System.Threading.Tasks;
using Narato.Libraries.POC.Application.Common;
using Narato.Libraries.POC.Domain.Models.Books;

namespace Narato.Libraries.POC.Application.UseCases.Author
{
    public class AddBookUseCase : BaseUseCase<AddBookRequest, AddBookResponse>
    {
        private readonly IAuthorDataProvider _authorDataProvider;
        private readonly IBookDataProvider _bookDataProvider;

        public AddBookUseCase(IAuthorDataProvider authorDataProvider, IBookDataProvider bookDataProvider)
        {
            _authorDataProvider = authorDataProvider;
            _bookDataProvider = bookDataProvider;
        }

        public override async Task<AddBookResponse> Execute(AddBookRequest request)
        {
            var author = await _authorDataProvider.GetById(request.AuthorID);
            if(author == null)
                throw new Exception("Auteur niet gevonden!");

            var book = await _bookDataProvider.GetById(request.BookID);
            if(book == null)
                throw new Exception("Boek niet gevonden!");

            author.AddBook(book);

            await _authorDataProvider.Commit();

            return new AddBookResponse();
        }
    }
}