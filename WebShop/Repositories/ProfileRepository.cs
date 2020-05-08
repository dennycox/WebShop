using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Context;
using WebShop.Models;
using WebShop.ViewModels;

namespace WebShop.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly IWebShopContext webShopContext;

        public ProfileRepository(IWebShopContext webShopContext)
        {
            this.webShopContext = webShopContext;
        }

        public ProfileViewModel GetProfileById(int id)
        {
            SqlConnection conn = webShopContext.GetConnection();

            ProfileViewModel profileViewModel = null;
            try
            {
                conn.Open();

                string sql = "SELECT id, email, first_name, insertion, last_name, zip_code, house_number, house_number_addition, password, profile_type FROM profile WHERE id = @id;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    profileViewModel = new ProfileViewModel()
                    {
                        ID = rdr.GetInt32(0),
                        Email = rdr.GetString(1),
                        FirstName = rdr.GetString(2),
                        Insertion = !rdr.IsDBNull(3) ? rdr.GetString(3) : null,
                        LastName = rdr.GetString(4),
                        ZipCode = rdr.GetString(5),
                        HouseNumber = rdr.GetInt32(6),
                        HouseNumberAddition = !rdr.IsDBNull(7) ? rdr.GetString(7) : null,
                        Password = rdr.GetString(8),
                        ConfirmPassword = rdr.GetString(8),
                        ProfileType = (ProfileType)Enum.Parse(typeof(ProfileType), rdr.GetString(9)),
                    };
                }
                rdr.Close();
            }
            catch (Exception e)
            {
                throw e;
            }

            conn.Close();

            return profileViewModel;
        }
    }
}
