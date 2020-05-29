using System;
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
    public class ProductController : BaseController
    {
        private readonly IProductCollection _productCollection;
        private readonly ICategoryCollection _categoryCollection;
        private readonly IStorage _storage;

        public ProductController(IProductCollection productCollection, ICategoryCollection categoryCollection, IStorage storage) : base(categoryCollection)
        {
            this._productCollection = productCollection;
            this._categoryCollection = categoryCollection;
            this._storage = storage;
        }

        // GET: Product
        public ActionResult Index(int categoryId = 0)
        {
            List<IProduct> products = null;

            if (categoryId > 0)
            {
                products = _productCollection.GetProductsByCategoryID(categoryId);
            }
            else
            {
                products = _productCollection.GetAllProducts();
            }

            products.ForEach(p => p.Category = _categoryCollection.GetCategoryById(p.CategoryId));
            ProductIndexViewModel productIndexViewModel = new ProductIndexViewModel
            {
                Products = products,
            };

            return View(productIndexViewModel);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            IProduct product = _productCollection.GetProductById(id);
            product.Category = _categoryCollection.GetCategoryById(product.CategoryId);
            ProductDetailsViewModel productViewModel = new ProductDetailsViewModel()
            {
                Product = product,
            };

            return View(productViewModel);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ProductCreateViewModel productViewModel = new ProductCreateViewModel()
            {
                Categories = _categoryCollection.GetAllCategories(),
            };
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
                    CategoryId = productViewModel.CategoryID,
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
                CategoryID = product.CategoryId,
                Categories = _categoryCollection.GetAllCategories(),
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
                    CategoryId = productViewModel.CategoryID,
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
            product.Category = _categoryCollection.GetCategoryById(product.CategoryId);
            ProductDeleteViewModel productDeleteViewModel = new ProductDeleteViewModel()
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImagePath = product.ImagePath,
                CategoryName = product.Category.CategoryName,
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
            products.ForEach(p => p.Category = _categoryCollection.GetCategoryById(p.CategoryId));
            ProductSearchViewModel productSearchViewModel = new ProductSearchViewModel
            {
                Products = products
            };

            return View(productSearchViewModel);
        }
    }
}