   M S B A M L   `   `   `  ����F  BWallysWorld, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:zpotts_rd_a3zpotts_rd_a3  5   	       zpotts_rd_a3.Reciept   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:zpotts_rd_a3     5   	     � Title$  Reciept��5   	   $	��400��6   $	��600��6&   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��auto �6   6,   �� 5      $��7* �6   6*   �� 5      $
��auto �6   6,   .+�5   
   �� .+�5      �� -   5         ��Name$ 	thanksLoc��5      $��15(�6+   $
��Wrap=�69   +)Thank you for shopping at Wally’s World5      �� 5      -   5        $ ordernum��5      $��15(�6*   $
��Wrap=�68   OrderID:50015      5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ itemsOnReciept��5      $��1��6+   $��2��68   $��1��6H      
IsReadOnly .    SelectionMode$ Single=�6n   $��3,3,3,3q�6�   5      �� 5   
   $��2��6    �� Orientation$ 
Horizontal=�6"   .+�5      �� $	��200��6   Paid!5      �� 5      -   5        .��5   *   Close Reciept5      �� 5       .+�5!      �� -   5        $ producttotal��5!      
Subtotal =5#      �� 5$      -   5        $	 tax��5$      HST (13%) =5&      �� 5'      -   5        $ final��5'      Sale Total =5)      5*      5+      5,      5-      