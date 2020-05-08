using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebShop.Repositories;
using WebShop.Utilities;
using WebShop.ViewModels;

namespace WebShop.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductRepository _productRepository;
        private readonly IStorage _storage;

        public ProductController(IProductRepository productRepository, IStorage storage)
        {
            this._productRepository = productRepository;
            this._storage = storage;
        }

        // GET: Product
        public ActionResult Index(string categoryName = null)
        {
            List<ProductViewModel> productViewModels = null;

            if (!String.IsNullOrEmpty(categoryName))
            {
                productViewModels = _productRepository.GetProductsByCategory(categoryName);
            }
            else
            {
                productViewModels = _productRepository.GetAllProducts();
            }

            return View(productViewModels);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            ProductViewModel productViewModel = _productRepository.GetProductById(id);
            return View(productViewModel);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ProductViewModel productViewModel = new ProductViewModel();
            return View(productViewModel);
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel productViewModel, IFormFile image)
        {
            try
            {
                if (image != null)
                {
                    productViewModel.ImagePath = _storage.StoreFile(image);
                }
                _productRepository.AddProduct(productViewModel);

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
            ProductViewModel productViewModel = _productRepository.GetProductById(id);

            return View(productViewModel);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductViewModel productViewModel, IFormFile image)
        {
            try
            {
                var oldProduct = _productRepository.GetProductById(id);

                if (image != null)
                {
                    if (productViewModel.ImagePath != null)
                    {
                        _storage.RemoveFile(oldProduct.ImagePath);
                    }
                    productViewModel.ImagePath = _storage.StoreFile(image);
                } else
                {
                    productViewModel.ImagePath = oldProduct.ImagePath;
                }
                productViewModel.ProductID = id;
                _productRepository.UpdateProduct(productViewModel);

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
            ProductViewModel productViewModel = _productRepository.GetProductById(id);
            return View(productViewModel);
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
            List<ProductViewModel> productViewModels = new List<ProductViewModel>();

            if (!String.IsNullOrEmpty(productName))
            {
                productViewModels = _productRepository.SearchProduct(productName);
            }
            else
            {
                return View();
            }

            return View(productViewModels);
        }
    }
}