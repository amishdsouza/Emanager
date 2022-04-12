using AutoMapper;
using Demo.Service.Data.Repository.BranchRepository;
using Demo.Service.Dtos;
using Demo.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Service.Handlers.BranchHandler
{
    public class BranchInteractor : IBranchInteractor
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IMapper _mapper;

        public BranchInteractor(IBranchRepository branchRepository, IMapper mapper)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
        }
        
        public List<BranchDto> GetBranches()
        {
            var branchOutput = _branchRepository.GetBranches();
            var mappedBranchOutput = _mapper.Map<List< BranchDto>>(branchOutput);
            return mappedBranchOutput;
        }

        public BranchDto GetBranches(string id)
        {
            throw new NotImplementedException();
        }

        public BranchDto AddBranch(BranchDto branchInput)
        {
            var mappedInput = _mapper.Map<Branch>(branchInput);

            var rolesOutput = _branchRepository.AddBranch(mappedInput);

            var mappedOutput = _mapper.Map<BranchDto>(rolesOutput);

            return mappedOutput;
        }
    }
}
