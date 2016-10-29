using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BO;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class NotaPembelianDAL
    {
        public string GetConnString()
        {
            return ConfigurationManager
                .ConnectionStrings["POSDbConnectionString"].ConnectionString;
        }

        public int GetNoNotaPembelian(NotaPembelian notaBeli)
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                string strSql = @"insert into NotaPembelian(KodePemasok,Tanggal) 
                              values(@KodePemasok,@Tanggal);select @@identity;";

                var param = new
                {
                    KodePemasok = notaBeli.KodePemasok,
                    Tanggal = notaBeli.Tanggal
                };

                var result = Convert.ToInt32(conn.ExecuteScalar(strSql, param));

                return result;
            }
               
        }

        public void Update(NotaPembelian notaBeli)
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                string strSql = @"update NotaPembelian set KodePemasok=@KodePemasok,
                                  Tanggal=@Tanggal where KodeNotaBeli=@KodeNotaBeli";

                var param = new
                {
                    KodePemasok = notaBeli.KodePemasok,
                    Tanggal = notaBeli.Tanggal,
                    KodeNotaBeli = notaBeli.KodeNotaBeli
                };

                try
                {
                    conn.Execute(strSql, param);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Number + " " + sqlEx.Message);
                }
            }
        }
    }
}
