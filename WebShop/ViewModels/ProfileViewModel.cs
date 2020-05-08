using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.ViewModels
{
    public class ProfileViewModel
    {
        public int ID { get; set; }

        [DisplayName("E-mailadres")]
        [Required(ErrorMessage = "Een e-mailadres invullen is verplicht")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Voornaam")]
        [Required(ErrorMessage = "Een voornaam invullen is verplicht")]
        public string FirstName { get; set; }

        [DisplayName("Tussenvoegsel")]
        public string Insertion { get; set; }

        [DisplayName("Achternaam")]
        [Required(ErrorMessage = "Een achternaam invullen is verplicht")]
        public string LastName { get; set; }

        [DisplayName("Postcode")]
        [Required(ErrorMessage = "Een postcode invullen is verplicht")]
        public string ZipCode { get; set; }

        [DisplayName("Huisnummer")]
        [Required(ErrorMessage = "Een huisnummer invullen is verplicht")]
        public int HouseNumber { get; set; }

        [DisplayName("Huisnummer toevoeging")]
        public string HouseNumberAddition { get; set; }

        [DisplayName("Wachtwoord")]
        [Required(ErrorMessage = "Een wachtwoord invullen is verplicht")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Bevestig wachtwoord")]
        [Compare("Password", ErrorMessage = "Wachtwoorden komen niet overeen")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [DisplayName("Profiel type")]
        [Required]
        public ProfileType ProfileType { get; set; }
    }
}
