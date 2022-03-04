﻿using AutoMapper;
using Demo.Service.Data.Repository.EmployeeRepo;
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

        public Employee DeleteEmployee(Employee employee)
        {
            var employeesOutput = _employeeRepository.DeleteEmployee(employee);
            return employeesOutput;
        }

        public AddDto AddEmployee(AddDto employeeInput)
        {
            var employeeI = _mapper.Map<Employee>(employeeInput);
            var employeesOutput = _employeeRepository.AddEmployee(employeeI);
            var mappedEmployeeOutput = _mapper.Map<AddDto>(employeesOutput);
            return mappedEmployeeOutput;
        }

        public EditDto EditEmployee(EditDto employeeInput)
        {
            var mappedClientInput = _mapper.Map<Employee>(employeeInput);
            var employeesOutput = _employeeRepository.EditEmployee(mappedClientInput);
            var mappedEmployeeOutput = _mapper.Map<EditDto>(employeesOutput);
            return mappedEmployeeOutput;
        }

        public List<EmployeeDto> GetEmployees()
        {
            var employeesOutput = _employeeRepository.GetEmployees();
            var mappedEmployeesOutput = _mapper.Map<List<EmployeeDto>>(employeesOutput);
            return mappedEmployeesOutput;
        }

        public EmployeeDto GetEmployee(int id)
        {
            var employeesOutput = _employeeRepository.GetEmployee(id);
            var mappedEmployeesOutput = _mapper.Map<EmployeeDto>(employeesOutput);
            return mappedEmployeesOutput;
        }
    }
}