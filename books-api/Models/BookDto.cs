using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace books_api.Models
{
    public class BookDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime PublishDate { get; set; }

        public AuthorDto Author { get; set; }

        public int AuthorId { get; set; }

        public int Copies { get; set; }
    }
}
