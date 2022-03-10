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

        Employee AddEmployee(Employee employee);

        Employee EditEmployee(Employee employee);

        Employee DeleteEmployee(Employee employee);

        void EditEmployeeMapping(EmpRoleMap empRoleID);

        void AddEmployeeMapping(List<int> mapOutput, int employeeId);
        
        void DeleteEmployeeMapping(int id);

        
    }
}
