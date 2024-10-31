﻿#pragma checksum "..\..\..\CustomerWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F8FB8D1A9C2C1491D91F1A6EEBD64BA91813E779"
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
using System.Windows.Controls.Ribbon;
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


namespace WPFApp {
    
    
    /// <summary>
    /// CustomerWindow
    /// </summary>
    public partial class CustomerWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\CustomerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DepartmentButton;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\CustomerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AttendanceButton;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\CustomerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SalaryButton;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\CustomerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Checkin;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\CustomerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Checkout;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\CustomerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock SectionHeader;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WPFApp;component/customerwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\CustomerWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.DepartmentButton = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\CustomerWindow.xaml"
            this.DepartmentButton.Click += new System.Windows.RoutedEventHandler(this.DepartmentButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.AttendanceButton = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\CustomerWindow.xaml"
            this.AttendanceButton.Click += new System.Windows.RoutedEventHandler(this.AttendanceButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.SalaryButton = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\CustomerWindow.xaml"
            this.SalaryButton.Click += new System.Windows.RoutedEventHandler(this.SalaryButtonClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Checkin = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\CustomerWindow.xaml"
            this.Checkin.Click += new System.Windows.RoutedEventHandler(this.CheckInButtonClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Checkout = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\CustomerWindow.xaml"
            this.Checkout.Click += new System.Windows.RoutedEventHandler(this.CheckOutButtonClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.SectionHeader = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

