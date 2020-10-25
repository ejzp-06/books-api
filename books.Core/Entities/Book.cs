using System;
using System.Collections.Generic;
using System.Text;

namespace books.Core.Entities
{
    class Book
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int AuthorId { get; set; }

        public int Copies { get; set; }
    }
}
