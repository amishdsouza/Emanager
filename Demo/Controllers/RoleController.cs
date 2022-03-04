using AutoMapper;
using Demo.Service.Dtos;
using Demo.Service.Handlers.EmployeeHandler;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    [ApiController]
    public class RoleController : Controller
    {
        private readonly IRoleInteractor _roleInteractor;
        private readonly IMapper _mapper;

        public RoleController(IRoleInteractor roleInteractor, IMapper mapper)
        {
            _roleInteractor = roleInteractor;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public ActionResult GetRoles()
        {
            List<RoleDto> response = _roleInteractor.GetRoles();
            return Ok(response);
        }
    }
}
