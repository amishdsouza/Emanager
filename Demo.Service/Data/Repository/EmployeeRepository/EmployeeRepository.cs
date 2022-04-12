using AutoMapper;
using Demo.Service.Data.Repository.EmployeeRepository;
using Demo.Service.Dtos;
using Demo.Service.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Demo.Service.Data.Repository.EmployeeRepository
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

        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid().ToString();
            _context.Employee.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public Employee EditEmployee(Employee employee)
        {
            var existingEmployee = _context.Employee.Find(employee.Id);
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.EmailID = employee.EmailID;
                existingEmployee.Gender = employee.Gender;
                _context.SaveChanges();
            }
            return employee;
        }

        public int DeleteEmployee(string id)
        {
            int deleted = 0;
            var existingEmployee = _context.Employee.Find(id);
            DeleteEmployeeMapping(id);

            if (existingEmployee != null)
            {
                existingEmployee.IsDeleted = true;
            }
            //_context.Employee.Remove(existingEmployee);
            deleted = _context.SaveChanges();
            return deleted;
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

        public void AddEmployeeMapping(List<string> mapOutput, string employeeId)
        {
            foreach (var item in mapOutput)
            {
                var empRoleID = new EmpRoleMap()
                {
                    RoleID = item,
                    EmployeeID = employeeId
                };
                empRoleID.Id = Guid.NewGuid().ToString();

                _context.EmpRoleMap.AddRange(empRoleID);
            }
            _context.SaveChanges();
        }

        public void DeleteEmployeeMapping(string id)
        {
            var deletedRoleMapping = _context.EmpRoleMap.Where(u => (u.EmployeeID == id));
            _context.EmpRoleMap.RemoveRange(deletedRoleMapping);
            _context.SaveChanges();
        }

        public EmployeeDto GetEmployee(string id)
        {
            var res = (from employee in _context.Employee
                       where employee.Id == id && !employee.IsDeleted
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
                       })
                       .FirstOrDefault();
            return res;
        }

        public int GetTotalNumberOfEmployees()
        {
            int totalCount = (from employee in _context.Employee where !employee.IsDeleted select employee.Id).Count();
            return totalCount;
        }

        public List<EmployeeDto> GetEmployees(int? pageNumber, int? pageSize, string filterText = null)
        {
            var employeesrole = new List<EmployeeDto>();
            if (!string.IsNullOrEmpty(filterText))
            {
                employeesrole = GetEmployees(filterText);
                if (pageNumber.HasValue && pageSize.HasValue)
                    employeesrole = employeesrole.Skip((pageNumber.Value - 1) * pageSize.Value)
                                                 .Take(pageSize.Value)
                                                 .ToList();
                else if (pageSize.HasValue)
                    employeesrole = employeesrole.Take(pageSize.Value)
                                                  .ToList();
            }
            else
            {
                if (pageNumber.HasValue && pageSize.HasValue)
                    employeesrole = (from employee in _context.Employee
                                    .Where(b => !b.IsDeleted)
                                    .Skip((pageNumber.Value - 1) * pageSize.Value)
                                    .Take(pageSize.Value)


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

                else if (pageSize.HasValue)
                    employeesrole = (from employee in _context.Employee.Take(pageSize.Value)
                                     where !employee.IsDeleted
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

                else employeesrole = (from employee in _context.Employee
                                      where !employee.IsDeleted
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
            }
            return employeesrole;
        }

        public List<EmployeeDto> GetEmployees(string key)
        {
            var employees = (from employee in _context.Employee.Where(b => !string.IsNullOrEmpty(b.Name) && !string.IsNullOrEmpty(key) && b.Name.ToLower().Contains(key.ToLower()) && !b.IsDeleted)
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
            return employees;
        }

        public bool CheckIfUserDetailsExists(string EmailID)
        {
            bool checkIfExisting = _context.Employee.Any(u => u.EmailID == EmailID);
            return checkIfExisting;
        }

        public List<GenderBasedDto> GetEmployeeByGender(string filterText)
        {
            var employees = (from employee in _context.Employee.Where(b => !string.IsNullOrEmpty(b.Gender)
                             && !string.IsNullOrEmpty(filterText)
                             && b.Gender.ToLower().Equals(filterText.ToLower())
                             && !b.IsDeleted)
                             select new GenderBasedDto
                             {
                                 Name = employee.Name,
                                 EmailID = employee.EmailID,
                                 Roles = (
                                       from empRoleMap in _context.EmpRoleMap
                                       join role in _context.Role
                                       on empRoleMap.RoleID equals role.Id
                                       where empRoleMap.EmployeeID == employee.Id
                                       select role.Name).ToList()
                             }).ToList();
            return employees;
        }

        public List<RoleBasedDto> GetEmployeeByRole(string filterText)
        {
            var employees = (from role in _context.Role
                             where role.Name == filterText

                             from empRoleMap in _context.EmpRoleMap
                             join emp in _context.Employee

                             on empRoleMap.EmployeeID equals emp.Id
                             where empRoleMap.RoleID == role.Id

                             select new RoleBasedDto
                             {
                                 Name = emp.Name,
                                 EmailID = emp.EmailID,
                                 Gender = emp.Gender,

                             }).ToList();
            return employees;
        }



        public EmployeeWithBranchDto AddEmployeeWithBranchDetails(EmployeeWithBranchDto employeeInput)
        {
            var mappedEmployeeOutput = _mapper.Map<Employee>(employeeInput);
            var employeesOutput = AddEmployee(mappedEmployeeOutput);

            AddEmployeeMapping(employeeInput.RoleIDs, employeesOutput.Id);

            AddBranchMapping(employeeInput.BranchID, employeesOutput.Id);

            return employeeInput;
        }

        public void AddBranchMapping(string branchId, string employeeId)
        {
            var empBranch = new EmpBranchMap()
            {
                EmployeeID = employeeId,
                BranchID = branchId
                
            };
            empBranch.Id = Guid.NewGuid().ToString();
            _context.EmpBranchMap.AddRange(empBranch);
            _context.SaveChanges();
        }

        public List<EmployeeWithBranchDto> GetEmployeeAndBranch(string id = null)
        {
            var res = new List<EmployeeWithBranchDto>();

            if (!string.IsNullOrEmpty(id)) 
            { 
                res = (from employee in _context.Employee
                           where employee.Id == id && !employee.IsDeleted

                           from empRoleMap in _context.EmpRoleMap
                           join roleInformation in _context.Role 
                           on empRoleMap.RoleID equals roleInformation.Id
                           where empRoleMap.EmployeeID == id

                           from empBranchMap in _context.EmpBranchMap
                           join branchInformation in _context.Branch
                           on empBranchMap.BranchID equals branchInformation.Id
                           where empBranchMap.EmployeeID == id

                           select new EmployeeWithBranchDto
                           {
                               Name = employee.Name,
                               EmailID = employee.EmailID,
                               Gender = employee.Gender,
                               BranchID = branchInformation.Name,

                           }).ToList();
                return res;
            }
            else
            {
                res = (from employee in _context.Employee
                        join empBranchMap in _context.EmpBranchMap on employee.Id equals empBranchMap.EmployeeID into bj
                        from empBranchMap in bj.DefaultIfEmpty()

                        join branchInformation in _context.Branch
                        on empBranchMap.BranchID equals branchInformation.Id 

                       select new EmployeeWithBranchDto
                       {
                            Name = employee.Name,
                            EmailID = employee.EmailID,
                            Gender = employee.Gender,
                            BranchID = branchInformation.Name,
                           
                           
                            RoleIDs = (
                                        from empRoleMap in _context.EmpRoleMap
                                        join role in _context.Role
                                        on empRoleMap.RoleID equals role.Id
                                        where empRoleMap.EmployeeID == employee.Id
                                        select role.Name).ToList()

                       }).ToList();
                return res;
            }
        }

    }
}
