using GoshenJimenez.EmployeesDatabaseSystem.Windows.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoshenJimenez.EmployeesDatabaseSystem.Windows.Helpers
{
    public static class ProgramUser
    {
        public static Guid? Id { get; set; }
        public static string EmailAddress { get; set; }
        public static string FirstName { get; set; }
        public static string LastName { get; set; }

        public static string FullName { get
            {
                return FirstName + " " + LastName;
            } 
        }
        public static List<UserRole> Roles { get; set; }
    }
}
