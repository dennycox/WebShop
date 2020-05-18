using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DataInterfaces.Data
{
    public interface IWebShopContext
    {
        SqlConnection GetConnection();
    }
}
