using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab2.Models
{
    public class Order
    {
        public Book Book { get; private set; }
        public int NumCopies { get; set; }
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double SubTotal
        {
            get { return Book.Price*NumCopies; }
        }

        public Order(Book book, int numCopies)
        {
            Book = book;
            NumCopies = numCopies;
        }
    }
}