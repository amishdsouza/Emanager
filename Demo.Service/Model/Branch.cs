using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Demo.Service.Model
{
    public class Branch
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
