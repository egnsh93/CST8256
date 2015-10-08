using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Lab2.Models;
using Lab2.Repositories;

namespace Lab2.ViewModels
{
    public class CartViewModel
    {
        public List<Order> BookOrders { get; set; }
        public int NumCopies { get; set; }
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double TotalAmountPayable
        {
            get
            {
                return OrderRepository.RetrieveAllOrders().Sum(order => order.SubTotal);
            }
        }
    }
}