using Demo.Service.Dtos;
using Demo.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Service.Handlers.RoleHandler
{
    public interface IRoleInteractor
    {
        List<RoleDto> GetRoles();

        RoleDto GetRole(int id);

        RoleDto AddRole(RoleDto roleInput);

        Role DeleteRole(int id);

        EditRoleDto EditRole(EditRoleDto roleInput);
    }
}
