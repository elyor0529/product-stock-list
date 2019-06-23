using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using PSL.UI.Core.Data.Infrastructure.EF;

namespace PSL.UI.Core.Data.Entities
{
    public class Purchase : AuditEntity
    {

        public DateTime Date { get; set; }

        public int? SupplierId { get; set; }

        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }

        public string BuyerId { get; set; }

        [ForeignKey("BuyerId")]
        public virtual ApplicationUser Buyer { get; set; }

        public decimal TotalAmount { get; set; }

        public virtual ICollection<PurchaseInOrder> PurchaseInOrders { get; set; }

    }
}