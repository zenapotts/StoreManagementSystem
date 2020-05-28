using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zpotts_rd_a3
{
    class ZP_Customers
    {
        public static List<CustomerEntry> CustList = new List<CustomerEntry>();

    }
    public class CustomerEntry
    {
        public string custID { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public string tNumber { get; set; }
    }
}
