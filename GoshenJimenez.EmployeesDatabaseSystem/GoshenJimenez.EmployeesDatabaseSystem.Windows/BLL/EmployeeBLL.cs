using GoshenJimenez.EmployeesDatabaseSystem.Windows.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoshenJimenez.EmployeesDatabaseSystem.Windows.BLL
{
    public static class EmployeeBLL
    {
        private static EmployeesDBContext db = new EmployeesDBContext();

        public static List<Models.Employee> GetList(string sortBy = "lastname", string sortOrder = "asc")
        {
            if (sortBy.ToLower() == "lastname" && sortOrder.ToLower() == "asc")
            {
                return db.Employees.OrderBy(e => e.LastName).ToList();
            }
            else if (sortBy.ToLower() == "lastname" && sortOrder.ToLower() == "desc")
            {
                return db.Employees.OrderByDescending(e => e.LastName).ToList();
            }
            else if (sortBy.ToLower() == "salary" && sortOrder.ToLower() == "asc")
            {
                return db.Employees.OrderBy(e => e.Salary).ToList();
            }
            else
            {
                return db.Employees.OrderByDescending(e => e.Salary).ToList();
            }
        }

        
    }
}
