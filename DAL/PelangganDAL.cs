using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BO;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Dapper.FastCrud;
using System.Configuration;

namespace DAL
{
    public class PelangganDAL
    {
        public PelangganDAL()
        {
            OrmConfiguration.DefaultDialect = SqlDialect.MsSql;
        }

        public string GetConnString()
        {
            return ConfigurationManager
                .ConnectionStrings["POSDbConnectionString"].ConnectionString;
        }

        public IEnumerable<Pelanggan> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                return conn.Find<Pelanggan>(p => p.OrderBy($"{nameof(Pelanggan.Nama):C} desc"));
            }
        }

        public void Insert(Pelanggan pelanggan)
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                try
                {
                    conn.Insert(pelanggan);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Number + " " + sqlEx.Message);
                }
            }
        }
    }
}
