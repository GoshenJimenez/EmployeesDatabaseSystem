using GoshenJimenez.EmployeesDatabaseSystem.Windows.DAL;
using GoshenJimenez.EmployeesDatabaseSystem.Windows.DataTransferObjects;
using GoshenJimenez.EmployeesDatabaseSystem.Windows.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoshenJimenez.EmployeesDatabaseSystem.Windows.BLL
{
    public class DeductionBLL
    {
        private static EmployeesDBContext db = new EmployeesDBContext();

        public static List<EmployeeDeductionDto> List(Guid? employeeId)
        {
            return db.EmployeeDeductions.Include("Employee").Include("Deduction")
                                                .Where(e => e.EmployeeId == employeeId)
                                                .Select(e => new EmployeeDeductionDto()
                                                    {
                                                        Id = e.Id,
                                                        EmployeeId = e.EmployeeId,
                                                        EmployeeName = e.Employee.FirstName + " " + e.Employee.LastName,
                                                        DeductionId = e.DeductionId,
                                                        DeductionName = e.Deduction.Name,
                                                        DeductionPrice = e.Deduction.Price
                                                }
                                                ).ToList();
        }
    }
}
