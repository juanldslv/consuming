using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ejemplo
{
    public interface IRequest
    {
        Task<List<BookElement>> GetBook(string title);
        Task<List<BookElement>> GetBooks();
        Task<BookDetail> GetDetailBook(string isbn13);
    }
}
