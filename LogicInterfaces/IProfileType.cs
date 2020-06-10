using System;
using System.Collections.Generic;
using System.Text;

namespace LogicInterfaces
{
    public interface IProfileType
    {
        int ProfileTypeID { get; set; }

        string ProfileTypeName { get; set; }
    }
}
