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
    public class BorrowingController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly BooksDbContext _BooksDbContext;

        public BorrowingController(IHttpContextAccessor httpContextAccessor, BooksDbContext BooksDbContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _BooksDbContext = BooksDbContext;
        }

        [HttpGet]
        public ActionResult<BorrowingDto> Get()
        {
            var borrowingId = _httpContextAccessor.HttpContext.Request.Headers["#Id"].ToString();
            var borrowing = _BooksDbContext.Borrowings.FirstOrDefault(b => b.Id.ToString() == borrowingId);
            if (borrowing == null)
            {
                return NotFound("El prestamo no existe.");
            }

            return Ok(new BorrowingDto
            {
                Id = borrowing.Id,             
                BookId= borrowing.BookId,
                AuthorId = borrowing.AuthorId
            });
        }

        [HttpPost]
        public ActionResult<Borrowing
            > Post([FromBody] AddBorrowing borrowing)
        {
            var newBorrowing= new Borrowing
            {
                BookId = borrowing.BookId,
                AuthorId = borrowing.AuthorId
            };

            var book = _BooksDbContext.Books.FirstOrDefault(b => b.Id == borrowing.BookId);
            if (book == null || book.Copies <= 3)
            {
                return NotFound("El libro no existe o no hay suficientes copias disponibles.");
            }

            var bookTmp = _BooksDbContext.Books.FirstOrDefault(b => b.Id == book.Id);

            if(bookTmp == null)
            {
                return NotFound("El libro no existe o no hay suficientes copias disponibles.");
            }
            else
            {
                bookTmp.Copies -= 1;
                _BooksDbContext.Entry(bookTmp).CurrentValues.SetValues(bookTmp);
            }

            _BooksDbContext.Borrowings.Add(newBorrowing);
            _BooksDbContext.SaveChanges();

            return newBorrowing;
        }
    }
}
