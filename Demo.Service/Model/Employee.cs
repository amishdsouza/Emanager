using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Service.Model
{
    public class Employee
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string EmailID { get; set; }
        public string Gender { get; set; }
        public bool IsDeleted { get; set; }
    }
}
