using System;
using System.Collections.Generic;
using System.Windows;
using DataAccessLayer;
using BusinessObjects.Models;

namespace WPFApp
{
    public partial class CustomerWindow : Window
    {
        private Users currentUser;
        private EmployeesDAO employeesDAO;
        private DepartmentsDAO departmentsDAO;
        private AttendanceDAO attendanceDAO;

        public CustomerWindow(Users user)
        {
            InitializeComponent();
            currentUser = user;
            employeesDAO = new EmployeesDAO();
            departmentsDAO = new DepartmentsDAO();
            attendanceDAO = new AttendanceDAO();
        }

        private void ShowSection(string section)
        {
            DefaultContent.Visibility = Visibility.Collapsed;
            DepartmentSection.Visibility = section == "Department" ? Visibility.Visible : Visibility.Collapsed;
            AttendanceSection.Visibility = section == "Attendance" ? Visibility.Visible : Visibility.Collapsed;
            SalarySection.Visibility = section == "Salary" ? Visibility.Visible : Visibility.Collapsed;
        }

        private void DepartmentButton_Click(object sender, RoutedEventArgs e)
        {
            ShowSection("Department");
            LoadDepartments();
        }

        private void AttendanceButton_Click(object sender, RoutedEventArgs e)
        {
            ShowSection("Attendance");
            LoadAttendance();
        }

        private void SalaryButtonClick(object sender, RoutedEventArgs e)
        {
            ShowSection("Salary");
            LoadSalaries();
        }

        private void LoadDepartments()
        {
            try
            {
                var departments = departmentsDAO.GetAll();
                DataGridDepartments.ItemsSource = departments;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading department data: {ex.Message}");
            }
        }

        private void LoadAttendance()
        {
            try
            {
                var date = DateTime.Now.Date; // Or allow user to select date
                var attendanceList = attendanceDAO.GetEmployeeAttendancesInADay(date);
                DataGridAttendance.ItemsSource = attendanceList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading attendance data: {ex.Message}");
            }
        }

        private void LoadSalaries()
        {
            try
            {
                var salaries = employeesDAO.GetAll(); // Adjust if needed to fetch salary-specific data
                DataGridSalaries.ItemsSource = salaries;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading salary data: {ex.Message}");
            }
        }

        private void CheckInButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Check-in functionality not implemented yet.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CheckOutButtonClick(object sender, RoutedEventArgs e)
        {
            // Close the current CustomerWindow
            this.Close();

            // Navigate to the MainWindow (login/homepage)
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

    }
}
