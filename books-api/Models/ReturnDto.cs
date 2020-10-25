using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace books_api.Models
{
    public class ReturnDto
    {
        public int Id { get; set; }

        public AuthorDto Author { get; set; }

        public int AuthorId { get; set; }

        public BookDto Book { get; set; }

        public int BookId { get; set; }

    }
}
