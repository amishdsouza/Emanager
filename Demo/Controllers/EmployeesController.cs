using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Service.Data;
using Demo.Service.Enums;
using AutoMapper;
using Demo.Service.Dtos;
using Demo.Service.Handlers.EmployeeHandler;
using Demo.Service.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Demo.Model
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeInteractor _employeeInteractor;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeInteractor employeeInteractor, IMapper mapper)
        {
            _employeeInteractor = employeeInteractor;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("InitialData")]
        public ActionResult InitialData()
        {
            var response = new CustomResponse<EmployeeInitialDataDto>();
            var employeeInitialData = new EmployeeInitialDataDto()
            {
                Role = _employeeInteractor.GetRoles(),
                EmployeeGenderType = _employeeInteractor.GetGender()
            };

            response.Status = true;
            response.Message = $"Retrieved initial data.";
            response.Result = employeeInitialData;
            return Ok(response);
        }

        [HttpGet]
        [Route("GetByRole/{filterText}")]
        public ActionResult GetEmployeeByRole(string filterText = null)
        {
            var response = _employeeInteractor.GetEmployeeByRole(filterText);
            return Ok(response);
        }


        //getemp by role such as hr, manager

        [HttpGet]
        [Route("GetByGender/{filterText}")]
        public ActionResult GetByGender(string filterText = null)
        {
            var response = _employeeInteractor.GetEmployeeByGender(filterText);
            return Ok(response);
        }

        [HttpGet]
        [Route("EmployeeInformation")]
        public ActionResult GetEmployees(int? pageNumber, int? pageSize, string filterText = null)
        {
            var response = _employeeInteractor.GetEmployees(pageNumber, pageSize, filterText);
            return Ok(response);
        }

        [HttpGet]
        [Route("EmployeeInformationbyId/{id}")]
        public ActionResult GetEmployee(string id)
        {
            var response = _employeeInteractor.GetEmployee(id);
            return Ok(response);
        }

        [HttpPost]
        [Route("AddEmployee")]
        public ActionResult AddEmployee(AddDto employeeInput)
        {
            var response = _employeeInteractor.AddEmployee(employeeInput);
            return Ok(response);
        }

        [HttpPatch]
        [Route("EditEmployee/{id}")]
        public ActionResult EditEmployee(string id, EditDto employeeInput)
        {
            employeeInput.Id = id;
            var response = _employeeInteractor.EditEmployee(employeeInput);
            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public ActionResult DeleteEmployee(string id)
        {
            var response = _employeeInteractor.DeleteEmployee(id);
            return Ok(response);
        }

    }
}
