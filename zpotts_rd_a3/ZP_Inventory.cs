using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zpotts_rd_a3
{
    class ZP_Inventory
    {
        public static List<InventoryEntry> InvAtLoc = new List<InventoryEntry>();
    }
    public class InventoryEntry
    {
        public string branchID { get; set; }
        public string SKU { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public string pName { get; set; }
    }
}
