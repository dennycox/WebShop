using System;
using System.Collections.Generic;
using System.Text;

namespace DataInterfaces.Models
{
    public interface IProfileTypeDto
    {
        int ProfileTypeID { get; set; }

        string ProfileTypeName { get; set; }
    }
}
