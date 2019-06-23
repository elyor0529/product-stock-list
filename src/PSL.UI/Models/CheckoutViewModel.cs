using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PSL.UI.Models
{
    public class CheckoutViewModel
    {

        [Required]
        public int? SupplierId { get; set; }

        [Required]
        public List<OrderViewModel> Items { get; set; } = new List<OrderViewModel>();

    }

}