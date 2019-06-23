using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PSL.UI.Core.Data.Infrastructure.EF;

namespace PSL.UI.Core.Data.Entities
{
    public class Product : FactoryEntity
    {

        [Required]
        [StringLength(120)]
        public string Name { get; set; }

        [StringLength(800)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Inventory { get; set; }

        public virtual ICollection<Order> Orders { get; set; }=new List<Order>();

        public virtual ICollection<PurchaseInOrder> PurchaseInOrders{ get; set; }=new List<PurchaseInOrder>();

    }
}