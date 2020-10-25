using System;
using System.Collections.Generic;
using System.Text;

namespace books.Core.Entities
{
    public class BookList
    {
        public BookList()
        {
            Books = new List<Book>();
        }

        public IEnumerable<Book> Books { get; set; }

        public int AuthorId { get; set; }

        public int Id { get; set; }
    }
}
