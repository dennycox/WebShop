using Data.Models;
using DataInterfaces.Models;
using System;

namespace DataFactory
{
    public static class Factory
    {
        public static IProductDto GetProductDto()
        {
            return new ProductDto();
        }
    }
}
