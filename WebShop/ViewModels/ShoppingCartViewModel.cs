using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.ViewModels
{
    public class ShoppingCartViewModel
    {
        public int ProductID { get; set; }

        public int ProfileID { get; set; }

        [Required]
        public int Amount { get; set; }
    }
}
