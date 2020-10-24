using System;
using System.Collections.Generic;
using System.Text;

namespace books.Core.Entities
{
    class BookList
    {
        public BookList()
        {
            books = new List<Book>();
        }

        public IEnumerable<Book> books { get; set; }

        public Author author { get; set; }

        public int id { get; set; }
    }
}
