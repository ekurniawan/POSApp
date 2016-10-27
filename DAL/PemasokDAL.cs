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

        public IEnumerable<Pemasok> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                List<Pemasok> listPemasok = new List<Pemasok>();
                string strSql = @"select * from Pemasok 
                                  order by Nama";

                SqlCommand cmd = new SqlCommand(strSql, conn);
                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if(dr.HasRows)
                    {
                        while(dr.Read())
                        {
                            listPemasok.Add(new Pemasok
                            {
                                KodePemasok = Convert.ToInt32(dr["KodePemasok"]),
                                Nama = dr["Nama"].ToString(),
                                Alamat = dr["Alamat"].ToString(),
                                Telp = dr["Telp"].ToString()
                            });
                        }
                    }
                    dr.Close();
                    return listPemasok;
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Message);
                }
                finally
                {
                    
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }
    }
}
