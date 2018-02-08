using Microsoft.AspNetCore.Mvc;
using Narato.ResponseMiddleware.Models.Models;
using System;
using System.Threading.Tasks;
using Narato.Libraries.POC.Application.UseCases.Books;
using Narato.Libraries.POC.API.Common;

namespace Narato.Libraries.POC.API.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : BaseApiController
    {

        /// <summary>
        /// Gets all books (paged)
        /// </summary>
        /// <param name="page">which page to get</param>
        /// <param name="pagesize">how many items per page</param>
        /// <returns>a paged list of books</returns>
        [ProducesResponseType(typeof(Paged<BookListDTO>), (int)System.Net.HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorContent), (int)System.Net.HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorContent), (int)System.Net.HttpStatusCode.InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pagesize = 10)
        {
            var req = new FindBooksRequest(){Page = page, PageSize = pagesize };
            var response = await HandleUseCase<FindBooksRequest, FindBooksResponse>(req);

            return Ok(new Paged<BookListDTO>(response.BooksList, response.Currentpage, response.PageSize, response.RecordsTotal));
        }

        /// <summary>
        /// Gets a book by its Id
        /// </summary>
        /// <param name="id">the Id of the book</param>
        /// <returns>the Book with the given Id</returns>
        [ProducesResponseType(typeof(GetBookByIDResponse), (int)System.Net.HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorContent), (int)System.Net.HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorContent), (int)System.Net.HttpStatusCode.InternalServerError)]
        [HttpGet("{id}", Name = "GetBookById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var req = new GetBookByIDRequest() { Id = id };
            var response = await HandleUseCase<GetBookByIDRequest, GetBookByIDResponse>(req);

            return Ok(response);
        }

        /// <summary>
        /// Creates a book
        /// </summary>
        /// <param name="book">the book to create</param>
        /// <returns>the newly created book, or a list of validation errors</returns>
        [ProducesResponseType(typeof(CreateBookResponse), (int)System.Net.HttpStatusCode.OK)]
        //[ProducesResponseType(typeof(ValidationErrorContent<string>), (int)System.Net.HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorContent), (int)System.Net.HttpStatusCode.InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookRequest request)
        {
            var response = await HandleUseCase<CreateBookRequest, CreateBookResponse>(request);

            return Ok(response);
        }

        /// <summary>
        /// Updates a book
        /// </summary>
        /// <param name="id">the Id of the book to update</param>
        /// <param name="book">the book to update</param>
        /// <returns>the updated book, or a list of validation errors</returns>
        [ProducesResponseType(typeof(UpdateBookResponse), (int)System.Net.HttpStatusCode.OK)]
        //[ProducesResponseType(typeof(ValidationErrorContent<string>), (int)System.Net.HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorContent), (int)System.Net.HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorContent), (int)System.Net.HttpStatusCode.InternalServerError)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBookRequest request)
        {
            var response = await HandleUseCase<UpdateBookRequest, UpdateBookResponse>(request);

            return Ok(response);
        }

        /// <summary>
        /// Deletes the book by given id
        /// </summary>
        /// <param name="id">the id of the book that will get deleted</param>
        /// <returns>204 no content</returns>
        [ProducesResponseType(typeof(void), (int)System.Net.HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorContent), (int)System.Net.HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorContent), (int)System.Net.HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorContent), (int)System.Net.HttpStatusCode.InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var request = new DeleteBookRequest() { Id = id };
            await HandleUseCase<DeleteBookRequest, DeleteBookResponse>(request);

            return NoContent();
        }
    }
}
