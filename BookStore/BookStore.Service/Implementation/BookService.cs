using BookStore.Domain.Entities;
using BookStore.Persistence;
using BookStore.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Service.Implementation
{
    public class BookService : IBookService
    {
        private readonly IApplicationDbContext _context;
        public BookService(IApplicationDbContext context)
        {
            _context = context;
        }

        public List<Books> GetAllBooks()
        {
            return _context.Books.All().ToList();
        }

        public Books GetBookById(Guid id)
        {
            return _context.Books.FindByKey(id);
        }

        public void AddBook(Books book)
        {
            _context.Books.Insert(book);
            _context.Books.SaveChanges();
        }
    }

}
