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
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }

        public int Create(Pemasok pemasok)
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                string strSql = @"insert into Pemasok(Nama,Alamat,Telp) 
                                  values(@Nama,@Alamat,@Telp);select @@identity";

                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("Nama", pemasok.Nama);
                cmd.Parameters.AddWithValue("Alamat", pemasok.Alamat);
                cmd.Parameters.AddWithValue("Telp", pemasok.Telp);

                try
                {
                    conn.Open();
                    var result = Convert.ToInt32(cmd.ExecuteScalar());
                    return result;
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Number + " " + sqlEx.Message);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }

        public void Update(Pemasok pemasok)
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                string strSql = @"update Pemasok set Nama=@Nama,Alamat=@Alamat,
                                  Telp=@Telp where KodePemasok=@KodePemasok";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("Nama", pemasok.Nama);
                cmd.Parameters.AddWithValue("Alamat", pemasok.Alamat);
                cmd.Parameters.AddWithValue("Telp", pemasok.Telp);
                cmd.Parameters.AddWithValue("KodePemasok", pemasok.KodePemasok);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Number + " " + sqlEx.Message);
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
