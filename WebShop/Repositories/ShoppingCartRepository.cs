using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Context;
using WebShop.Models;

namespace WebShop.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly IWebShopContext webShopContext;

        public ShoppingCartRepository(IWebShopContext webShopContext)
        {
            this.webShopContext = webShopContext;
        }

        public List<Product> GetShoppingCartProductsById(int id)
        {
            List<Product> products = new List<Product>();

            SqlConnection conn = webShopContext.GetConnection();
            try
            {
                conn.Open();

                string sql = "SELECT Product.id, Product.name, Product.description, Product.price, Product.image_path, Product.category, ShoppingCart.amount FROM Product INNER JOIN ShoppingCart ON Product.id=ShoppingCart.product_id WHERE ShoppingCart.profile_id = @id;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
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
    }
}
