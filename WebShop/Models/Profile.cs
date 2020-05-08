using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class Profile
    {
        [Key]
        public int ID { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string Insertion { get; set; }

        public string LastName { get; set; }

        public string ZipCode { get; set; }

        public int HouseNumber { get; set; }

        public string HouseNumberAddition { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public ProfileType ProfileType { get; set; }
    }
}
