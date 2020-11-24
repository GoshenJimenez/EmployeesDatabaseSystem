using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoshenJimenez.EmployeesDatabaseSystem.Windows.DAL
{
    public class DataInitializer : System.Data.Entity.DropCreateDatabaseAlways<EmployeesDBContext>
    {
        protected override void Seed(EmployeesDBContext context)
        {
            context.Employees.Add(new Models.Employee()
            {
                Id = Guid.Parse("56bac4c3-ef14-4f17-905d-5fb554063561"),
                FirstName = "Jace",
                LastName = "Beleren",
                Assignment = Models.Enums.Assignment.Office,
                EmailAddress = "jbeleren@mailinator.com",
                Salary = decimal.Parse("100000"),
                Status = Models.Enums.Status.Regular,
                IsActive = true
            });

            context.Employees.Add(new Models.Employee()
            {
                Id = Guid.Parse("56bac4c3-ef14-4f17-905d-5fb554063562"),
                FirstName = "Liliana",
                LastName = "Vess",
                Assignment = Models.Enums.Assignment.Field,
                EmailAddress = "lvess@mailinator.com",
                Salary = decimal.Parse("120000"),
                Status = Models.Enums.Status.Probationary,
                IsActive = true
            });

            context.SaveChanges();
        }
    }
}
