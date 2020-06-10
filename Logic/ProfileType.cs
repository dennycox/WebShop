using LogicInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Logic
{
    public class ProfileType : IProfileType
    {
        public int ProfileTypeID { get; set; }

        public string ProfileTypeName { get; set; }
    }
}
