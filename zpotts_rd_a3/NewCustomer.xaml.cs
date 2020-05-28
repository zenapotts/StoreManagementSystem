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
    /// <summary>
    /// Interaction logic for NewCustomer.xaml
    /// </summary>
    public partial class NewCustomer : Window
    {
        string name = "";
        string lname = "";
        string phone = "";
        public NewCustomer()
        {
            InitializeComponent();
            CustomersView.ItemsSource = null;
            ZP_Customers.CustList.Clear();
            ZP_Customers.CustList = SQL_Calls.Select_Customers();
            CustomersView.ItemsSource = ZP_Customers.CustList;
        }

        private void AddCust_Click(object sender, RoutedEventArgs e)
        {
            name = NAME.Text;
            lname = LNAME.Text;
            phone = PHONE.Text;
            SQL_Calls.AddNewCustomer(name, lname, phone);
            //clear the text
            NAME.Text = "";
            LNAME.Text = "";
            PHONE.Text = "";
            //refresh the view 
            CustomersView.ItemsSource = null;
            ZP_Customers.CustList.Clear();
            ZP_Customers.CustList = SQL_Calls.Select_Customers();
            CustomersView.ItemsSource = ZP_Customers.CustList;
        }

        private void Complete_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
