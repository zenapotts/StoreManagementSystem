   M S B A M L   `   `   `  ����F  BWallysWorld, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:zpotts_rd_a3zpotts_rd_a3  5   	       zpotts_rd_a3.OrderWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:zpotts_rd_a3     5   	     � Title$  OrderWindow��5   	   $	��450��6   $	��800��6*   .��5	      �  � ColumnDefinitions 5
   
   �� 5      6!   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      $
��auto �6   6.   �� 5      $��1* �6   6*   �� 5      $
��auto �6   6.   .+�5   
   �� .+�5      �� -   5         ��Name$ RefreshCust��5      $��25��6D   $��3q�6P   .��6\   Refresh Customers6o   �� 5      -   5        $ NewCust��5      $��25��6<   $��3q�6H   .��6T   New Customer6b   5      �� 5   
   -   5         ��Name$ CustInfo��5      $��1��6&   $��3,3,3,3q�66   6I   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ CustomerSelect��5      $��1��6+   $��0��68   $��1��6H      
IsReadOnly .    SelectionMode$ Single=�6n   $��3,3,3,3q�6�   5        5   
   -   5        $ LocInventory��5      $��1��6)   $��1��66   $��1��6F    . $ Single=�6l   $��3,3,3,3q�6�   5        5   
   -   5        $ SelectedItems��5      $��1��6*   $��2��67   $��1��6G    . $ Single=�6m   $��3,3,3,3q�6�   5      �� 5   
    �� Orientation$ 
Horizontal=�6   $	��Top=�6/   $
��Left=�6G   $��2��6b   $��1��6o   $��25��6   $��3q�6�   .+�5       �� 	Quantity:6'   �� 5!      $��10��6   6)   �� 5"      -   5        	 ��Name$	 Quantity��5"      $��70��6E   ��6-   �� 5#      �� 5$      -   5        $��2��5$      $��1��6&   $	��100��6M   .��6Y   Add Selected6g   5%      �� 5&   
   -	   5        $ Confirm��5&      $��26(�69   $��2��6G   $��2��6W   $��50��6d   
�������
���OO/�$��3q�6�   .��6�   Confirm Order6�   �� 5'   
   -
   5        $ 
SelectCust��5'      $��2��6%   $��3q�6K   $��25��6V   $	��Top=�6b   .��6z   Select Customer6�   5)      5*      