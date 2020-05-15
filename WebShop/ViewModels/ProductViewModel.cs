using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.ViewModels
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }

        [DisplayName("Naam")]
        [Required(ErrorMessage = "Een naam invullen is verplicht")]
        public string Name { get; set; }

        [DisplayName("Beschrijving")]
        [Required(ErrorMessage = "Een beschrijving invullen is verplicht")]
        public string Description { get; set; }

        [DisplayName("Prijs")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Een prijs invullen is verplicht")]
        public decimal Price { get; set; }

        [DisplayName("Afbeelding")]
        public string ImagePath { get; set; }
    }
}
