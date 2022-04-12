using Demo.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Service.Data.Repository.BranchRepository
{
    public interface IBranchRepository
    {
        Branch GetBranches(string id);

        List<Branch> GetBranches();
        
        Branch AddBranch(Branch BranchInput);
    }
}
