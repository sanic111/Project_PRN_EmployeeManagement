﻿using BusinessObjects.Models;
using DataAccessLayer;
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

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for AttendanceList.xaml
    /// </summary>
    public partial class AttendanceList : Window
    {
        public AttendanceList()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            AttendanceDAO attendanceDAO = new AttendanceDAO();
            List<EmployeeAttendance> employeeAttendances = attendanceDAO.GetAllEmployeesWithAttendance(DateOnly.FromDateTime(DateTime.Now));
            DataGridAttendance.ItemsSource = employeeAttendances;
            AttendanceIn.Text = DateOnly.FromDateTime(DateTime.Now).ToString();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }

        private void SortByCheckInAscClick(object sender, RoutedEventArgs e)
        {

        }

        private void SortByCheckInDescClick(object sender, RoutedEventArgs e)
        {

        }

        private void SortByCheckOutAscClick(object sender, RoutedEventArgs e)
        {

        }

        private void SortByCheckOutDescClick(object sender, RoutedEventArgs e)
        {

        }

        private void SalaryDetailButton_Click(object sender, RoutedEventArgs e)
        {

            int employeeId = ((EmployeeAttendance)DataGridAttendance.SelectedItem).EmployeeId;
            SalaryDetail salaryDetail = new SalaryDetail(employeeId);
            salaryDetail.Show();
            this.Close();

        }

        private void CheckinLateButton_Click(object sender, RoutedEventArgs e)
        {
            AttendanceDAO attendanceDAO = new AttendanceDAO();
            List<EmployeeAttendance> employeeAttendances = attendanceDAO.GetCheckInLateEmployees(DateOnly.FromDateTime(DateTime.Now));
            DataGridAttendance.ItemsSource = employeeAttendances;
        }

        private void CheckOutSoon_Click(object sender, RoutedEventArgs e)
        {
            AttendanceDAO attendanceDAO = new AttendanceDAO();
            List<EmployeeAttendance> employeeAttendances = attendanceDAO.GetCheckoutSoonEmployee(DateOnly.FromDateTime(DateTime.Now));
            DataGridAttendance.ItemsSource = employeeAttendances;
        }

        private void CheckOutLate_Click(object sender, RoutedEventArgs e)
        {
            AttendanceDAO attendanceDAO = new AttendanceDAO();
            List<EmployeeAttendance> employeeAttendances = attendanceDAO.GetCheckoutLateEmployee(DateOnly.FromDateTime(DateTime.Now));
            DataGridAttendance.ItemsSource = employeeAttendances;
        }

        private void Absent_Click(object sender, RoutedEventArgs e)
        {
            AttendanceDAO attendanceDAO = new AttendanceDAO();
            List<EmployeeAttendance> employeeAttendances = attendanceDAO.GetAbsentEmployee(DateOnly.FromDateTime(DateTime.Now));
            DataGridAttendance.ItemsSource = employeeAttendances;
        }

        private void All_Click(object sender, RoutedEventArgs e)
        {
            AttendanceDAO attendanceDAO = new AttendanceDAO();
            List<EmployeeAttendance> employeeAttendances = attendanceDAO.GetAllEmployeesWithAttendance(DateOnly.FromDateTime(DateTime.Now));
            DataGridAttendance.ItemsSource = employeeAttendances;
        }

        private void AttendanceChange(object sender, SelectionChangedEventArgs e)
        {
            AttendanceDAO attendanceDAO = new AttendanceDAO();
            List<EmployeeAttendance> employeeAttendances = attendanceDAO.GetEmployeeAttendancesInADay(DateOnly.FromDateTime(DateTime.Now));
            DataGridAttendance.ItemsSource = employeeAttendances;
        }
    }
}
