using System;
using System.Windows;
using DataAccessLayer;
using BusinessObjects.Models;
using System.Collections.Generic;

namespace WPFApp
{
    public partial class CustomerWindow : Window
    {
        private EmployeesDAO employeesDAO;
        private DepartmentsDAO departmentsDAO;
        private AttendanceDAO attendanceDAO;
        private string customerId; // Field to store the passed customer ID

        // Constructor that accepts a customer ID
        public CustomerWindow(string customerId)
        {
            InitializeComponent();
            this.customerId = customerId; // Store the customer ID for later use
            employeesDAO = new EmployeesDAO();
            departmentsDAO = new DepartmentsDAO();
            attendanceDAO = new AttendanceDAO();
        }

        // Default constructor
        public CustomerWindow()
        {
            InitializeComponent();
            employeesDAO = new EmployeesDAO();
            departmentsDAO = new DepartmentsDAO();
            attendanceDAO = new AttendanceDAO();
        }

        // Method when clicking the "Department" button
        private void DepartmentButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Departments> departments = departmentsDAO.GetAll();
                // Display the list of departments (update UI or display somewhere)
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading departments: {ex.Message}");
            }
        }

        // Method when clicking the "Attendance" button
        private void AttendanceButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime today = DateTime.Today;
                List<EmployeeAttendance> attendanceRecords = attendanceDAO.GetAllEmployeesWithAttendance(today);
                // Display the attendance records (update UI or display somewhere)
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading attendance records: {ex.Message}");
            }
        }

        // Method when clicking the "Salary" button
        private void SalaryButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                // Call methods in DAO if there are methods to retrieve salary data or related calculations.
                // Update UI or handle displaying salary data.
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading salary information: {ex.Message}");
            }
        }

        // Method when clicking the "Checkin" button
        private void CheckInButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                int employeeId = 1; // Replace with actual employee ID or get from user input
                bool isCheckedIn = attendanceDAO.CheckIn(employeeId);

                if (isCheckedIn)
                {
                    MessageBox.Show("Check-in successful!");
                }
                else
                {
                    MessageBox.Show("Check-in failed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during check-in: {ex.Message}");
            }
        }

        // Method when clicking the "Checkout" button
        private void CheckOutButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                int employeeId = 1; // Replace with actual employee ID or get from user input
                bool isCheckedOut = attendanceDAO.CheckOut(employeeId);

                if (isCheckedOut)
                {
                    MessageBox.Show("Check-out successful!");
                }
                else
                {
                    MessageBox.Show("Check-out failed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during check-out: {ex.Message}");
            }
        }
    }
}
