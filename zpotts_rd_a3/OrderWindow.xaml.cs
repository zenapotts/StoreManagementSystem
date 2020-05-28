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
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        public int Loc = 0;
        public OrderInfo order = new OrderInfo();
        public bool selectedCust = false;
        public bool selectedAdd = false;
        public OrderWindow(int Location)
        {
            InitializeComponent();
            Loc = Location;
            //populate the cust select
            CustomerSelect.ItemsSource = null;
            ZP_Customers.CustList = null;
            ZP_Customers.CustList = SQL_Calls.Select_Customers();
            CustomerSelect.ItemsSource = ZP_Customers.CustList;
            //populate inventory by branch/loc
            ZP_Inventory.InvAtLoc = null;
            ZP_Inventory.InvAtLoc = SQL_Calls.Select_Inventory(Loc);
            LocInventory.ItemsSource = null;
            LocInventory.ItemsSource = ZP_Inventory.InvAtLoc;
            //get new orderID and set to SQL_Calls class for calling the number later
            SQL_Calls.MaxOrderID();
        }

        private void SelectCust_Click(object sender, RoutedEventArgs e)
        {
            foreach (CustomerEntry c in CustomerSelect.SelectedItems)
            {
                order.customer = c;
                CustInfo.Text= c.custID + "\n" + c.fName + " " + c.lName + "\n" + c.tNumber;
                selectedCust = true;
            }

        }

        private void NewCust_Click(object sender, RoutedEventArgs e)
        {
            NewCustomer newpage = new NewCustomer();
            newpage.ShowDialog();
        }

        private void RefreshCust_Click(object sender, RoutedEventArgs e)
        {
            CustomerSelect.ItemsSource = null;
            ZP_Customers.CustList = null;
            ZP_Customers.CustList = SQL_Calls.Select_Customers();
            CustomerSelect.ItemsSource = ZP_Customers.CustList;
        }
        public List<int> combo = new List<int>();
        private void LocInventory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int max = 0;
            Quantity.SelectedIndex = -1;
            combo.Clear();
            foreach (InventoryEntry c in LocInventory.SelectedItems)
            {
                max = c.quantity;
            }
            for (int i = 0; i <= max; i++)
            {
                combo.Add(i);
            }
            Quantity.ItemsSource = null;
            Quantity.ItemsSource = combo;
        }

        private void AddItems_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCust == true) 
            {
                bool state = false;
                if (Quantity.SelectedIndex != -1)
                {
                    selectedAdd = true;
                    foreach (InventoryEntry c in LocInventory.SelectedItems)
                    {
                        if (Quantity.SelectedIndex <= c.quantity && Quantity.SelectedIndex > 0 && c.quantity > 0)
                        {
                            InventoryEntry temp = new InventoryEntry();
                            temp.branchID = c.branchID;
                            temp.price = c.price;
                            temp.pName = c.pName;
                            temp.quantity = Quantity.SelectedIndex;
                            temp.SKU = c.SKU;
                            foreach (InventoryEntry d in order.listOfItems)
                            {
                                if (d.SKU == c.SKU)
                                {
                                    d.quantity += Quantity.SelectedIndex;
                                    state = true;
                                }
                            }
                            if (state == false)
                            {
                                order.listOfItems.Add(temp);
                            }
                            c.quantity -= Quantity.SelectedIndex;
                        }
                    }
                }
                LocInventory.ItemsSource = null;
                LocInventory.ItemsSource = ZP_Inventory.InvAtLoc;
                SelectedItems.ItemsSource = null;
                SelectedItems.ItemsSource = order.listOfItems;
            } 
            else 
            {
                MessageBox.Show("Must Select a Customer First!\n(Click On The Customer And Click 'Select Customer')");
            }
            
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (selectedAdd == true) 
            {
                if (order.customer.custID != null && (order.listOfItems.Count != 0))
                {
                    selectedCust = false;
                    SQL_Calls.AddNewOrder(SQL_Calls.OrderID.ToString(), "2019-12-20", order.customer.custID, "PAID", "000" + Loc.ToString());
                    foreach (InventoryEntry c in order.listOfItems)
                    {
                        SQL_Calls.AddNewProductToOrder(SQL_Calls.OrderID.ToString(), c.SKU, c.quantity);
                    }
                    foreach (InventoryEntry c in LocInventory.Items)
                    {
                        SQL_Calls.UpdateInventory(c.quantity, c.branchID, c.SKU);
                    }
                    Reciept orderReciept = new Reciept(order, Loc);
                    orderReciept.ShowDialog();

                    this.Close();
                }

            } else 
            {
                MessageBox.Show("Must Add a Select Item First!\n(Click On An Item,\n Select a Quantity From The Dropdown,\n And Click 'Add Selected')");
            }
        }
    }
}
