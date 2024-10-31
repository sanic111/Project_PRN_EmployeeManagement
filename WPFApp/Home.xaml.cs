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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }
        private void DepartmentButton_Click(object sender, RoutedEventArgs e)
        {
            DepartmentList department = new DepartmentList();
            department.Show();
            this.Close();
        }

        private void AttendanceButton_Click(object sender, RoutedEventArgs e)
        {
            AttendanceList attendance = new AttendanceList();
            attendance.Show();
            this.Close();
        }

        private void SalaryButtonClick(object sender, RoutedEventArgs e)
        {
            SalaryList salary = new SalaryList();
            salary.Show();
            this.Close();
        }

        private void CheckInButtonClick(object sender, RoutedEventArgs e)
        {
            AttendanceDAO dao = new AttendanceDAO();
            bool check = dao.CheckIn(1);
            bool second_check = false;
            if (check)
            {
                second_check = dao.CheckInNotInTime(1);
            }
            else
            {
                MessageBox.Show("Failed");
            }
            if (second_check)
            {
                MessageBox.Show("Check in successfully at " + TimeOnly.FromDateTime(DateTime.Now) + "" + DateOnly.FromDateTime(DateTime.Now));
            }
            else
            {
                MessageBox.Show("Check in failed");
            }

        }

        private void CheckOutButtonClick(object sender, RoutedEventArgs e)
        {
            AttendanceDAO attendanceDAO = new AttendanceDAO();
            bool check = attendanceDAO.CheckOut(1);
            bool second_check = false;
            if (check)
            {
                second_check = attendanceDAO.CheckOutNotInTime(1);
            }
            else
            {
                MessageBox.Show("Failed");
            }
            if (second_check)
            {
                MessageBox.Show("Check out successfully at " + TimeOnly.FromDateTime(DateTime.Now) + "" + DateOnly.FromDateTime(DateTime.Now));
            }
            else
            {
                MessageBox.Show("Check out faile");
            }
        }
    }
}
