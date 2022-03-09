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

        Employee DeleteEmployee(Employee employee);

        EmployeeDto EditEmployee(EditDto employeeInput);

        AddDto AddEmployee(AddDto employeeInput);
    }
}
