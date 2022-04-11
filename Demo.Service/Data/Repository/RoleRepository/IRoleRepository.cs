using Demo.Service.Dtos;
using Demo.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Service.Data.Repository.RoleRepository
{
    public interface IRoleRepository
    {
        Role AddRole(Role role);
        Role DeleteRole(Role role);
        Role GetRole(string id);
        List<Role> GetRoles();

        bool CheckRole(string id);
        void DeletedRoleMapping(string id);

        Role EditRole(Role role);
    }
}
