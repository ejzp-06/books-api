using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using books_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var book = _BooksDbContext.Baskets.FirstOrDefault(b => b.Id == bookId && !b.IsDeleted);
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
                Author = book.Author
            });
        }

        [HttpPost]
        public ActionResult<BookDto> Post([FromBody] AddBooks book)
        {
            var newBook = new BookDto
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
