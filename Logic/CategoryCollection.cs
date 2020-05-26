using DataInterfaces.Models;
using DataInterfaces.Repositories;
using LogicInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class CategoryCollection : ICategoryCollection
    {
        private ICategoryRepository _categoryRepository;

        public CategoryCollection(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<ICategory> GetAllCategories()
        {
            return _categoryRepository.GetAllCategories().Select(c => CategoryDtoToCategory(c)).ToList();
        }

        public ICategory GetCategoryById(int id)
        {
            return CategoryDtoToCategory(_categoryRepository.GetCategoryById(id));
        }

        private ICategory CategoryDtoToCategory(ICategoryDto categoryDto)
        {
            return new Category()
            {
                CategoryId = categoryDto.CategoryId,
                CategoryName = categoryDto.CategoryName,
            };
        }
    }
}
