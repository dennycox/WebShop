﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        
        [DisplayName("Naam")]
        [Required(ErrorMessage = "Een naam invullen is verplicht")]
        public string Name { get; set; }
        
        [DisplayName("Beschrijving")]
        [Required(ErrorMessage = "Een beschrijving invullen is verplicht")]
        public string Description { get; set; }
        
        [DisplayName("Prijs")]
        [Required(ErrorMessage = "Een prijs invullen is verplicht")]
        public Decimal Price { get; set; }

        [DisplayName("Afbeelding")]
        public string ImagePath { get; set; }

        [DisplayName("Categorie")]
        [Required(ErrorMessage = "Een categorie kiezen is verplicht")]
        public Category Category { get; set; }
    }
}