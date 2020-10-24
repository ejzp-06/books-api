using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace books_api.Models
{
    public class Return
    {
        public int id { get; set; }

        public Author author { get; set; }

        public Book book { get; set; }

    }
}
