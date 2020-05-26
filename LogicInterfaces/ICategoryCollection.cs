using System;
using System.Collections.Generic;
using System.Text;

namespace LogicInterfaces
{
    public interface ICategoryCollection
    {
        List<ICategory> GetAllCategories();

        ICategory GetCategoryById(int id);
    }
}
