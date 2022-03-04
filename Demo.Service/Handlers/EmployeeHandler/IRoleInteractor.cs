using Demo.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Service.Handlers.EmployeeHandler
{
    public interface IRoleInteractor
    {
        List<RoleDto> GetRoles();
    }
}
