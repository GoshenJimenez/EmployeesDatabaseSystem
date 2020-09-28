using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoshenJimenez.EmployeesDatabaseSystem.Windows.DAL
{
    public class EmployeesDBContext : DbContext
    {
        public DbSet<Models.Employee> Employees { get; set; }

    }
}
