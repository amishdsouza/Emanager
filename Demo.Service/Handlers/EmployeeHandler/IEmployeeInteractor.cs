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

        //AddDto AddEmployee(AddDto employeeInput);

        EditDto EditEmployee(EditDto employeeInput);

        AddEmployeeDto AddEmployee(AddEmployeeDto employeeInput);
    }
}
