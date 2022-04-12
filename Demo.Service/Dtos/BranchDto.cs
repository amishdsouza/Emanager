using AutoMapper;
using Demo.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Service.Dtos
{
    public class BranchDto
    {
        public string Name { get; set; }
    }

    public class BranchProfile : Profile
    {
        public BranchProfile()
        {
            CreateMap<Branch, BranchDto>().ReverseMap();
        }
    }
}
