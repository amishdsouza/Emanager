using AutoMapper;
using Demo.Service.Dtos;
using Demo.Service.Handlers.BranchHandler;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [ApiController]
    public class BranchController : Controller
    {
        private readonly IBranchInteractor _branchInteractor;
        private readonly IMapper _mapper;

        public BranchController(IBranchInteractor branchInteractor, IMapper mapper)
        {
            _branchInteractor = branchInteractor;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Branch/{id}")]
        public ActionResult GetBranches(string id)
        {
            var response = _branchInteractor.GetBranches(id);
            return Ok(response);
        }

        [HttpGet]
        [Route("Branch")]
        public ActionResult GetBranches()
        {
            var response = _branchInteractor.GetBranches();
            return Ok(response);
        }

        [HttpPost]
        [Route("AddBranch")]
        public ActionResult AddBranch(BranchDto branchInput)
        {
            var response = _branchInteractor.AddBranch(branchInput);
            return Ok(response);
        }
    }
}
