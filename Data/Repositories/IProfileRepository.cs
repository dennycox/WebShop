using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.ViewModels;

namespace WebShop.Repositories
{
    public interface IProfileRepository
    {
        public ProfileViewModel GetProfileById(int id);
    }
}
