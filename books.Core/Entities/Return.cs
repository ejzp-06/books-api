using System;
using System.Collections.Generic;
using System.Text;

namespace books.Core.Entities
{
    public class Return
    {
        public int Id { get; set; }

        public int AuthorId { get; set; }

        public int BookId { get; set; }
    }
}
