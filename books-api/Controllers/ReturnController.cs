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
    public class ReturnController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly BooksDbContext _BooksDbContext;
        
        public ReturnController(IHttpContextAccessor httpContextAccessor, BooksDbContext BooksDbContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _BooksDbContext = BooksDbContext;
        }

        [HttpGet]
        public ActionResult<ReturnDto> Get()
        {
            var ReturnId = _httpContextAccessor.HttpContext.Request.Headers["#Id"].ToString();
            var _return = _BooksDbContext.Returns.FirstOrDefault(b => b.Id.ToString() == ReturnId);
            if (_return == null)
            {
                return NotFound("El retorno no existe.");
            }

            return Ok(new ReturnDto
            {
                Id = _return.Id,
                AuthorId = _return.AuthorId,
                BookId = _return.BookId
            });
        }

        [HttpPost]
        public ActionResult<Return> Post([FromBody] AddReturn _return)
        {
            var newReturn = new Return
            {
                AuthorId = _return.AuthorId,
                BookId = _return.BookId
            };

            var bookTmp = _BooksDbContext.Books.FirstOrDefault(b => b.Id == _return.BookId);

            if (bookTmp == null)
            {
                return NotFound("El libro no existe.");
            }
            else
            {
                bookTmp.Copies += 1;
            }

            _BooksDbContext.Returns.Add(newReturn);
            _BooksDbContext.SaveChanges();

            return newReturn;
        }
    }
}
