﻿using Narato.ResponseMiddleware.Models.Models;
using Narato.Libraries.POC.APIContracts.DTO;
using System;
using System.Threading.Tasks;

namespace Narato.Libraries.POC.Domain.Managers.Interfaces
{
    public interface IBookManager
    {
        Task<Paged<BookDto>> GetAllBooksAsync(int page = 1, int pagesize = 10);
        Task<BookDto> GetBookByIdAsync(Guid id);
        Task<BookDto> CreateBookAsync(BookDto book);
        Task<BookDto> UpdateBookAsync(Guid id, BookDto book);
        Task DeleteBookAsync(Guid id);
    }
}