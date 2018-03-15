﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

// Entity framework
using System.Data.Entity;

// Employee class
using EmployeeList;
using System.ComponentModel;

namespace EmployeeList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AddEmployee ae;
        public MainWindow()
        {
            InitializeComponent();

            // Initialize the database context
            ContextContainer.Initialize();

            // Add columns to employee datagrid list
            DataGridTextColumn textColumn = new DataGridTextColumn();
            textColumn.Header = "First Name";
            textColumn.Binding = new Binding("FirstName");
            employeeDataGrid.Columns.Add(textColumn);

            textColumn = new DataGridTextColumn();
            textColumn.Header = "Last Name";
            textColumn.Binding = new Binding("LastName");
            employeeDataGrid.Columns.Add(textColumn);

            UpdateEmployeeGrid();
        }

        // Add employee
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ae = new AddEmployee();
            ae.Show();
            ae.Closing += new CancelEventHandler(UpdateEmployeeGridFormClose);
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ; ;
        }

        public void UpdateEmployeeGridFormClose(object sender, CancelEventArgs e)
        {
            if (!ae.UpdateList)
                return;

            UpdateEmployeeGrid();
        }

        public void UpdateEmployeeGrid()
        {
            employeeDataGrid.Items.Clear();
            IQueryable<Employee> rtn = from temp in ContextContainer.Ctx.Employees select temp;
            var list = rtn.ToList();
            for (int i = 0; i < list.Count(); i++)
            {
                employeeDataGrid.Items.Add(list[i]);
            }
        }
    }
}