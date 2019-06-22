using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using PSL.UI.Core.Data.Infrastructure.EF;

namespace PSL.UI.Core.Data.Entities
{
    public class Order : AuditEntity
    {

        [Required]
        [StringLength(250)]
        public string Title { get; set; }

        public DateTime Date { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        public string ClientId { get; set; }

        [ForeignKey("ClientId")]
        public virtual ApplicationUser Client { get; set; }

    }
}