using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Utilities
{
    public class Storage : IStorage
    {
        private IWebHostEnvironment _environment;

        public Storage(IWebHostEnvironment environment)
        {
            this._environment = environment;
        }

        public string StoreFile(IFormFile file)
        {
            if (file.Length > 0)
            {
                using (var stream = File.Create(GetStoragePath(file.FileName)))
                {
                    file.CopyTo(stream);
                }
            }

            return file.FileName;
        }

        public void RemoveFile(string fileName)
        {
            File.Delete(GetStoragePath(fileName));
        }

        private string GetStoragePath(string fileName)
        {
            return Path.Combine(_environment.WebRootPath, "storage", fileName);
        }
    }
}
