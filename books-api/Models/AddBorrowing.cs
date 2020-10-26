using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace books_api.Models
{
    public class AddBorrowing
    {
        public int Id { get; set; }

        public int AuthorId { get; set; }

        public int BookId { get; set; }

    }
}
