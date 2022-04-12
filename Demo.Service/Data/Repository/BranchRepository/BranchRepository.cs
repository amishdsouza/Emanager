using Demo.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Service.Data.Repository.BranchRepository
{
    public class BranchRepository : IBranchRepository
    {
        private readonly DemoDbContext _context;

        public BranchRepository(DemoDbContext context)
        {
            _context = context;
        }

        public Branch AddBranch(Branch branchInput)
        {
            branchInput.Id = Guid.NewGuid().ToString();
            _context.Branch.Add(branchInput);
            _context.SaveChanges();
            return branchInput;
        }

        public List<Branch> GetBranches()
        {
            return _context.Branch.ToList();
        }

        public Branch GetBranches(string id)
        {
            throw new NotImplementedException();
        }
    }
}
