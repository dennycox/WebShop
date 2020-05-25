using LogicInterfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.ViewModels.Product
{
    public class ProductCreateViewModel
    {
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

        public IFormFile Image { get; set; }

        [DisplayName("Categorie")]
        [Required(ErrorMessage = "Een categorie selecteren is verplicht")]
        public int CategoryID { get; set; }

        public List<ICategory> Categories { get; set; }
    }
}
