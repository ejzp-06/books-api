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
    public class AuthorsController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly BooksDbContext _BooksDbContext;

        public AuthorsController(IHttpContextAccessor httpContextAccessor, BooksDbContext BooksDbContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _BooksDbContext = BooksDbContext;
        }

        [HttpGet]
        public ActionResult<AuthorDto> Get()
        {
            var authorId = _httpContextAccessor.HttpContext.Request.Headers["#Id"].ToString();
            var author = _BooksDbContext.Authors.FirstOrDefault(b => b.Id.ToString() == authorId);
            if (author == null)
            {
                return NotFound("El autor no existe.");
            }

            return Ok(new AuthorDto
            {
                Id = author.Id,
                Age = author.Age,
                Name = author.Name
            });
        }

        [HttpPost]
        public ActionResult<Author> Post([FromBody] AddAuthor author)
        {
            var newAuthor = new Author
            {
                Age = author.Age,
                Name = author.Name
            };

            _BooksDbContext.Authors.Add(newAuthor);
            _BooksDbContext.SaveChanges();

            return newAuthor;
        }

        [HttpGet]
        [Route("{id}/books")]
        public ActionResult<IEnumerable<BookDto>> Get([FromQuery] int authorId)
        {
            var list = _BooksDbContext.Books.Where(b => b.AuthorId == authorId);
            return Ok(list.Select(b => new BookDto
            {
                Id = b.Id,
                AuthorId = b.AuthorId,
                Name = b.Name,
                Copies = b.Copies,
                PublishDate = b.PublishDate
            }));
        }

    }
}
