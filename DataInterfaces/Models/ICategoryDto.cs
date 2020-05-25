using System;
using System.Collections.Generic;
using System.Text;

namespace DataInterfaces.Models
{
    public interface ICategoryDto
    {
        int CategoryId { get; set; }

        string CategoryName { get; set; }
    }
}
