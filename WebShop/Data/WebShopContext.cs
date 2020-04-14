﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WebShop.Context
{
    public class WebShopContext : IWebShopContext
    {
        private readonly IConfiguration configuration;

        public WebShopContext(IConfiguration config)
        {
            this.configuration = config;
        }

        public MySqlConnection GetConnection()
        {
            string connStr = configuration.GetConnectionString("DefaultConnection");
            return new MySqlConnection(connStr);
        }
    }
}