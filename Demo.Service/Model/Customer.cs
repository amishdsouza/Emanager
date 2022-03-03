using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Service.Model
{
    public class Customer
    {
        [Key]
        public long ID { get; set; }
        public string Name { get; set; }
    }
}
