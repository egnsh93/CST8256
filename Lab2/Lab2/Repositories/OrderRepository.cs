using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab2.Models;

namespace Lab2.Repositories
{
    public class OrderRepository
    {
        public static List<Order> OrderList = new List<Order>();

        public static void SaveOrder(Order order)
        {
            OrderList.Add(order);
        }

        public static List<Order> RetrieveAllOrders()
        {
            return OrderList;
        }

        public static void RemoveAllorders()
        {
            OrderList.Clear();
        }
    }
}