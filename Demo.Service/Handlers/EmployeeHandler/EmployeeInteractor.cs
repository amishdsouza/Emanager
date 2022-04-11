using AutoMapper;
using Demo.Service.Data.Repository.EmployeeRepository;
using Demo.Service.Data.Repository.RoleRepository;
using Demo.Service.Dtos;
using Demo.Service.Enums;
using Demo.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Service.Handlers.EmployeeHandler
{
    public class EmployeeInteractor : IEmployeeInteractor
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public EmployeeInteractor(IEmployeeRepository employeeRepository, IMapper mapper, IRoleRepository roleRepository)
        {
            _employeeRepository = employeeRepository;
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public CustomResponse<PaginationDetails<List<EmployeeDto>>> GetEmployees(int? pageNumber, int? pageSize, string filterText = null)
        {
            var response = new CustomResponse<PaginationDetails<List<EmployeeDto>>>();

            var employeesOutput = _employeeRepository.GetEmployees(pageNumber, pageSize, filterText);


            var paginationDetails = new PaginationDetails<List<EmployeeDto>>();
            paginationDetails.Values = employeesOutput;


            if (!string.IsNullOrEmpty(filterText))
                paginationDetails.TotalCount = _employeeRepository.GetEmployees(filterText).Count;
            else
                paginationDetails.TotalCount = _employeeRepository.GetTotalNumberOfEmployees();



            response.Status = true;
            response.Result = paginationDetails;

            if (response.Result != null)
            {
                response.Message = $"{paginationDetails.Values.Count} Employees data is retrieved successfully.";
                response.Status = true;
            }
            else
            {
                response.Message = $"No Employees data is available.";
                response.Status = false;
            }
            return response;
        }

        public CustomResponse<EmployeeDto> GetEmployee(string id)
        {
            var response = new CustomResponse<EmployeeDto>();
            response.Result = _employeeRepository.GetEmployee(id);
            if (response.Result != null)
            {
                response.Message = $"Employee data is retrieved successfully.";
                response.Status = true;
            }
            else
            {
                response.Message = $"No Employees data is available.";
                response.Status = false;
            }
            return response;
        }

        public CustomResponse<EmployeeDto> AddEmployee(AddDto employeeInput)
        {
            var response = new CustomResponse<EmployeeDto>();

            foreach (string s in employeeInput.RoleIDs)
            {
                if (string.IsNullOrEmpty(s))
                {
                    response.Message += $"Role field cannot be null. ";
                    return response;
                }
            }

            if (string.IsNullOrEmpty(employeeInput.Name)
                || string.IsNullOrEmpty(employeeInput.Gender)
                || string.IsNullOrEmpty(employeeInput.EmailID)
                || employeeInput.RoleIDs.Count == 0)
            {
                response.Status = false;
                if (string.IsNullOrEmpty(employeeInput.Name))
                    response.Message = $"Name field cannot be empty. ";

                if (string.IsNullOrEmpty(employeeInput.EmailID))
                    response.Message += $"Email field cannot be empty. ";

                if (string.IsNullOrEmpty(employeeInput.Gender))
                    response.Message += $"Gender field cannot be empty. ";

                if (employeeInput.RoleIDs.Count == 0)
                {
                    response.Message += $"Role field cannot be empty. ";
                    return response;
                }
            }



            var ifUserDetailsExists = _employeeRepository.CheckIfUserDetailsExists(employeeInput.EmailID);
            if (ifUserDetailsExists)
            {
                response.Message += $"Email Address already existing. ";
                return response;
            }

            response.Result = _employeeRepository.AddEmployeeDetails(employeeInput);
            if (response.Result != null)
            {
                response.Message = $"Employee data is added successfully.";
                response.Status = true;
            }
            else
            {
                response.Message = $"Employees data is not added.";
                response.Status = false;
            }
            return response;
        }

        public CustomResponse<EmployeeDto> EditEmployee(EditDto employeeInput)
        {
            var response = new CustomResponse<EmployeeDto>();

            if (string.IsNullOrEmpty(employeeInput.Name)
                || string.IsNullOrEmpty(employeeInput.EmailID)
                || string.IsNullOrEmpty(employeeInput.Gender)
                || employeeInput.RoleIDs == null)
            {
                response.Status = false;
                if (string.IsNullOrEmpty(employeeInput.Name))
                    response.Message = $"Name field cannot be empty. ";

                if (string.IsNullOrEmpty(employeeInput.EmailID))
                    response.Message += $"Email field cannot be empty. ";

                if (string.IsNullOrEmpty(employeeInput.Gender))
                    response.Message += $"Gender field cannot be empty. ";

                if (employeeInput.RoleIDs == null)
                    response.Message += $"Role field cannot be empty. ";

                return response;
            }

            var ifUserDetailsExists = _employeeRepository.CheckIfUserDetailsExists(employeeInput.EmailID);
            if (ifUserDetailsExists)
            {
                response.Message += $"Email Address already existing. ";
                return response;
            }


            response.Result = _employeeRepository.EditEmployeeDetails(employeeInput);
            if (response.Result != null)
            {
                response.Message = $"Employee data is updated successfully.";
                response.Status = true;
            }
            else
            {
                response.Message = $"Employees data is not updated.";
                response.Status = false;
            }
            return response;
        }

        public CustomResponse<int> DeleteEmployee(string id)
        {
            var response = new CustomResponse<int>();
            int deleted = _employeeRepository.DeleteEmployee(id);
            if (deleted != 0)
            {
                response.Message = $"Employee with ID : {id} is removed";
                response.Status = true;
                response.Result = deleted;
            }
            else
            {
                response.Message = $"Employees data is not deleted.";
                response.Status = false;
            }
            return response;
        }


        //initial data
        public List<RoleDto> GetRoles()
        {
            var roleTypes = _roleRepository.GetRoles();
            var mappedOutput = _mapper.Map<List<RoleDto>>(roleTypes);
            return mappedOutput;
        }


        public List<EmployeeGenderType> GetGender()
        {
            var genderTypes = EmployeeGenderType.List().ToList();
            return genderTypes;
        }



        public CustomResponse<List<GenderBasedDto>> GetEmployeeByGender(string filterText)
        {
            var response = new CustomResponse<List<GenderBasedDto>>();

            var employeesOutput = _employeeRepository.GetEmployeeByGender(filterText);

            response.Status = true;
            response.Result = employeesOutput;

            if (response.Result != null)
            {
                response.Message = $"{employeesOutput.Count} Employees data for {filterText} is retrieved successfully.";
                response.Status = true;
            }
            else
            {
                response.Message = $"No Employees data is available.";
                response.Status = false;
            }
            return response;
        }

        public CustomResponse<List<RoleBasedDto>> GetEmployeeByRole(string filterText)
        {
            var response = new CustomResponse<List<RoleBasedDto>>();

            var employeesOutput = _employeeRepository.GetEmployeeByRole(filterText);

            response.Status = true;
            response.Result = employeesOutput;

            if (response.Result != null)
            {
                response.Message = $"{employeesOutput.Count} Employees data for {filterText} role is retrieved successfully.";
                response.Status = true;
            }
            else
            {
                response.Message = $"No Employees data is available.";
                response.Status = false;
            }
            return response;
        }
    }
}
