using System;
using System.Collections.Generic;
using System.Text;

namespace books.Core.Entities
{
    class BookList
    {
        public BookList()
        {
            Books = new List<Book>();
        }

        public IEnumerable<Book> Books { get; set; }

        public Author Author { get; set; }

        public int Id { get; set; }
    }
}
