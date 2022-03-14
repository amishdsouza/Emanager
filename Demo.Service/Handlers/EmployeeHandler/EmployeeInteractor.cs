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
            var count = 0;
            response.Result = _employeeRepository.GetEmployees();
            
            if (response.Result != null)
            {
                foreach (var item in response.Result)
                {
                    count++;
                }

                response.Message = $"{count} Employees data is retrieved successfully.";
                response.Status = true;
            }
            else {
                response.Message = $"No Employees data is available.";
                response.Status = false;
            }
            return response;
        }

        public EmployeeDto GetEmployee(int id)
        {



            var employeesOutput = _employeeRepository.GetEmployee(id);
            var mappedEmployeesOutput = _mapper.Map<EmployeeDto>(employeesOutput);
            return mappedEmployeesOutput;
        }

        public EmployeeDto AddEmployee(AddDto employeeInput)
        {
            var mappedEmployeeOutput = _employeeRepository.AddEmployeeDetails(employeeInput);
            return mappedEmployeeOutput;
        }

        public EmployeeDto EditEmployee(EditDto employeeInput)
        {
            var employeesOutput = _employeeRepository.EditEmployeeDetails(employeeInput);
            return employeesOutput;
        }

        public void DeleteEmployee(int id)
        {
            _employeeRepository.DeleteEmployee(id);
        }
    }
}
