using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Models;
using WebShop.Context;
using WebShop.ViewModels;

namespace WebShop.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IWebShopContext webShopContext;

        public ProductRepository(IWebShopContext webShopContext)
        {
            this.webShopContext = webShopContext;
        }

        public List<ProductViewModel> GetAllProducts()
        {
            List<ProductViewModel> productViewModels = new List<ProductViewModel>();

            SqlConnection conn = webShopContext.GetConnection();
            try
            {
                conn.Open();

                string sql = "SELECT id, name, description, price, image_path, category FROM product;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    productViewModels.Add(
                        new ProductViewModel()
                        {
                            ProductID = rdr.GetInt32(0),
                            Name = rdr.GetString(1),
                            Description = rdr.GetString(2),
                            Price = rdr.GetDecimal(3),
                            ImagePath = !rdr.IsDBNull(4) ? rdr.GetString(4) : null,
                            Category = (Category)Enum.Parse(typeof(Category), rdr.GetString(5)),
                        }
                    );
                }
                rdr.Close();
            }
            catch (Exception e)
            {
                throw e;
            }

            conn.Close();

            return productViewModels;
        }

        public ProductViewModel GetProductById(int id)
        {
            SqlConnection conn = webShopContext.GetConnection();

            ProductViewModel productViewModel = null;
            try
            {
                conn.Open();

                string sql = "SELECT id, name, description, price, image_path, category FROM product WHERE id = @id;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    productViewModel = new ProductViewModel()
                    {
                        ProductID = rdr.GetInt32(0),
                        Name = rdr.GetString(1),
                        Description = rdr.GetString(2),
                        Price = rdr.GetDecimal(3),
                        ImagePath = !rdr.IsDBNull(4) ? rdr.GetString(4) : null,
                        Category = (Category)Enum.Parse(typeof(Category), rdr.GetString(5)),
                    };
                }
                rdr.Close();
            }
            catch (Exception e)
            {
                throw e;
            }

            conn.Close();

            return productViewModel;
        }

        public void AddProduct(ProductViewModel productViewModel)
        {
            SqlConnection conn = webShopContext.GetConnection();
            try
            {
                conn.Open();

                string sql = "INSERT INTO product (name, description, price, image_path, category)" +
                    "VALUES(@name, @description, @price, @imagePath, @category);";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", productViewModel.Name);
                cmd.Parameters.AddWithValue("@description", productViewModel.Description);
                cmd.Parameters.AddWithValue("@price", productViewModel.Price);
                cmd.Parameters.AddWithValue("@imagePath", productViewModel.ImagePath ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@category", productViewModel.Category);

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }

            conn.Close();
        }

        public void UpdateProduct(ProductViewModel productViewModel)
        {
            SqlConnection conn = webShopContext.GetConnection();
            try
            {
                conn.Open();

                string sql = "UPDATE product SET name = @name, description = @description, " +
                    "price = @price, image_path = @imagePath, category = @category WHERE id = @productID;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", productViewModel.Name);
                cmd.Parameters.AddWithValue("@description", productViewModel.Description);
                cmd.Parameters.AddWithValue("@price", productViewModel.Price);
                cmd.Parameters.AddWithValue("@imagePath", productViewModel.ImagePath ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@category", productViewModel.Category);
                cmd.Parameters.AddWithValue("@productID", productViewModel.ProductID);

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }

            conn.Close();
        }

        public void DeleteProduct(int id)
        {
            SqlConnection conn = webShopContext.GetConnection();
            try
            {
                conn.Open();

                string sql = "DELETE FROM product WHERE id = @id;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }

            conn.Close();
        }

        public List<ProductViewModel> SearchProduct(string searchName)
        {
            SqlConnection conn = webShopContext.GetConnection();
            List<ProductViewModel> productViewModels = new List<ProductViewModel>();

            try
            {
                conn.Open();

                string sql = "SELECT id, name, description, price, image_path, category FROM product WHERE name LIKE '%' + @name + '%' OR description LIKE '%' + @description + '%';";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", searchName);
                cmd.Parameters.AddWithValue("@description", searchName);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    productViewModels.Add(
                        new ProductViewModel()
                        {
                            ProductID = rdr.GetInt32(0),
                            Name = rdr.GetString(1),
                            Description = rdr.GetString(2),
                            Price = rdr.GetDecimal(3),
                            ImagePath = !rdr.IsDBNull(4) ? rdr.GetString(4) : null,
                            Category = (Category)Enum.Parse(typeof(Category), rdr.GetString(5)),
                        }
                    );
                }
                rdr.Close();
            }
            catch (Exception e)
            {
                throw e;
            }

            conn.Close();

            return productViewModels;
        }

        public List<ProductViewModel> GetProductsByCategory(string categoryName)
        {
            SqlConnection conn = webShopContext.GetConnection();
            List<ProductViewModel> productViewModels = new List<ProductViewModel>();

            try
            {
                conn.Open();

                string sql = "SELECT id, name, description, price, image_path, category FROM product WHERE category = @category;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                int categoryId = (int)Enum.Parse(typeof(Category), categoryName);
                cmd.Parameters.AddWithValue("@category", categoryId);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    productViewModels.Add(
                        new ProductViewModel()
                        {
                            ProductID = rdr.GetInt32(0),
                            Name = rdr.GetString(1),
                            Description = rdr.GetString(2),
                            Price = rdr.GetDecimal(3),
                            ImagePath = !rdr.IsDBNull(4) ? rdr.GetString(4) : null,
                            Category = (Category)Enum.Parse(typeof(Category), rdr.GetString(5)),
                        }
                    );
                }
                rdr.Close();
            }
            catch (Exception e)
            {
                throw e;
            }

            conn.Close();

            return productViewModels;
        }
    }
}
