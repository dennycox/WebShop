using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataInterfaces;
using Data.Models;
using DataInterfaces.Data;
using DataInterfaces.Repositories;
using DataInterfaces.Models;

namespace Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IWebShopContext webShopContext;

        public ProductRepository(IWebShopContext webShopContext)
        {
            this.webShopContext = webShopContext;
        }

        public List<IProductDto> GetAllProducts()
        {
            List<IProductDto> products = new List<IProductDto>();

            SqlConnection conn = webShopContext.GetConnection();
            try
            {
                conn.Open();

                string sql = "SELECT id, name, description, price, image_path FROM product;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    products.Add(
                        new ProductDto()
                        {
                            ProductID = rdr.GetInt32(0),
                            Name = rdr.GetString(1),
                            Description = rdr.GetString(2),
                            Price = rdr.GetDecimal(3),
                            ImagePath = !rdr.IsDBNull(4) ? rdr.GetString(4) : null,
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

        public IProductDto GetProductById(int id)
        {
            SqlConnection conn = webShopContext.GetConnection();

            IProductDto product = null;
            try
            {
                conn.Open();

                string sql = "SELECT id, name, description, price, image_path FROM product WHERE id = @id;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    product = new ProductDto()
                    {
                        ProductID = rdr.GetInt32(0),
                        Name = rdr.GetString(1),
                        Description = rdr.GetString(2),
                        Price = rdr.GetDecimal(3),
                        ImagePath = !rdr.IsDBNull(4) ? rdr.GetString(4) : null,
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

        public void AddProduct(IProductDto productDto)
        {
            SqlConnection conn = webShopContext.GetConnection();
            try
            {
                conn.Open();

                string sql = "INSERT INTO product (name, description, price, image_path)" +
                    "VALUES(@name, @description, @price, @imagePath);";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", productDto.Name);
                cmd.Parameters.AddWithValue("@description", productDto.Description);
                cmd.Parameters.AddWithValue("@price", productDto.Price);
                cmd.Parameters.AddWithValue("@imagePath", productDto.ImagePath ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }

            conn.Close();
        }

        public void UpdateProduct(IProductDto productDto)
        {
            SqlConnection conn = webShopContext.GetConnection();
            try
            {
                conn.Open();

                string sql = "UPDATE product SET name = @name, description = @description, " +
                    "price = @price, image_path = @imagePath WHERE id = @productID;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", productDto.Name);
                cmd.Parameters.AddWithValue("@description", productDto.Description);
                cmd.Parameters.AddWithValue("@price", productDto.Price);
                cmd.Parameters.AddWithValue("@imagePath", productDto.ImagePath ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@productID", productDto.ProductID);

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

        public List<IProductDto> SearchProduct(string searchName)
        {
            SqlConnection conn = webShopContext.GetConnection();
            List<IProductDto> productViewModels = new List<IProductDto>();

            try
            {
                conn.Open();

                string sql = "SELECT id, name, description, price, image_path FROM product WHERE name LIKE '%' + @name + '%' OR description LIKE '%' + @description + '%';";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", searchName);
                cmd.Parameters.AddWithValue("@description", searchName);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    productViewModels.Add(
                        new ProductDto()
                        {
                            ProductID = rdr.GetInt32(0),
                            Name = rdr.GetString(1),
                            Description = rdr.GetString(2),
                            Price = rdr.GetDecimal(3),
                            ImagePath = !rdr.IsDBNull(4) ? rdr.GetString(4) : null,
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
