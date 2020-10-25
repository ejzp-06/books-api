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
            var _return = _BooksDbContext.Baskets.FirstOrDefault(b => b.Id == ReturnId && !b.IsDeleted);
            if (_return == null)
            {
                return NotFound("El autor no existe.");
            }

            return Ok(new AuthorDto
            {
                Id = _return.Id,
                Age = _return.Age,
                Name = _return.Name
            });
        }

        [HttpPost]
        public ActionResult<ReturnDto> Post([FromBody] AddReturn _return)
        {
            var newReturn = new ReturnDto
            {
                AuthorId = _return.AuthorId,
                BookId = _return.BookId
            };

            _BooksDbContext.Returns.Add(newReturn);
            _BooksDbContext.SaveChanges();

            return newReturn;
        }
    }
}
