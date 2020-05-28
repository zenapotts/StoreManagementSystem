using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace zpotts_rd_a3
{
    public partial class Reciept : Window
    {
        public Reciept(OrderInfo order, int branch)
        {
            string branchstring = "Undefined";
            if (branch == 1)
            {
                branchstring = "SportsWorld";
            }
            else if (branch == 2)
            {
                branchstring = "Waterloo";
            }
            else if (branch == 3)
            {
                branchstring = "Cambridge Mall";
            }
            double ordertotalprice = 0.0 ;
            InitializeComponent();
            thanksLoc.Text = "Thank you for shopping at Wally’s World" + branchstring;
            ordernum.Text = "OrderID: " + SQL_Calls.OrderID;
            itemsOnReciept.ItemsSource = null;
            itemsOnReciept.ItemsSource = order.listOfItems;
            foreach(InventoryEntry f in order.listOfItems)
            {
                ordertotalprice += f.price * f.quantity;
            }
            producttotal.Text = ordertotalprice.ToString("C");
            tax.Text = (ordertotalprice * 0.13).ToString("C");
            final.Text = (ordertotalprice * 1.13).ToString("C");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
