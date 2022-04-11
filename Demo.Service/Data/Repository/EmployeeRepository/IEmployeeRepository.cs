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


        EmployeeDto GetEmployee(string id);

        Employee AddEmployee(Employee employee);

        Employee EditEmployee(Employee employee);

        int DeleteEmployee(string id);

        void DeleteEmployeeMapping(string id);

        EmployeeDto AddEmployeeDetails(AddDto employeeInput);

        EmployeeDto EditEmployeeDetails(EditDto employeeInput);

        bool CheckIfUserDetailsExists(string EmailID);

        List<GenderBasedDto> GetEmployeeByGender(string filterText);

        List<RoleBasedDto> GetEmployeeByRole(string filterText);
    }
}
