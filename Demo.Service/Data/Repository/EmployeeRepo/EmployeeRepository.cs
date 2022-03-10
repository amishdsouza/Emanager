using Demo.Service.Data.Repository.EmployeeRepo;
using Demo.Service.Dtos;
using Demo.Service.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Demo.Service.Data.Repository.EmployeeRepo
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DemoDbContext _context;

        public EmployeeRepository(DemoDbContext context)
        {
            _context = context;
        }

        public List<EmployeeDto> GetEmployees()
        {
            var res = (from employee in _context.Employee
                       select new EmployeeDto
                       {
                           Name = employee.Name,
                           EmailID = employee.EmailID,
                           Gender = employee.Gender,
                           Roles = (
                                   from empRoleMap in _context.EmpRoleMap
                                   join role in _context.Role
                                   on empRoleMap.RoleID equals role.Id
                                   where empRoleMap.EmployeeID == employee.Id
                                   select role.Name).ToList() 
                       }).ToList();
            return res;
        }

        public EmployeeDto GetEmployee(int id)
        {
            var res = (from employee in _context.Employee
                       where employee.Id == id
                       select new EmployeeDto
                       {
                           Name = employee.Name,
                           EmailID = employee.EmailID,
                           Gender = employee.Gender,
                           Roles = (
                           from empRoleMap in _context.EmpRoleMap
                           join role in _context.Role
                           on empRoleMap.RoleID equals role.Id
                           where empRoleMap.EmployeeID == id
                           select role.Name)
                           .ToList()
                       }).FirstOrDefault();
            return res;
        }
        public Employee AddEmployee(Employee employee)
        {
            _context.Employee.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public Employee EditEmployee(Employee employee)
        {
            var existingEmployee = _context.Employee.Find(employee.Id);
            if(existingEmployee != null)
            {
                existingEmployee.Name=employee.Name;
                existingEmployee.EmailID=employee.EmailID;
                existingEmployee.Gender=employee.Gender;
                _context.SaveChanges();
            }
            return employee;
        }

        public Employee DeleteEmployee(Employee employee)
        {
            _context.Employee.Remove(employee);
            _context.SaveChanges();
            return employee;

        }

        public EmpRoleMap AddEmployeeMapping(EmpRoleMap mapOutput)
        {
           _context.EmpRoleMap.Add(mapOutput);
           _context.SaveChanges();
           return mapOutput;
        }

        public void DeleteEmployeeMapping(int id)
        {
            var deletedRoleMapping = _context.EmpRoleMap.Where(u => (u.EmployeeID == id));
            _context.EmpRoleMap.RemoveRange(deletedRoleMapping);
            _context.SaveChanges();
        }

        public void EditEmployeeMapping(EmpRoleMap empRoleID)
        {
            DeleteEmployeeMapping(empRoleID.EmployeeID);
            AddEmployeeMapping(empRoleID);
        }

        public void AddEmployeeMapping(List<int> mapOutput, int employeeId)
        {
            foreach (var item in mapOutput)
            {
                var empRoleID = new EmpRoleMap()
                {
                    RoleID = item,
                    EmployeeID = employeeId
                };
                _context.EmpRoleMap.AddRange(empRoleID);
            }

            _context.SaveChanges();
        }

       
    }
}
