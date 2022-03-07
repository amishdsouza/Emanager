using Demo.Service.Dtos;
using Demo.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Role AddRole(Role role)
        {
            _context.Role.Add(role);
            _context.SaveChanges();
            return role;
        }

        public Role DeleteRole(Role role)
        {
            _context.Role.Remove(role);
            _context.SaveChanges();
            return role;
        }

        public Role GetRole(int id)
        {
            var role =  _context.Role.Find(id);
            return role;
        }

        public List<Role> GetRoles()
        {
            return _context.Role.ToList();
        }



        public bool CheckRole(int id)
        {
            bool isAssigned = _context.EmpRoleMap.Any(j => j.Id == id);
            
            return isAssigned;
        }

        public EmpRoleMap GetRoleMapping(int id)
        {
            var deletedRoleMapping = _context.EmpRoleMap.Where(u => (u.RoleID == id)).FirstOrDefault();

            _context.EmpRoleMap.Remove(deletedRoleMapping);
            _context.SaveChanges();

            return deletedRoleMapping;
        }

        public Role EditRole(Role role)
        {
            var existingRole = _context.Role.Find(role.Id);
            if (existingRole != null)
            {
                existingRole.Name = role.Name;
                _context.Role.Update(existingRole);
                _context.SaveChanges();
            }
            return role;
        }
    }
}
