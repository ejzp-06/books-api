using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace books_api.Models
{
    public class BookListDto
    {
        public int Id { get; set; }

        public IEnumerable<BookDto> Books { get; set; }

        public AuthorDto Author { get; set; }

        public int AuthorId { get; set; }

    }
}
