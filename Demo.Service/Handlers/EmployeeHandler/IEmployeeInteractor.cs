using Demo.Service.Dtos;
using Demo.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Service.Handlers.EmployeeHandler
{
    public interface IEmployeeInteractor
    {
        List<EmployeeDto> GetEmployees();

        EmployeeDto GetEmployee(int id);

        EmployeeDto AddEmployee(AddDto employeeInput);

        EmployeeDto EditEmployee(EditDto employeeInput);

        Employee DeleteEmployee(Employee employee);
    }
}
