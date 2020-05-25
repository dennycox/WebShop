using DataInterfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class CategoryDto : ICategoryDto
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
