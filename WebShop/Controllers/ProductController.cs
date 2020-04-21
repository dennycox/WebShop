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
using WebShop.Utilities;

namespace WebShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IStorage _storage;

        public ProductController(IProductRepository productRepository, IStorage storage)
        {
            this._productRepository = productRepository;
            this._storage = storage;
        }

        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = _productRepository.GetAllProducts();
            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            Product product = _productRepository.GetProductById(id);
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
        public ActionResult Create(Product product)
        {
            try
            {
                product.ImagePath = _storage.StoreFile(product.Image);

                _productRepository.AddProduct(product);

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
            Product product = _productRepository.GetProductById(id);

            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                var oldProduct = _productRepository.GetProductById(id);
                _storage.RemoveFile(oldProduct.ImagePath);
                
                product.ImagePath = _storage.StoreFile(product.Image);

                product.ProductID = id;
                _productRepository.UpdateProduct(product);

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
            Product product = _productRepository.GetProductById(id);
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProductById(int id)
        {
            try
            {
                var oldProduct = _productRepository.GetProductById(id);
                _storage.RemoveFile(oldProduct.ImagePath);

                _productRepository.DeleteProduct(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Search(string productName)
        {
            List<Product> products = new List<Product>();

            if (!String.IsNullOrEmpty(productName))
            {
                products = _productRepository.SearchProduct(productName);
            }
            else
            {
                return View();
            }

            return View(products);
        }
    }
}