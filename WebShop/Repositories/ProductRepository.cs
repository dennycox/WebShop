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

                string sql = "SELECT id, name, description, price, image_path, category FROM product WHERE id = " + id + ";";
                SqlCommand cmd = new SqlCommand(sql, conn);
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
                    "VALUES('" + product.Name + "', '" + product.Description + "', '" + product.Price + 
                    "', '" + product.ImagePath + "', '" + product.Category + "');";
                SqlCommand cmd = new SqlCommand(sql, conn);
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

                string sql = "UPDATE product SET name = '" + product.Name + "', description = '" + product.Description + 
                    "', price = '" + product.Price + "', image_path = '" + product.ImagePath + "', " + 
                    "category = '" + product.Category + "' WHERE id = "+ product.ProductID + ";";
                SqlCommand cmd = new SqlCommand(sql, conn);
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

                string sql = "DELETE FROM product WHERE id = " + id + ";";
                SqlCommand cmd = new SqlCommand(sql, conn);
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
