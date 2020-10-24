using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace books_api.Models
{
    public class Book
    {
        public int id { get; set; }

        public string name { get; set; }

        public DateTime publishDate { get; set; }

        public Author author { get; set; }

        public int copies { get; set; }
    }
}
