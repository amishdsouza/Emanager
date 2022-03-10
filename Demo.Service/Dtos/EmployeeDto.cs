using AutoMapper;
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

    public class AddDto
    {
        public List<int> RoleIDs { get; set; }
        public string Name { get; set; }
        public string EmailID { get; set; }
        public string Gender { get; set; }
    }

    public class EditDto
    {
        public int Id { get; set; }
        public List<int> RoleIDs { get; set; }
        public string Name { get; set; }
        public string EmailID { get; set; }
        public string Gender { get; set; }
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
