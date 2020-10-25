using System;
using System.Collections.Generic;
using System.Text;

namespace books.Core.Entities
{
    class Return
    {
        public int Id { get; set; }

        public Author Author { get; set; }

        public Book Book { get; set; }
    }
}
