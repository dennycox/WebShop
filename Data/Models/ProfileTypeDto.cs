using DataInterfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class ProfileTypeDto : IProfileTypeDto
    {
        public int ProfileTypeID { get; set; }

        public string ProfileTypeName { get; set; }
    }
}
