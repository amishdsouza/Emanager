using Demo.Service.Dtos;
using Demo.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Service.Handlers.BranchHandler
{
    public interface IBranchInteractor
    {
        List<BranchDto> GetBranches();

        BranchDto GetBranches(string id);

        BranchDto AddBranch(BranchDto branchInput);
    }
}
