using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using books_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using books.Infrastructure;
using books.Core.Entities;

namespace books_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly BooksDbContext _BooksDbContext;

        public BooksController(IHttpContextAccessor httpContextAccessor, BooksDbContext BooksDbContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _BooksDbContext = BooksDbContext;
        }

        [HttpGet]

        public ActionResult<BookDto> Get()
        {
            var bookId = _httpContextAccessor.HttpContext.Request.Headers["#Id"].ToString();
            var book = _BooksDbContext.Books.FirstOrDefault(b => b.Id.ToString() == bookId);
            if (book == null)
            {
                return NotFound("El libro no existe o no está disponible.");
            }

            return Ok(new BookDto
            {
                Id = book.Id,
                Name = book.Name,
                PublishDate = book.PublishDate,
                Copies = book.Copies,
                AuthorId = book.AuthorId
            });
        }

        [HttpPost]
    
        public ActionResult<Book> Post([FromBody] AddBooks book)
        {
            var newBook = new Book
            {
                Name = book.Name,
                PublishDate = DateTime.Now,
                Copies = 5,
                AuthorId = book.AuthorId
            };

            _BooksDbContext.Books.Add(newBook);
            _BooksDbContext.SaveChanges();

            return newBook;
        }

    }
}
