using System;
using System.Threading.Tasks;
using Narato.Libraries.POC.Application.Common;
using Narato.Libraries.POC.Domain.Models.Books;

namespace Narato.Libraries.POC.Application.UseCases.Books
{
    public class DeleteBookUseCase : BaseUseCase<DeleteBookRequest, DeleteBookResponse>
    {

        private readonly IBookDataProvider _bookDataProvider;

        public DeleteBookUseCase(IBookDataProvider bookDataProvider)
        {
            _bookDataProvider = bookDataProvider;
        }

        public override async Task<DeleteBookResponse> Execute(DeleteBookRequest request)
        {
            // Get book
            var book = await _bookDataProvider.GetById(request.Id);

            if(book == null)
                throw new Exception("Book already Deleted!");

            // Delete book
            _bookDataProvider.Delete(book);

            // Commit changes
            await _bookDataProvider.Commit();
            
            return new DeleteBookResponse();
        }
    }
}