using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Context
{
    public interface IWebShopContext
    {
        SqlConnection GetConnection();
    }
}
