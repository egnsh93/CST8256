using Lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.ViewModels
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public IEnumerable<Book> BookData { get; set; }
    }
}