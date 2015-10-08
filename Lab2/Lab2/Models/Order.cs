using System.ComponentModel.DataAnnotations;

namespace Lab2.Models
{
    public class Order
    {
        public Order(Book book, int numCopies)
        {
            Book = book;
            NumCopies = numCopies;
        }

        public Book Book { get; private set; }
        public int NumCopies { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double SubTotal
        {
            get { return Book.Price*NumCopies; }
        }
    }
}