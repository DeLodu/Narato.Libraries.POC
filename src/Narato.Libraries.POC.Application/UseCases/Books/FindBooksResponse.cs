using System.Collections.Generic;

namespace Narato.Libraries.POC.Application.UseCases.Books
{
    public class FindBooksResponse
    {
        public List<BookListDTO> BooksList { get; set; }

        public int Currentpage { get; set; }

        public int PageSize { get; set; }

        public int RecordsTotal { get; set; }
    }
}