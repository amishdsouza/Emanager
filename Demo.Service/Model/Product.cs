using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Service.Model
{
    public class Product
    {
        [Key]
        public long ID { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
    }

    public class Product1
    {
        [Key]
        public long ID { get; set; }
        public string Name { get; set; }
        public long CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customer Customers { get; set; }
    }
}
