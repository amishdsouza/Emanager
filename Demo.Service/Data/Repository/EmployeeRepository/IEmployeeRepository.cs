using System;
using System.Collections.Generic;
using System.Text;
using Demo.Service.Dtos;
using Demo.Service.Model;

namespace Demo.Service.Data.Repository.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        List<EmployeeDto> GetEmployees(int? pageNumber, int? pageSize, string filterText = null);

        List<EmployeeDto> GetEmployees(string key);

        int GetTotalNumberOfEmployees();


        EmployeeDto GetEmployee(int id);

        Employee AddEmployee(Employee employee);

        Employee EditEmployee(Employee employee);

        int DeleteEmployee(int id);
        
        void DeleteEmployeeMapping(int id);

        EmployeeDto AddEmployeeDetails(AddDto employeeInput);

        EmployeeDto EditEmployeeDetails(EditDto employeeInput);
    }
}
