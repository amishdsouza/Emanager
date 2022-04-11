using Demo.Service.Dtos;
using Demo.Service.Enums;
using Demo.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Service.Handlers.EmployeeHandler
{
    public interface IEmployeeInteractor
    {
        List<RoleDto> GetRoles();

        List<EmployeeGenderType> GetGender();

        CustomResponse<PaginationDetails<List<EmployeeDto>>> GetEmployees(int? pageNumber, int? pageSize, string filterText = null);

        CustomResponse<EmployeeDto> GetEmployee(string id);

        CustomResponse<EmployeeDto> AddEmployee(AddDto employeeInput);

        CustomResponse<EmployeeDto> EditEmployee(EditDto employeeInput);

        CustomResponse<int> DeleteEmployee(string id);

        CustomResponse<List<GenderBasedDto>> GetEmployeeByGender(string filterText);

        CustomResponse<List<RoleBasedDto>> GetEmployeeByRole(string filterText);
    }
}
