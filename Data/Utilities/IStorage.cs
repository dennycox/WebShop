using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Utilities
{
    public interface IStorage
    {
        public string StoreFile(IFormFile file);
        public void RemoveFile(string path);
    }
}
