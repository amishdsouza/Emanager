using Demo.Service.Dtos;
using Demo.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Service.Handlers.EmployeeHandler
{
    public interface IEmployeeInteractor
    {
        CustomResponse<PaginationDetails<List<EmployeeDto>>> GetEmployees(int? pageNumber, int? pageSize, string filterText = null);

        CustomResponse<EmployeeDto> GetEmployee(int id);

        CustomResponse<EmployeeDto> AddEmployee(AddDto employeeInput);

        CustomResponse<EmployeeDto> EditEmployee(EditDto employeeInput);

        CustomResponse<int> DeleteEmployee(int id);
    }
}
