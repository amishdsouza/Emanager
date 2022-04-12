using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Demo.Service.Model;

namespace Demo.Service.Data
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmpRoleMap> EmpRoleMap { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Branch> Branch { get; set; }
        public DbSet<EmpBranchMap> EmpBranchMap { get; set; }
    }
}
