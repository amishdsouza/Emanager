using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Service.Data;
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
        [Route("api/[controller]")]
        public ActionResult GetEmployees()
        {
            CustomResponse<List <EmployeeDto>> response = _employeeInteractor.GetEmployees();
            return Ok(response);
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public ActionResult GetEmployee(int id)
        {
            var response = _employeeInteractor.GetEmployee(id);
            return Ok(response);
        }

        [HttpPost]
        [Route("api/[controller]")]
        public ActionResult AddEmployee(AddDto employeeInput)
        {
            var response = _employeeInteractor.AddEmployee(employeeInput);
            return Ok(response);
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public ActionResult EditEmployee(int id, EditDto employeeInput)
        {
            employeeInput.Id = id;
            var response = _employeeInteractor.EditEmployee(employeeInput);
            return Ok(response);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            var response = _employeeInteractor.DeleteEmployee(id);
            return Ok(response);
        }

    }
}
