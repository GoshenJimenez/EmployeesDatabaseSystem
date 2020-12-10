using GoshenJimenez.EmployeesDatabaseSystem.Windows.DAL;
using GoshenJimenez.EmployeesDatabaseSystem.Windows.DataTransferObjects;
using GoshenJimenez.EmployeesDatabaseSystem.Windows.Helpers;
using GoshenJimenez.EmployeesDatabaseSystem.Windows.Models;
using GoshenJimenez.EmployeesDatabaseSystem.Windows.Models.Enums;
using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt = DevOne.Security.Cryptography.BCrypt;

namespace GoshenJimenez.EmployeesDatabaseSystem.Windows.BLL
{
    public static class EmployeeBLL
    {
        private static EmployeesDBContext db = new EmployeesDBContext();

        public static Paged<EmployeeDto> Search(int pageIndex = 1, int pageSize = 1, string sortBy = "lastname", string sortOrder = "asc", string assignment = "", string status = "", string keyword = "")
        {
            IQueryable<Employee> allEmployees = (IQueryable<Employee>)db.Employees;
            Paged<Models.Employee> employees = new Paged<Models.Employee>();

            allEmployees = allEmployees.Where(e => e.IsActive == true);

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

            var result = new Paged<EmployeeDto>();
            result.PageCount = pageCount;
            result.QueryCount = queryCount;
            result.PageIndex = pageIndex;
            result.PageSize = pageSize;
            result.Items = new List<EmployeeDto>();

            foreach(var employee in employees.Items)
            {
                var deductions = db.EmployeeDeductions.Include("Deduction").Where(e => e.EmployeeId == employee.Id).ToList();
                decimal totalDeductions = 0;

                foreach(var deduction in deductions)
                {
                    totalDeductions = totalDeductions + deduction.Deduction.Price;
                }

                result.Items.Add(new EmployeeDto()
                {
                    Id = employee.Id,
                    Deductions = totalDeductions,
                    Salary = employee.Salary,
                    Status = employee.Status,
                    Assignment = employee.Assignment,
                    EmailAddress = employee.EmailAddress,
                    FirstName = employee.FirstName,
                    IsActive = employee.IsActive,
                    LastName = employee.LastName,
                });
            }

            return result;
        }

        public static Operation Add(Employee employee)
        {
            try
            {
                employee.IsActive = true;
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
                    oldRecord.IsActive = true;

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

        public static Employee GetById(Guid? id)
        {
            return db.Employees.FirstOrDefault(e => e.Id == id);
        }

        public static List<UserRole> GetRoles(Guid? id)
        {
            return db.EmployeeRoles.Where(r => r.EmployeeId == id).Select(r => r.UserRole).ToList();
        }

        public static Operation Deactivate(Guid? employeeId)
        {
            try
            {
                Employee oldRecord = db.Employees.FirstOrDefault(e => e.Id == employeeId);

                if (oldRecord != null)
                {
                    oldRecord.IsActive = false;                   

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


        public static Operation Login(string emailAddress = "", string password = "")
        {
            if (string.IsNullOrEmpty(emailAddress))
            {
                return new Operation()
                {
                    Code = "500",
                    Message = "Invalid Login"
                };
            }

            if (string.IsNullOrEmpty(password))
            {
                return new Operation()
                {
                    Code = "500",
                    Message = "Invalid Login"
                };
            }

            try
            {
                Employee user = db.Employees.FirstOrDefault(e => e.EmailAddress.ToLower() == emailAddress.ToLower());

                if (user == null)
                {
                    return new Operation()
                    {
                        Code = "500",
                        Message = "Invalid Login"
                    };
                }

                if (BCrypt.BCryptHelper.CheckPassword(password, user.Password))
                {
                    return new Operation()
                    {
                        Code = "200",
                        Message = "Successful Login",
                        ReferenceId = user.Id
                    };
                }

                return new Operation()
                {
                    Code = "500",
                    Message = "Invalid Login"
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
