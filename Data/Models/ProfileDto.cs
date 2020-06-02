using DataInterfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class ProfileDto : IProfileDto
    {
        public int ID { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string Insertion { get; set; }

        public string LastName { get; set; }

        public string ZipCode { get; set; }

        public int HouseNumber { get; set; }

        public string HouseNumberAddition { get; set; }

        public string Password { get; set; }

        public int ProfileTypeID { get; set; }
    }
}
