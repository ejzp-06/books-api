using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace books_api.Models
{
    public class Return
    {
        public int Id { get; set; }

        public Author Author { get; set; }

        public Book Book { get; set; }

    }
}
