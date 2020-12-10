using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoshenJimenez.EmployeesDatabaseSystem.Windows.DataTransferObjects
{
    public class EmployeeDeductionDto
    {
        public Guid? Id { get; set; }

        public Guid? EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public Guid? DeductionId { get; set; }

        public string DeductionName { get; set; }

        public decimal DeductionPrice { get; set; }
    }
}
