using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class ShoppingCart
    {
        [Key]
        public int ProductID { get; set; }

        [Key]
        public int ProfileID { get; set; }

        [Required]
        public int Amount { get; set; }
    }
}
