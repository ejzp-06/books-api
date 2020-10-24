using System;
using System.Collections.Generic;
using System.Text;

namespace books.Core.Entities
{
    class Borrowing
    {
        public int id { get; set; }

        public Author author { get; set; }

        public Book book { get; set; }
    }
}
