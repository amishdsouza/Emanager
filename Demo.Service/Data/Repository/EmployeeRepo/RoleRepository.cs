using Demo.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Service.Data.Repository.EmployeeRepo
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DemoDbContext _context;

        public RoleRepository(DemoDbContext context)
        {
            _context = context;
        }


        public List<RoleDto> GetRoles()
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
                                   select role.Name).ToList() //roledto
                       }).ToList();
            return res;
        }
    }
}
