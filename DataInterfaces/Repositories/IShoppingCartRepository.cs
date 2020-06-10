using DataInterfaces;
using DataInterfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataInterfaces.Repositories
{
    public interface IShoppingCartRepository
    {
        IShoppingCartDto GetShoppingCartById(int id);
    }
}
