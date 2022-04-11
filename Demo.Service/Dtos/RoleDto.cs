using AutoMapper;
using Demo.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Service.Dtos
{
    public class RoleDto
    {
        public string Name { get; set; }
    }

    public class EditRoleDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<Role, EditRoleDto>().ReverseMap();

            CreateMap<RoleBasedDto, EmployeeDto>().ReverseMap();
        }
    }
}
