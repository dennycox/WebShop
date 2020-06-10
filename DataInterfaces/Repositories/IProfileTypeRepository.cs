using DataInterfaces;
using DataInterfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataInterfaces.Repositories
{
    public interface IProfileTypeRepository
    {
        List<IProfileTypeDto> GetAllProfileTypes();
        IProfileTypeDto GetProfileTypeById(int id);
    }
}
