using System;
using System.Windows;
using OfficeOpenXml;
using Services; // Đảm bảo đã thêm namespace cho service
using System.Collections.Generic;
using BusinessObjects.Models;
using DataAccessLayer;

namespace WPFApp
{
   
    public partial class ManagementWindow : Window
    {
        private PRN_EmployeeManagementContext _context;

        public ManagementWindow()
        {
            InitializeComponent();
            _context = new PRN_EmployeeManagementContext();
           
        }

      
            
    }
}
