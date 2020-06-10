using System;
using System.Collections.Generic;
using System.Text;

namespace LogicInterfaces
{
    public interface IProfileCollection
    {
        IProfile GetProfileById(int id);
    }
}
