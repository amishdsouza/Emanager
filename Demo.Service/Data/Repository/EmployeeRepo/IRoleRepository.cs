using Demo.Service.Dtos;
using Demo.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Service.Data.Repository.EmployeeRepo
{
    public interface IRoleRepository
    {
        Role AddRole(Role role);
        Role DeleteRole(Role role);
        Role GetRole(int id);
        List<Role> GetRoles();


        bool CheckRole(int id);
        EmpRoleMap DeletedRoleMapping(int id);

        Role EditRole(Role role);
    }
}
