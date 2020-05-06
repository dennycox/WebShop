using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Context;
using WebShop.Models;

namespace WebShop.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly IWebShopContext webShopContext;

        public ProfileRepository(IWebShopContext webShopContext)
        {
            this.webShopContext = webShopContext;
        }

        public Profile GetProfileById(int id)
        {
            SqlConnection conn = webShopContext.GetConnection();

            Profile profile = null;
            try
            {
                conn.Open();

                string sql = "SELECT id, email, first_name, insertion, last_name, zip_code, house_number, house_number_addition, password, profile_type FROM profile WHERE id = @id;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    profile = new Profile()
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

            return profile;
        }

        public void UpdateProfile(Profile profile)
        {
            SqlConnection conn = webShopContext.GetConnection();
            try
            {
                conn.Open();

                string sql = "UPDATE profile SET email = @email, first_name = @firstName, insertion = @insertion, last_name = @lastName, zip_code = @zipCode, house_number = @houseNumber, house_number_addition = @houseNumberAddition, password = @password, profile_type = @profileType WHERE id = @profileID;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@profileID", profile.ID);
                cmd.Parameters.AddWithValue("@email", profile.Email);
                cmd.Parameters.AddWithValue("@firstName", profile.FirstName);
                cmd.Parameters.AddWithValue("@insertion", profile.Insertion ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@lastName", profile.LastName);
                cmd.Parameters.AddWithValue("@zipCode", profile.ZipCode);
                cmd.Parameters.AddWithValue("@houseNumber", profile.HouseNumber);
                cmd.Parameters.AddWithValue("@houseNumberAddition", profile.HouseNumberAddition ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@password", profile.Password);
                cmd.Parameters.AddWithValue("@profileType", profile.ProfileType);

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
