using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebShop.Models;
using WebShop.Repositories;

namespace WebShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;

        private IWebHostEnvironment _environment;

        public ProductController(IProductRepository productRepository, IWebHostEnvironment environment)
        {
            this.productRepository = productRepository;
            this._environment = environment;
        }

        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = productRepository.GetAllProducts();
            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            Product product = productRepository.GetProductById(id);
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            Product product = new Product();
            return View(product);
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            try
            {
                if (product.Image.Length > 0)
                {
                    var filePath = Path.Combine(_environment.WebRootPath, "storage", product.Image.FileName);
                    product.ImagePath = product.Image.FileName;

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await product.Image.CopyToAsync(stream);
                    }
                }

                productRepository.AddProduct(product);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            Product product = productRepository.GetProductById(id);

            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                product.ProductID = id;
                productRepository.UpdateProduct(product);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            Product product = productRepository.GetProductById(id);
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProductById(int id)
        {
            try
            {
                productRepository.DeleteProduct(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}