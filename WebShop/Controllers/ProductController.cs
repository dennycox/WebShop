using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebShop.Data;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            ProductRepository productRepository = new ProductRepository();
            List<Product> products = productRepository.GetAllProducts();
            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            ProductRepository productRepository = new ProductRepository();
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
        public ActionResult Create(Product product)
        {
            try
            {
                ProductRepository productRepository = new ProductRepository();
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
            ProductRepository productRepository = new ProductRepository();
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
                ProductRepository productRepository = new ProductRepository();
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
            ProductRepository productRepository = new ProductRepository();
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
                ProductRepository productRepository = new ProductRepository();
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