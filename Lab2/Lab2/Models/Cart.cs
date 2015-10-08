using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab2.Repositories;

namespace Lab2.Models
{
    public class Cart
    {
        public List<Order> BookOrders { get; set; }
    }
}