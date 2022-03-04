using AutoMapper;
using Demo.Service.Data.Repository.EmployeeRepo;
using Demo.Service.Dtos;
using Demo.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Service.Handlers.EmployeeHandler
{
    public class RoleInteractor : IRoleInteractor
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleInteractor(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public List<RoleDto> GetRoles()
        {
            var employeesOutput = _roleRepository.GetRoles();
            var mappedEmployeesOutput = IMapper.Map<List<RoleDto>>(employeesOutput);
            return mappedEmployeesOutput;
        }
    }
}
