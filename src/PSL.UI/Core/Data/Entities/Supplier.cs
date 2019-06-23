using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PSL.UI.Core.Data.Infrastructure.EF;

namespace PSL.UI.Core.Data.Entities
{
    public class Supplier : FactoryEntity
    {

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}