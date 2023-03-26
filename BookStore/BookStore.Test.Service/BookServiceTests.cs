using BookStore.Domain.Entities;
using BookStore.Persistence;
using BookStore.Service.Implementation;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Test.Service
{
    [TestClass]
    public class BookServiceTests
    {
        public ApplicationDbContext _appDbContext;

        [TestInitialize]
        public void TestIntialize()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDB").Options;
            _appDbContext = new ApplicationDbContext(options);
        }

        [TestMethod]
        public void BookService_GetAllBooks_ShouldInsertBooks()
        {
            List<Books> books = new List<Books>() {
                new Books()
                {
                    Id = new Guid(),
                },
                new Books()
                {
                    Id = new Guid(),
                },
                new Books()
                {
                    Id = new Guid(),
                }
            };
            _appDbContext.Books.Insert(books);
            _appDbContext.SaveChanges();
            var bookDetails = new BookService(_appDbContext).GetAllBooks();

            Assert.AreEqual(3, bookDetails.Count());
        }

        [TestMethod]
        public void BookService_GetBookById_ShouldReturnBooks()
        {
            List<Books> books = new List<Books>() {
                new Books()
                {
                    Id = new Guid(),
                },
                new Books()
                {
                    Id = new Guid(),
                },
                new Books()
                {
                    Id = new Guid(),
                }
            };
            _appDbContext.Books.Insert(books);
            _appDbContext.SaveChanges();
            var bookDetails = new BookService(_appDbContext).GetBookById(books[0].Id);

            Assert.IsNotNull(bookDetails);
            Assert.AreEqual(books[0].Id, bookDetails.Id);
        }
    }
}