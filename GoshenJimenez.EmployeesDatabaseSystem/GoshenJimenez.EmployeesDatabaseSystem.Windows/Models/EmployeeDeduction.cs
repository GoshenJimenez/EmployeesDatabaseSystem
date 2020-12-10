using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoshenJimenez.EmployeesDatabaseSystem.Windows.Models
{
    public class EmployeeDeduction
    {
        public Guid? Id { get; set; }

        public Guid? EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public Guid? DeductionId { get; set; }

        public Deduction Deduction { get; set; }
    }
}
