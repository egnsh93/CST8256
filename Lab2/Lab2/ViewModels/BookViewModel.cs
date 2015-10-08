using Lab2.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab2.ViewModels
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double Price { get; set; }
        public int NumCopies { get; set; }
        public List<Book> BookData { get; set; }
    }
}