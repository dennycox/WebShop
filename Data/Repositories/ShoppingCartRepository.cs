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
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly IWebShopContext webShopContext;

        public ShoppingCartRepository(IWebShopContext webShopContext)
        {
            this.webShopContext = webShopContext;
        }

        public IShoppingCartDto GetShoppingCartById(int id)
        {
            SqlConnection conn = webShopContext.GetConnection();

            IShoppingCartDto shoppingCart = null;
            try
            {
                conn.Open();

                string sql = "SELECT profile_id, product_id, amount FROM shoppingcart WHERE profile_id = @id;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    shoppingCart = new ShoppingCartDto()
                    {
                        ProfileID = rdr.GetInt32(0),
                        ProductID = rdr.GetInt32(1),
                        Amount = rdr.GetInt32(2),
                    };
                }
                rdr.Close();
            }
            catch (Exception e)
            {
                throw e;
            }

            conn.Close();

            return shoppingCart;
        }
    }
}
