using System;
using System.Collections.Generic;
using System.Text;

namespace books.Core.Entities
{
    class Book
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Author Author { get; set; }

        public int Copies { get; set; }
    }
}
