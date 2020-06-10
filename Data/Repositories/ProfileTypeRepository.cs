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
    public class ProfileTypeRepository : IProfileTypeRepository
    {
        private readonly IWebShopContext webShopContext;

        public ProfileTypeRepository(IWebShopContext webShopContext)
        {
            this.webShopContext = webShopContext;
        }

        public List<IProfileTypeDto> GetAllProfileTypes()
        {
            List<IProfileTypeDto> profileTypes = new List<IProfileTypeDto>();

            SqlConnection conn = webShopContext.GetConnection();
            try
            {
                conn.Open();

                string sql = "SELECT profile_type_id, profile_type_name FROM profiletype;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    profileTypes.Add(
                        new ProfileTypeDto()
                        {
                            ProfileTypeID = rdr.GetInt32(0),
                            ProfileTypeName = rdr.GetString(1),
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

            return profileTypes;
        }

        public IProfileTypeDto GetProfileTypeById(int id)
        {
            SqlConnection conn = webShopContext.GetConnection();

            IProfileTypeDto profileType = null;
            try
            {
                conn.Open();

                string sql = "SELECT profile_type_id, profile_type_name FROM profiletype WHERE profile_type_id = @id;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    profileType = new ProfileTypeDto()
                    {
                        ProfileTypeID = rdr.GetInt32(0),
                        ProfileTypeName = rdr.GetString(1),
                    };
                }
                rdr.Close();
            }
            catch (Exception e)
            {
                throw e;
            }

            conn.Close();

            return profileType;
        }
    }
}
