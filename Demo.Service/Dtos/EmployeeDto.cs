using AutoMapper;
using Demo.Service.Enums;
using Demo.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Service.Dtos
{
    public class EmployeeDto
    {
        public string Name { get; set; }
        public string EmailID { get; set; }
        public string Gender { get; set; }
        public List<string> Roles { get; set; }
    }

    public class GenderBasedDto
    {
        public string Name { get; set; }
        public string EmailID { get; set; }
        public List<string> Roles { get; set; }
    }

    public class RoleBasedDto
    {
        public string Name { get; set; }
        public string EmailID { get; set; }
        public string Gender { get; set; }
    }

    public class AddDto
    {
        public List<string> RoleIDs { get; set; }
        public string Name { get; set; }
        public string EmailID { get; set; }
        public string Gender { get; set; }
    }

    public class EditDto
    {
        public string Id { get; set; }
        public List<string> RoleIDs { get; set; }
        public string Name { get; set; }
        public string EmailID { get; set; }
        public string Gender { get; set; }
    }

    public class UserInfoDto
    {
        public string EmailID { get; set; }
    }

    public class EmployeeInitialDataDto
    {
        public List<RoleDto> Role { get; set; }

        public List<EmployeeGenderType> EmployeeGenderType { get; set; }
    }

    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Employee, AddDto>().ReverseMap();
            CreateMap<Employee, EditDto>().ReverseMap();
        }
    }
}
