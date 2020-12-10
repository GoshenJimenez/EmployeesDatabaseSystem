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
        public EmployeesDBContext() : base("myConnectionString")
        {
            Database.SetInitializer(new GoshenJimenez.EmployeesDatabaseSystem.Windows.DAL.DataInitializer());
        }

        public DbSet<Models.Employee> Employees { get; set; }
        public DbSet<Models.EmployeeRole> EmployeeRoles { get; set; }
        public DbSet<Models.Deduction> Deductions { get; set; }
        public DbSet<Models.EmployeeDeduction> EmployeeDeductions { get; set; }

    }
}
