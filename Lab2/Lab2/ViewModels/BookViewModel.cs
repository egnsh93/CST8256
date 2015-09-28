using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab2.Models;

namespace Lab2.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int SelectedValue { get; set; }
        public virtual IEnumerable<Book> BookData { get; set; } 
    }
}