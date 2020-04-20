using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Models;
using WebShop.Context;

namespace WebShop.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IWebShopContext webShopContext;

        public ProductRepository(IWebShopContext webShopContext)
        {
            this.webShopContext = webShopContext;
        }

        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            SqlConnection conn = webShopContext.GetConnection();
            try
            {
                conn.Open();

                string sql = "SELECT id, name, description, price, image_path, category FROM product;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    products.Add(
                        new Product()
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

            return products;
        }

        public Product GetProductById(int id)
        {
            SqlConnection conn = webShopContext.GetConnection();

            Product product = null;
            try
            {
                conn.Open();

                string sql = "SELECT id, name, description, price, image_path, category FROM product WHERE id = @id;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    product = new Product()
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

            return product;
        }

        public void AddProduct(Product product)
        {
            SqlConnection conn = webShopContext.GetConnection();
            try
            {
                conn.Open();

                string sql = "INSERT INTO product (name, description, price, image_path, category)" +
                    "VALUES(@name, @description, @price, @imagePath, @category);";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@description", product.Description);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@imagePath", product.ImagePath ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@category", product.Category);

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }

            conn.Close();
        }

        public void UpdateProduct(Product product)
        {
            SqlConnection conn = webShopContext.GetConnection();
            try
            {
                conn.Open();

                string sql = "UPDATE product SET name = @name, description = @description, " +
                    "price = @price, image_path = @imagePath, category = @category WHERE id = @productID;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@description", product.Description);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@imagePath", product.ImagePath);
                cmd.Parameters.AddWithValue("@category", product.Category);
                cmd.Parameters.AddWithValue("@productID", product.ProductID);

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
    }
}
