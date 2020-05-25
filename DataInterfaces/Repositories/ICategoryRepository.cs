using DataInterfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataInterfaces.Repositories
{
    public interface ICategoryRepository
    {
        List<ICategoryDto> GetAllCategories();
    }
}
