using System;
using System.Collections.Generic;
using System.Text;
using Demo.Service.Dtos;
using Demo.Service.Model;

namespace Demo.Service.Data.Repository.EmployeeRepo
{
    public interface IEmployeeRepository
    {
        List<EmployeeDto> GetEmployees();

        EmployeeDto GetEmployee(int id);

        Employee DeleteEmployee(Employee employee);
        
        Employee AddEmployee(Employee employee);

        Employee EditEmployee(Employee employee);
    }
}
