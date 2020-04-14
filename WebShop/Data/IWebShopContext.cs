using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Context
{
    public interface IWebShopContext
    {
        MySqlConnection GetConnection();
    }
}
