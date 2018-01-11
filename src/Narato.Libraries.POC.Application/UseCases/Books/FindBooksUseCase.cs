using System.Linq;
using System.Threading.Tasks;
using Narato.Libraries.POC.Application.Common;
using Narato.Libraries.POC.Contracts.DTO;
using Narato.Libraries.POC.Domain.Models.Books;

namespace Narato.Libraries.POC.Application.UseCases.Books
{
    public class FindBooksUseCase : BaseUseCase<FindBooksRequest, FindBooksResponse>
    {
        private readonly IBookDataProvider _bookDataProvider;

        public FindBooksUseCase(IBookDataProvider bookDataProvider)
        {
            _bookDataProvider = bookDataProvider;
        }

        public override async Task<FindBooksResponse> Execute(FindBooksRequest request)
        {
            // aantal Records
            var pager = await _bookDataProvider.CountAllAsync(request.Page, request.PageSize);

            // List books
            var books = await _bookDataProvider.GetAllAsync(pager);
            
            // to DTO
            var bkLstDTO = books.Select(bk => new BookListDTO()
                {
                    Id = bk.Id,
                    Title = bk.Title,
                    AuthorFullName = bk.Author?.FullName
                })
                .ToList();

            return new FindBooksResponse()
            {
                BooksList = bkLstDTO,
                Currentpage = pager.Page,
                PageSize = pager.Pagesize,
                RecordsTotal = pager.Records,
            };
        }
    }
}