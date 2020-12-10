using GoshenJimenez.EmployeesDatabaseSystem.Windows.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoshenJimenez.EmployeesDatabaseSystem.Windows.DataTransferObjects
{
    public class EmployeeDto
    {
        public Guid? Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public decimal Salary { get; set; }

        public Status Status { get; set; }

        public Assignment Assignment { get; set; }
        public bool IsActive { get; set; }
        public decimal Deductions { get; set; }

        public decimal NetSalary { 
            get
            {
                return this.Salary - this.Deductions;
            }
        }
    }
}
