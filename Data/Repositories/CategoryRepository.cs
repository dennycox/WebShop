using Data.Models;
using DataInterfaces.Data;
using DataInterfaces.Models;
using DataInterfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IWebShopContext webShopContext;

        public CategoryRepository(IWebShopContext webShopContext)
        {
            this.webShopContext = webShopContext;
        }

        public List<ICategoryDto> GetAllCategories()
        {
            List<ICategoryDto> categories = new List<ICategoryDto>();

            SqlConnection conn = webShopContext.GetConnection();
            try
            {
                conn.Open();

                string sql = "SELECT category_id, category_name FROM category;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    categories.Add(
                        new CategoryDto()
                        {
                            CategoryId = rdr.GetInt32(0),
                            CategoryName = rdr.GetString(1),
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

            return categories;
        }

        public ICategoryDto GetCategoryById(int id)
        {
            SqlConnection conn = webShopContext.GetConnection();

            ICategoryDto category = null;
            try
            {
                conn.Open();

                string sql = "SELECT category_id, category_name FROM category WHERE category_id = @id;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    category = new CategoryDto()
                    {
                        CategoryId = rdr.GetInt32(0),
                        CategoryName = rdr.GetString(1),
                    };
                }
                rdr.Close();
            }
            catch (Exception e)
            {
                throw e;
            }

            conn.Close();

            return category;
        }
    }
}
