using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Service.Enums
{
    public  class EmployeeRoleType : Enumeration
    {
        public static EmployeeRoleType CEO = new EmployeeRoleType(1, "CEO");
        public static EmployeeRoleType CTO = new EmployeeRoleType(2, "CTO");
        public static EmployeeRoleType CMO = new EmployeeRoleType(3, "CMO");
    
    public EmployeeRoleType(int id, string name): base(id, name)
    {

    }


    public static IEnumerable<EmployeeRoleType> List() =>  new[] { CEO, CTO, CMO };
    }
}
