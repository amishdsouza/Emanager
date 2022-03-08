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

        public RoleDto AddRole(RoleDto roleInput)
        {
            var mappedRoleInput = _mapper.Map<Role>(roleInput);
            var rolesOutput = _roleRepository.AddRole(mappedRoleInput);

            var mappedRoleOutput = _mapper.Map <RoleDto>(rolesOutput);
            return mappedRoleOutput;
        }

        public RoleDto GetRole(int id)
        {
            var roleOutput = _roleRepository.GetRole(id);
            var mappedRoleOutput = _mapper.Map<RoleDto>(roleOutput);
            return mappedRoleOutput;
        }

        public List<RoleDto> GetRoles()
        {
            var employeesOutput = _roleRepository.GetRoles();
            var mappedEmployeesOutput = _mapper.Map<List<RoleDto>>(employeesOutput);
            return mappedEmployeesOutput;
        }

        public Role DeleteRole(int id)
        {
            bool isRoleAssigned = _roleRepository.CheckRole(id);
            if (isRoleAssigned ==true)
            {
                var deletedRoleMapping = _roleRepository.DeletedRoleMapping(id);
            }
            var role = _roleRepository.GetRole(id);
            var rolesOutput = _roleRepository.DeleteRole(role);
            return rolesOutput;
        }
        
        public EditRoleDto EditRole(EditRoleDto roleInput)
        {
            var mappedRoleInput = _mapper.Map<Role>(roleInput);
            var employeesOutput = _roleRepository.EditRole(mappedRoleInput);


            var mappedEmployeeOutput = _mapper.Map<EditRoleDto>(employeesOutput);
            return mappedEmployeeOutput;
        }
    }
}
