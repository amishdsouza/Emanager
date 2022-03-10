using AutoMapper;
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

        private readonly IMapper _mapper;

        public EmployeeRepository(DemoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

        public void DeleteEmployee(int id)
        {
            var existingEmployee = _context.Employee.Find(id);
            _context.Employee.Remove(existingEmployee);
            DeleteEmployeeMapping(id);
            _context.SaveChanges();
        }

        public EmployeeDto AddEmployeeDetails(AddDto employeeInput)
        {
            var mappedEmployeeOutput = _mapper.Map<Employee>(employeeInput);
            var employeesOutput = AddEmployee(mappedEmployeeOutput);

            AddEmployeeMapping(employeeInput.RoleIDs, employeesOutput.Id);
            return GetEmployee(employeesOutput.Id);
        }

        public EmployeeDto EditEmployeeDetails(EditDto employeeInput)
        {
            var mappedEmployeeOutput = _mapper.Map<Employee>(employeeInput);
            var employeeOutput = EditEmployee(mappedEmployeeOutput);

            DeleteEmployeeMapping(employeeOutput.Id);

            AddEmployeeMapping(employeeInput.RoleIDs, employeeOutput.Id);

            return GetEmployee(employeeInput.Id);
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

        public void DeleteEmployeeMapping(int id)
        {
            var deletedRoleMapping = _context.EmpRoleMap.Where(u => (u.EmployeeID == id));
            _context.EmpRoleMap.RemoveRange(deletedRoleMapping);
            _context.SaveChanges();
        }
    }
}
