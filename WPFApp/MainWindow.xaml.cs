using System;
using System.Linq;
using System.Windows;
using DataAccessLayer; // Thêm namespace cho DbContext
using BusinessObjects.Models; // Thêm namespace cho models
using Microsoft.EntityFrameworkCore;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
namespace WPFApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassWord.Password;

            // Sử dụng DbContext để kiểm tra thông tin đăng nhập
            using (var context = new PRN_EmployeeManagementContext())
            {
                // Tìm kiếm người dùng theo tên đăng nhập
               
                var user = context.Users
                   .FirstOrDefault(u => u.Username == username && u.Password == password);

                if (user != null)
                {
                    //Kiểm tra vai trò
                    if (user.RoleID == 1)
                    {
                        this.Close();
                        ManagementWindow managementWindow = new ManagementWindow();
                        managementWindow.Show();
                    }
                    else if (user.RoleID==2)
                    {
                        this.Hide();
                        CustomerWindow customerWindow = new CustomerWindow(); // Tạo CustomerWindow
                        customerWindow.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Thông tin tài khoản không chính xác. Vui lòng thử lại.");
                }
            }
        }
    }
}
