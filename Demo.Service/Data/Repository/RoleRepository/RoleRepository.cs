using Demo.Service.Dtos;
using Demo.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Service.Data.Repository.RoleRepository
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
            role.Id = Guid.NewGuid().ToString();
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

        public Role GetRole(string id)
        {
            var role = _context.Role.Find(id);
            return role;
        }

        public List<Role> GetRoles()
        {
            return _context.Role.ToList();
        }



        public bool CheckRole(string id)
        {
            bool isAssigned = _context.EmpRoleMap.Any(j => j.Id == id);

            return isAssigned;
        }

        public void DeletedRoleMapping(string id)
        {
            var deletedRoleMapping = _context.EmpRoleMap.Where(u => (u.RoleID == id));
            _context.EmpRoleMap.RemoveRange(deletedRoleMapping);
            _context.SaveChanges();
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
