using GoshenJimenez.EmployeesDatabaseSystem.Windows.DAL;
using GoshenJimenez.EmployeesDatabaseSystem.Windows.Helpers;
using GoshenJimenez.EmployeesDatabaseSystem.Windows.Models;
using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoshenJimenez.EmployeesDatabaseSystem.Windows.BLL
{
    public static class EmployeeBLL
    {
        private static EmployeesDBContext db = new EmployeesDBContext();

        public static Paged<Models.Employee> Search(int pageIndex = 1, int pageSize = 1, string sortBy = "lastname", string sortOrder = "asc", string assignment = "", string status = "", string keyword = "")
        {
            IQueryable<Employee> allEmployees = (IQueryable<Employee>)db.Employees;
            Paged<Models.Employee> employees = new Paged<Models.Employee>();

            if (!string.IsNullOrEmpty(assignment))
            {
                allEmployees = allEmployees.Where(e => e.Assignment.ToString().ToLower() == assignment.ToLower());
            }

            if (!string.IsNullOrEmpty(status))
            {
                allEmployees = allEmployees.Where(e => e.Status.ToString().ToLower() == status.ToLower());
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                allEmployees = allEmployees.Where(e => e.FirstName.Contains(keyword) || e.LastName.Contains(keyword));
            }

            var queryCount = allEmployees.Count();
            var skip = pageSize * (pageIndex - 1);

            long pageCount = (long)Math.Ceiling((decimal)(queryCount/pageSize));

            if (sortBy.ToLower() == "lastname" && sortOrder.ToLower() == "asc")
            {
                employees.Items = allEmployees.OrderBy(e => e.LastName).Skip(skip).Take(pageSize).ToList();
            }
            else if (sortBy.ToLower() == "lastname" && sortOrder.ToLower() == "desc")
            {
                employees.Items = allEmployees.OrderByDescending(e => e.LastName).Skip(skip).Take(pageSize).ToList();
            }
            else if (sortBy.ToLower() == "salary" && sortOrder.ToLower() == "asc")
            {
                employees.Items = allEmployees.OrderBy(e => e.Salary).Skip(skip).Take(pageSize).ToList();
            }
            else
            {
                employees.Items = allEmployees.OrderByDescending(e => e.Salary).Skip(skip).Take(pageSize).ToList();
            }

            employees.PageCount = pageCount;
            employees.QueryCount = queryCount;
            employees.PageIndex = pageIndex;
            employees.PageSize = pageSize;

            return employees;
        }

        public static Operation Add(Employee employee)
        {
            try
            {
                db.Employees.Add(employee);
                db.SaveChanges();

                return new Operation()
                {
                    Code = "200",
                    Message = "Ok",
                    ReferenceId = employee.Id
                };
            }
            catch(Exception e)
            {
                return new Operation()
                {
                    Code = "500",
                    Message = e.Message
                };
            }
        }

        public static Operation Update(Employee newRecord)
        {
            try
            {
                Employee oldRecord = db.Employees.FirstOrDefault(e => e.Id == newRecord.Id);

                if(oldRecord != null)
                {
                    oldRecord.Assignment = newRecord.Assignment;
                    oldRecord.EmailAddress = newRecord.EmailAddress;
                    oldRecord.FirstName = newRecord.FirstName;
                    oldRecord.LastName = newRecord.LastName;
                    oldRecord.Salary = newRecord.Salary;
                    oldRecord.Status = newRecord.Status;

                    db.SaveChanges();

                    return new Operation()
                    {
                        Code = "200",
                        Message = "OK"
                    };
                }


                return new Operation()
                {
                    Code = "500",
                    Message = "Not found"
                };
            }
            catch(Exception e)
            {
                return new Operation()
                {
                    Code = "500",
                    Message = e.Message
                };
            }
        }

        public static Operation Delete(Guid? employeeId)
        {
            try
            {
                Employee oldRecord = db.Employees.FirstOrDefault(e => e.Id == employeeId);

                if (oldRecord != null)
                {
                    db.Employees.Remove(oldRecord);

                    db.SaveChanges();

                    return new Operation()
                    {
                        Code = "200",
                        Message = "OK"
                    };
                }

                return new Operation()
                {
                    Code = "500",
                    Message = "Not found"
                };
            }
            catch (Exception e)
            {
                return new Operation()
                {
                    Code = "500",
                    Message = e.Message
                };
            }
        }
    }
}
