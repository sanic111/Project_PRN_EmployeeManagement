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
using BusinessObjects.Models;
using Repositories;
using Services;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for EmployeesManagementWindow.xaml
    /// </summary>
    public partial class EmployeesManagementWindow : Window
    {
        private EmployeesService _employeesService = new();
        private DepartmentsService _departmentsService = new();
        public EmployeesManagementWindow()
        {
            InitializeComponent();
            _employeesService = new();
            LoadInitialData();
        }
        private void LoadInitialData()
        {
            //LoadDepartments();
            LoadEmployees();
            LoadDepartments();
        }

        private void LoadEmployees()
        {
            try
            {
                var employees = _employeesService.GetAllEmployees();
                DataGridEmployees.ItemsSource = employees;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void LoadDepartments()
        {
            try
            {
                var departments = _departmentsService.GetAllDepartments();
                ComboBoxDepartment.ItemsSource = departments;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var searchText = TextBoxSearch.Text.Trim();
                var searchBy = (ComboBoxSearchBy.SelectedItem as ComboBoxItem)?.Content.ToString();

                if (string.IsNullOrEmpty(searchBy))
                {
                    MessageBox.Show("Vui lòng chọn tiêu chí tìm kiếm!");
                    return;
                }

                var results = _employeesService.SearchEmployees(searchText, searchBy);
                DataGridEmployees.ItemsSource = results;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonApplyFilter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var department = ComboBoxDepartment.SelectedItem as Departments;
                var gender = (ComboBoxGender.SelectedItem as ComboBoxItem)?.Content.ToString();

                double? minSalary = null;
                if (double.TryParse(TextBoxMinSalary.Text?.Replace(",", ""), out double min))
                {
                    minSalary = min;
                }

                double? maxSalary = null;
                if (double.TryParse(TextBoxMaxSalary.Text?.Replace(",", ""), out double max))
                {
                    maxSalary = max;
                }

                var results = _employeesService.FilterEmployees(
                    department?.DepartmentID,
                    gender,
                    minSalary,
                    maxSalary);

                DataGridEmployees.ItemsSource = results;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonClearFilter_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxDepartment.SelectedIndex = -1;
            ComboBoxGender.SelectedIndex = 0;
            TextBoxMinSalary.Clear();
            TextBoxMaxSalary.Clear();
            LoadEmployees();
        }

        private void CreateEmployee_Click(object sender, RoutedEventArgs e)
        {
            var window = new EmployeeDetailWindow();
            if (window.ShowDialog() == true)
            {
                LoadEmployees();
                MessageBox.Show("Thêm nhân viên mới thành công!");
            }
        }

        private void EditEmployee_Click(object sender, RoutedEventArgs e)
        {
            var selectedEmployee = DataGridEmployees.SelectedItem as Employees;
            if (selectedEmployee == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần chỉnh sửa!");
                return;
            }

            var window = new EmployeeDetailWindow(selectedEmployee);
            if (window.ShowDialog() == true)
            {
                LoadEmployees();
                MessageBox.Show("Cập nhật thông tin nhân viên thành công!");
            }
        }

        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            var selectedEmployee = DataGridEmployees.SelectedItem as Employees;
            if (selectedEmployee == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!");
                return;
            }

            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa nhân viên {selectedEmployee.FullName}?",
                "Xác nhận xóa",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    _employeesService.DeleteEmployee(selectedEmployee);
                    LoadEmployees();
                    MessageBox.Show("Xóa nhân viên thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa nhân viên: {ex.Message}");
                }
            }
        }

        private void DataGridEmployees_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedEmployee = DataGridEmployees.SelectedItem as Employees;
            if (selectedEmployee != null)
            {
                var window = new EmployeeDetailWindow(selectedEmployee);
                if (window.ShowDialog() == true)
                {
                    LoadEmployees();
                }
            }
        }
    }
}
