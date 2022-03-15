using AutoMapper;
using Demo.Service.Data.Repository.EmployeeRepository;
using Demo.Service.Dtos;
using Demo.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Service.Handlers.EmployeeHandler
{
    public class EmployeeInteractor : IEmployeeInteractor
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeInteractor(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public CustomResponse<List<EmployeeDto>> GetEmployees()
        {
            var response = new CustomResponse<List<EmployeeDto>>();
            response.Result = _employeeRepository.GetEmployees();
            
            if (response.Result != null)
            {
                response.Message = $"{response.Result.Count} Employees data is retrieved successfully.";
                response.Status = true;
            }
            else {
                response.Message = $"No Employees data is available.";
                response.Status = false;
            }
            return response;
        }

        public CustomResponse<EmployeeDto> GetEmployee(int id)
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

        public CustomResponse<int> DeleteEmployee(int id)
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
    }
}
