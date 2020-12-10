using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoshenJimenez.EmployeesDatabaseSystem.Windows.Models
{
    public class Deduction
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
