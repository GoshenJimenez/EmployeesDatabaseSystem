using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt = DevOne.Security.Cryptography.BCrypt;

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
                Password = BCrypt.BCryptHelper.HashPassword("m0ntessor1", BCrypt.BCryptHelper.GenerateSalt(8)),
                Salary = decimal.Parse("100000"),
                Status = Models.Enums.Status.Regular,
                IsActive = true
            });

            context.Employees.Add(new Models.Employee()
            {
                Id = Guid.Parse("56bac4c3-ef14-4f17-905d-5fb554063562"),
                FirstName = "Liliana",
                LastName = "Vess",
                Password = BCrypt.BCryptHelper.HashPassword("m0ntessor1", BCrypt.BCryptHelper.GenerateSalt(8)),
                Assignment = Models.Enums.Assignment.Field,
                EmailAddress = "lvess@mailinator.com",
                Salary = decimal.Parse("120000"),
                Status = Models.Enums.Status.Probationary,
                IsActive = true
            });

            context.EmployeeRoles.Add(new Models.EmployeeRole()
            {
                Id= Guid.NewGuid(),
                EmployeeId = Guid.Parse("56bac4c3-ef14-4f17-905d-5fb554063561"),
                UserRole = Models.Enums.UserRole.Admin
            });

            context.EmployeeRoles.Add(new Models.EmployeeRole()
            {
                Id = Guid.NewGuid(),
                EmployeeId = Guid.Parse("56bac4c3-ef14-4f17-905d-5fb554063561"),
                UserRole = Models.Enums.UserRole.HR
            });

            context.EmployeeRoles.Add(new Models.EmployeeRole()
            {
                Id = Guid.NewGuid(),
                EmployeeId = Guid.Parse("56bac4c3-ef14-4f17-905d-5fb554063562"),
                UserRole = Models.Enums.UserRole.Regular
            });

            context.Deductions.Add(new Models.Deduction()
            {
                Id = Guid.Parse("31b87ccb-9864-459d-b1c2-9792a3d10901"),
                Name = "SSS",
                Price = decimal.Parse("500")
            });

            context.Deductions.Add(new Models.Deduction()
            {
                Id = Guid.Parse("31b87ccb-9864-459d-b1c2-9792a3d10902"),
                Name = "PhilHealth",
                Price = decimal.Parse("300")
            });

            context.Deductions.Add(new Models.Deduction()
            {
                Id = Guid.Parse("31b87ccb-9864-459d-b1c2-9792a3d10903"),
                Name = "Pagibig",
                Price = decimal.Parse("200")
            });

            context.Deductions.Add(new Models.Deduction()
            {
                Id = Guid.Parse("31b87ccb-9864-459d-b1c2-9792a3d10904"),
                Name = "Cash bond",
                Price = decimal.Parse("150")
            });

            context.EmployeeDeductions.Add(new Models.EmployeeDeduction()
            {
                Id = Guid.NewGuid(),
                EmployeeId = Guid.Parse("56bac4c3-ef14-4f17-905d-5fb554063561"),
                DeductionId = Guid.Parse("31b87ccb-9864-459d-b1c2-9792a3d10901")
            });

            context.EmployeeDeductions.Add(new Models.EmployeeDeduction()
            {
                Id = Guid.NewGuid(),
                EmployeeId = Guid.Parse("56bac4c3-ef14-4f17-905d-5fb554063561"),
                DeductionId = Guid.Parse("31b87ccb-9864-459d-b1c2-9792a3d10902")
            });

            context.EmployeeDeductions.Add(new Models.EmployeeDeduction()
            {
                Id = Guid.NewGuid(),
                EmployeeId = Guid.Parse("56bac4c3-ef14-4f17-905d-5fb554063561"),
                DeductionId = Guid.Parse("31b87ccb-9864-459d-b1c2-9792a3d10903")
            });


            context.EmployeeDeductions.Add(new Models.EmployeeDeduction()
            {
                Id = Guid.NewGuid(),
                EmployeeId = Guid.Parse("56bac4c3-ef14-4f17-905d-5fb554063562"),
                DeductionId = Guid.Parse("31b87ccb-9864-459d-b1c2-9792a3d10901")
            });

            context.EmployeeDeductions.Add(new Models.EmployeeDeduction()
            {
                Id = Guid.NewGuid(),
                EmployeeId = Guid.Parse("56bac4c3-ef14-4f17-905d-5fb554063562"),
                DeductionId = Guid.Parse("31b87ccb-9864-459d-b1c2-9792a3d10902")
            });

            context.EmployeeDeductions.Add(new Models.EmployeeDeduction()
            {
                Id = Guid.NewGuid(),
                EmployeeId = Guid.Parse("56bac4c3-ef14-4f17-905d-5fb554063562"),
                DeductionId = Guid.Parse("31b87ccb-9864-459d-b1c2-9792a3d10903")
            });

            context.EmployeeDeductions.Add(new Models.EmployeeDeduction()
            {
                Id = Guid.NewGuid(),
                EmployeeId = Guid.Parse("56bac4c3-ef14-4f17-905d-5fb554063562"),
                DeductionId = Guid.Parse("31b87ccb-9864-459d-b1c2-9792a3d10904")
            });

            context.SaveChanges();
        }
    }
}
