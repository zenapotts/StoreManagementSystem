using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zpotts_rd_a3
{
    public static class ZP_Orders
    {
        public static List<Order> allOrders = new List<Order>();
        public static List<OrderItems> contains = new List<OrderItems>();
    }
    public class OrderInfo
    {
        public CustomerEntry customer = new CustomerEntry();
        public List<InventoryEntry> listOfItems = new List<InventoryEntry>(); 
    }
    public class Order
    {
        public string orderID { get; set; }
        public string date { get; set; }
        public string custID { get; set; }
        public string status { get; set; }
        public string branchID { get; set; }
    }

    public class OrderItems
    {
        public string orderID { get; set; }
        public string SKU { get; set; }
        public int quantity { get; set; }
    }
}
