﻿#pragma checksum "..\..\NewCustomer.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D9734AF79FFD8E38CEDB30CA0075A668E7AB9781BE3AE15399E3D2BBD5ADF51C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using zpotts_rd_a3;


namespace zpotts_rd_a3 {
    
    
    /// <summary>
    /// NewCustomer
    /// </summary>
    public partial class NewCustomer : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\NewCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NAME;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\NewCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LNAME;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\NewCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PHONE;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\NewCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddCust;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\NewCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid CustomersView;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\NewCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Complete;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WallysWorld;component/newcustomer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\NewCustomer.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.NAME = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.LNAME = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.PHONE = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.AddCust = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\NewCustomer.xaml"
            this.AddCust.Click += new System.Windows.RoutedEventHandler(this.AddCust_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CustomersView = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.Complete = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\NewCustomer.xaml"
            this.Complete.Click += new System.Windows.RoutedEventHandler(this.Complete_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
