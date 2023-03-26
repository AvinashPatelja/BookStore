using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Service.Contract
{
    public interface IBookService
    {
        List<Books> GetAllBooks();
        Books GetBookById(Guid id);
        void AddBook(Books book);
    }
}
