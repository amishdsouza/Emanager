using AutoMapper;
using Demo.Service.Dtos;
using Demo.Service.Handlers.RoleHandler;
using Demo.Service.Model;
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

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public ActionResult GetRole(int id)
        {
            var response = _roleInteractor.GetRole(id);
            return Ok(response);
        }

        [HttpPost]
        [Route("api/[controller]")]
        public ActionResult AddRole(RoleDto roleInput)
        {
            var response = _roleInteractor.AddRole(roleInput);
            return Ok(response);
        }


        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public ActionResult DeleteRole(int id)
        {
            var response = _roleInteractor.DeleteRole(id);
            return Ok(response);
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public ActionResult EditRole(int id, EditRoleDto roleInput)
        {
            roleInput.Id = id;
            var response = _roleInteractor.EditRole(roleInput);
            return Ok(response);
        }
    }
}
