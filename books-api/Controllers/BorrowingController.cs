using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using books_api.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var borrowing = _BooksDbContext.Baskets.FirstOrDefault(b => b.Id == borrowingId && !b.IsDeleted);
            if (borrowing == null)
            {
                return NotFound("El autor no existe.");
            }

            return Ok(new BorrowingDto
            {
                Id = borrowing.Id,             
                Book= borrowing.Book,
                Author = borrowing.Author
            });
        }

        [HttpPost]
        public ActionResult<BorrowingDto> Post([FromBody] AddBorrowing borrowing)
        {
            var newBorrowing= new BorrowingDto
            {
                BookId = borrowing.BookId,
                AuthorId = borrowing.AuthorId
            };

            _BooksDbContext.Borrowings.Add(newBorrowing);
            _BooksDbContext.SaveChanges();

            return newBorrowing;
        }
    }
}
