﻿#pragma checksum "..\..\..\Employees\List.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4CA93A27ACB28A97C147B4FE8D4BA932F7A31ABD270C22CDE828BD0ABC7319DE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GoshenJimenez.EmployeesDatabaseSystem.Windows.Employees;
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


namespace GoshenJimenez.EmployeesDatabaseSystem.Windows.Employees {
    
    
    /// <summary>
    /// List
    /// </summary>
    public partial class List : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\Employees\List.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgEmployees;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\Employees\List.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboSortOrder;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Employees\List.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblSortOrder;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Employees\List.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboSortBy;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Employees\List.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblSortBy;
        
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
            System.Uri resourceLocater = new System.Uri("/GoshenJimenez.EmployeesDatabaseSystem.Windows;component/employees/list.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Employees\List.xaml"
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
            this.dgEmployees = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.cboSortOrder = ((System.Windows.Controls.ComboBox)(target));
            
            #line 11 "..\..\..\Employees\List.xaml"
            this.cboSortOrder.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cboSortOrder_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.lblSortOrder = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.cboSortBy = ((System.Windows.Controls.ComboBox)(target));
            
            #line 13 "..\..\..\Employees\List.xaml"
            this.cboSortBy.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cboSortBy_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.lblSortBy = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

