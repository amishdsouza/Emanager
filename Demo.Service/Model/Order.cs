using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Service.Model
{
    public class Order
    {
        [Key]
        public long ID { get; set; }
        public string Qty { get; set; }

        public long CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customer Customers { get; set; }
        
        public long ProductID { get; set; }
        [ForeignKey("ProductID")]
        public virtual Product Products { get; set; }
    }
}
