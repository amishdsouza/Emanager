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

        RoleDto GetRole(string id);

        RoleDto AddRole(RoleDto roleInput);

        Role DeleteRole(string id);

        EditRoleDto EditRole(EditRoleDto roleInput);
    }
}
