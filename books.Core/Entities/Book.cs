using System;
using System.Collections.Generic;
using System.Text;

namespace books.Core.Entities
{
    class Book
    {
        public int id { get; set; }

        public string name { get; set; }

        public Author author { get; set; }

        public int copies { get; set; }
    }
}
