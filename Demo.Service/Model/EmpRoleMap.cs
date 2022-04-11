using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Demo.Service.Model
{
    public class EmpRoleMap
    {
        [Key]
        public string Id { get; set; }


        public string EmployeeID { get; set; }
        [ForeignKey("EmployeeID")]
        public virtual Employee Employees { get; set; }

        public string RoleID { get; set; }
        [ForeignKey("RoleID")]
        public virtual Role Roles { get; set; }

    }
}
