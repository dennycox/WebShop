using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataInterfaces.Data;
using Microsoft.Extensions.Configuration;

namespace Data.Data
{
    public class WebShopContext : IWebShopContext
    {
        private readonly IConfiguration configuration;

        public WebShopContext(IConfiguration config)
        {
            this.configuration = config;
        }

        public SqlConnection GetConnection()
        {
            string connStr = configuration.GetConnectionString("DefaultConnection");
            return new SqlConnection(connStr);
        }
    }
}
