﻿using BusinessObjects.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for DepartmentList.xaml
    /// </summary>
    public partial class DepartmentList : Window
    {
        public DepartmentList()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            DepartmentsDAO departmentDAO = new DepartmentsDAO();
            List<DepartmentListModel> departments = departmentDAO.GetAllDepartments();
            DataGridDepartment.ItemsSource = departments;
        }


        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            DepartmentsDAO departmentDAO = new DepartmentsDAO();
            int departmentId = departmentDAO.GetMaxDepartmentId() + 1;
            departmentDAO.AddDepartment("");
            DepartmentDetail departmentDetail = new DepartmentDetail(departmentId);
            departmentDetail.Show();
            this.Close();
        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Button updateButton = (Button)sender;
            int departmentId = (int)updateButton.Tag;
            DepartmentDetail departmentDetail = new DepartmentDetail(departmentId);
            departmentDetail.Show();
            this.Close();

        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGridDepartments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }

        private void SearchDepartment(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void SearchName_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchName = SearchName.Text;
            DepartmentsDAO departmentDAO = new DepartmentsDAO();
            List<DepartmentListModel> departments = departmentDAO.GetAllDepartmentsByName(searchName);
            DataGridDepartment.ItemsSource = departments;
        }

        private void SortByNumberASc_Click(object sender, RoutedEventArgs e)
        {
            var column = DataGridDepartment.Columns.FirstOrDefault(c => c.SortMemberPath == "Num");

            if (column != null)
            {
                // Determine the new sort direction
                ListSortDirection direction = ListSortDirection.Ascending;

                // Sort the data
                ICollectionView dataView = CollectionViewSource.GetDefaultView(DataGridDepartment.ItemsSource);
                dataView.SortDescriptions.Clear();
                dataView.SortDescriptions.Add(new SortDescription(column.SortMemberPath, direction));
                dataView.Refresh();

                // Update the column's sort direction
                column.SortDirection = direction;
            }
        }

        private void SortByNumberDsc_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SortByNumberASc_Click(object sender, DataGridSortingEventArgs e)
        {

        }
    }
}
