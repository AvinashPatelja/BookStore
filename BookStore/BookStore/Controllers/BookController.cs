using AutoMapper;
using BookStore.Domain.Entities;
using BookStore.Service.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private IMapper _mapper;
        private readonly ILogger<BookController> _logger;
        public BookController(IBookService bookService, IMapper mapper,ILogger<BookController> logger)
        {
            _bookService = bookService;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpGet()]
        public IActionResult GetAllBooks()
        {
            _logger.LogInformation("Executing GetAllBooks endpoint");
            var books = _bookService.GetAllBooks();
            if (books == null || !books.Any())
                return NoContent();

           var booksDetails = _mapper.Map<List<Books>>(books) ;

            _logger.Log(LogLevel.Error, "Message");
            
            return Ok(booksDetails);
        }
        [HttpGet("{id}")]
        public IActionResult GetBookById(Guid id)
        {
            var books = _bookService.GetBookById(id);
            if (books == null)
                return NoContent();

            var booksDetails = _mapper.Map<Books>(books);
            _logger.LogError("Error");
            return Ok(booksDetails);
        }
        [HttpPost]
        public IActionResult AddBook([FromBody] Books book)
        {
            if (book != null)
            {
                book.Id=Guid.NewGuid();
                _bookService.AddBook(book);
                var booksDetails = _mapper.Map<Books>(book);
                return Ok(booksDetails);
            }
            return NoContent();
        }
    }
}