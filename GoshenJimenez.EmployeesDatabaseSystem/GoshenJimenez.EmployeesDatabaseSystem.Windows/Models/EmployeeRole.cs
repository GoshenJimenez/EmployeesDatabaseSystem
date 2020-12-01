using GoshenJimenez.EmployeesDatabaseSystem.Windows.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoshenJimenez.EmployeesDatabaseSystem.Windows.Models
{
    public class EmployeeRole
    {
        public Guid? Id { get; set; } 

        public Guid? EmployeeId { get; set; }
        public UserRole UserRole { get; set; }
    }
}
