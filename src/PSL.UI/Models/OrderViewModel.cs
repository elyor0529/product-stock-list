using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PSL.UI.Models
{
    public class OrderViewModel
    {

        [Required]
        public int? OrderId { get; set; }

        [Required]
        public int? ProductId { get; set; }

        public int Quantity { get; set; }

    }
}