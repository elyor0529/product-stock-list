using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using PSL.UI.Core.Data.Infrastructure.EF;

namespace PSL.UI.Core.Data.Entities
{
    public class PurchaseInOrder : FactoryEntity
    {
          
        public int? PurchaseId { get; set; }

        [ForeignKey("PurchaseId")]
        public virtual Purchase Purchase { get; set; }

        public int? ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }

    }
}