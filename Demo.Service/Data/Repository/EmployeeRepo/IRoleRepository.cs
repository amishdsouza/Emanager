using Demo.Service.Dtos;
using Demo.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Service.Data.Repository.EmployeeRepo
{
    public interface IRoleRepository
    {
        List<RoleDto> GetRoles();
    }
}
