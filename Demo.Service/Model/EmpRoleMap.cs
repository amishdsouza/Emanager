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
        public int Id { get; set; }


        public int EmployeeID { get; set; }
        [ForeignKey("EmployeeID")]
        public virtual Employee Employees { get; set; }

        public int RoleID { get; set; }
        [ForeignKey("RoleID")]
        public virtual Role Roles { get; set; }

    }
}
