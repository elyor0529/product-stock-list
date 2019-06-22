using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PSL.UI.Core.Data.Infrastructure.EF
{
    public class AuditEntity : FactoryEntity
    {
          
        [ScaffoldColumn(false)]
        public bool Deleted { get; set; }

    }
}