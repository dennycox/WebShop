﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using LogicInterfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using WebShop.Utilities;
using WebShop.ViewModels;
using WebShop.ViewModels.Product;

namespace WebShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductCollection _productCollection;
        private readonly ICategoryCollection _categoryCollection;
        private readonly IStorage _storage;

        public ProductController(IProductCollection productCollection, ICategoryCollection categoryCollection, IStorage storage)
        {
            this._productCollection = productCollection;
            this._categoryCollection = categoryCollection;
            this._storage = storage;
        }

        // GET: Product
        public ActionResult Index()
        {
            List<IProduct> products = _productCollection.GetAllProducts();
            List<ICategory> categories = _categoryCollection.GetAllCategories();
            ProductIndexViewModel productIndexViewModel = new ProductIndexViewModel
            {
                Products = products,
                Categories = categories
            };

            return View(productIndexViewModel);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            IProduct product = _productCollection.GetProductById(id);
            List<ICategory> categories = _categoryCollection.GetAllCategories();
            ProductDetailsViewModel productViewModel = new ProductDetailsViewModel()
            {
                Product = product,
                Categories = categories
            };

            return View(productViewModel);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ProductCreateViewModel productViewModel = new ProductCreateViewModel();
            return View(productViewModel);
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCreateViewModel productViewModel)
        {
            try
            {
                IProduct product = new Product
                {
                    Name = productViewModel.Name,
                    Description = productViewModel.Description,
                    Price = productViewModel.Price,
                };

                if (productViewModel.Image != null)
                {
                    product.ImagePath = _storage.StoreFile(productViewModel.Image);
                }
                _productCollection.AddProduct(product);

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
            IProduct product = _productCollection.GetProductById(id);
            ProductEditViewModel productEditViewModel = new ProductEditViewModel()
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
            };

            return View(productEditViewModel);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductEditViewModel productViewModel)
        {
            try
            {
                IProduct product = new Product
                {
                    ProductID = id,
                    Name = productViewModel.Name,
                    Description = productViewModel.Description,
                    Price = productViewModel.Price,
                };

                var oldProduct = _productCollection.GetProductById(id);

                if (productViewModel.Image != null)
                {
                    if (oldProduct.ImagePath != null)
                    {
                        _storage.RemoveFile(oldProduct.ImagePath);
                    }
                    product.ImagePath = _storage.StoreFile(productViewModel.Image);
                } else
                {
                    product.ImagePath = oldProduct.ImagePath;
                }
                _productCollection.UpdateProduct(product);

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
            IProduct product = _productCollection.GetProductById(id);
            ProductDeleteViewModel productDeleteViewModel = new ProductDeleteViewModel()
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImagePath = product.ImagePath,
            };

            return View(productDeleteViewModel);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProductById(int id)
        {
            try
            {
                var oldProduct = _productCollection.GetProductById(id);
                if (oldProduct.ImagePath != null)
                {
                    _storage.RemoveFile(oldProduct.ImagePath);
                }

                _productCollection.DeleteProduct(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Search(string productName)
        {
            if (string.IsNullOrWhiteSpace(productName))
            {
                View();
            }

            List<IProduct> products = _productCollection.SearchProduct(productName);
            ProductSearchViewModel productSearchViewModel = new ProductSearchViewModel
            {
                Products = products
            };

            return View(productSearchViewModel);
        }
    }
}