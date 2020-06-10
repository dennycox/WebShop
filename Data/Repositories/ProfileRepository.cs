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
    public class ProfileRepository : IProfileRepository
    {
        private readonly IWebShopContext webShopContext;

        public ProfileRepository(IWebShopContext webShopContext)
        {
            this.webShopContext = webShopContext;
        }

        public IProfileDto GetProfileById(int id)
        {
            SqlConnection conn = webShopContext.GetConnection();

            IProfileDto profile = null;
            try
            {
                conn.Open();

                string sql = "SELECT profile_id, email, first_name, insertion, last_name, zipcode, house_number, " +
                    "house_number_addition, password, profile_type_id FROM profile WHERE profile_id = @id;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    profile = new ProfileDto()
                    {
                        ID = rdr.GetInt32(0),
                        Email = rdr.GetString(1),
                        FirstName = rdr.GetString(2),
                        Insertion = rdr.GetString(3),
                        LastName = rdr.GetString(4),
                        ZipCode = rdr.GetString(5),
                        HouseNumber = rdr.GetInt32(6),
                        HouseNumberAddition = rdr.GetString(7),
                        Password = rdr.GetString(8),
                        ProfileTypeID = rdr.GetInt32(9),
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
    }
}
