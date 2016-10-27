using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class PemasokDAL
    {
        public string GetConnString()
        {
            return ConfigurationManager
                .ConnectionStrings["POSDbConnectionString"].ConnectionString;
        }
    }
}
