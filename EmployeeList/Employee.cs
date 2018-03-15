using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Used to pass data between the AddEmployee window
 * and the main list window
*/
namespace EmployeeList
{
    public class Employee
    {
        public Employee()
        {
        }
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Context : DbContext
    {
        public Context() : base()
        {

        }
        public DbSet<Employee> Employees { get; set; }


    }
}
