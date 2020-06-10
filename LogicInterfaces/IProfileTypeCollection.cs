using System;
using System.Collections.Generic;
using System.Text;

namespace LogicInterfaces
{
    public interface IProfileTypeCollection
    {
        List<IProfileType> GetAllProfiletypes();

        IProfileType GetProfileTypeById(int id);
    }
}
