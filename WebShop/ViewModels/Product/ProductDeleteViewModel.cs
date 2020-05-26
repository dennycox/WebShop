using Logic;
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
    public class ProductDeleteViewModel
    {
        [DisplayName("Naam")]
        public string Name { get; set; }

        [DisplayName("Beschrijving")]
        public string Description { get; set; }

        [DisplayName("Prijs")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public string ImagePath { get; set; }

        [DisplayName("Categorie")]
        public string CategoryName { get; set; }
    }
}
