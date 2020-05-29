using System;
using System.Collections.Generic;
using System.Text;

namespace DataInterfaces.Models
{
    public interface IProfileDto
    {
        int ID { get; set; }

        string Email { get; set; }

        string FirstName { get; set; }

        string Insertion { get; set; }

        string LastName { get; set; }

        string ZipCode { get; set; }

        int HouseNumber { get; set; }

        string HouseNumberAddition { get; set; }

        string Password { get; set; }

        string ConfirmPassword { get; set; }

        int ProfileTypeID { get; set; }
    }
}
