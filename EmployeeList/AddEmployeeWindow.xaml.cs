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

namespace EmployeeList
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        // Closing status
        public bool UpdateList = false;
        public AddEmployee()
        {
            InitializeComponent();
        }

        // Close button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Check if first name box is empty
            if (firstNameBox.Text == "")
            {
                firstNameBox.Focus();
                return;
            }
            // Check if last name box is empty
            if (lastNameBox.Text == "")
            {
                lastNameBox.Focus();
                return;
            }

            // If both boxes have data then add employee to the statically set database object and close the window
            Employee emp = new Employee() { FirstName = firstNameBox.Text, LastName = lastNameBox.Text };
            try
            {

                ContextContainer.Ctx.Employees.Add(emp);
                ContextContainer.Ctx.SaveChanges();

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            UpdateList = true;
            this.Close();
        }
    }
}
