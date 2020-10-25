using System;
using System.Collections.Generic;
using System.Text;

namespace books.Core.Entities
{
    public class Book
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int AuthorId { get; set; }

        public int Copies { get; set; }
    }
}
