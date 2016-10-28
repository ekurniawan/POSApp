using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BO;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;

namespace DAL
{
    public class BarangDAL
    {
        public string GetConnString()
        {
            return ConfigurationManager
                .ConnectionStrings["POSDbConnectionString"].ConnectionString;
        }

        public IEnumerable<Barang> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                string strSql = @"select * from Barang order by Nama asc";
                var results = conn.Query<Barang>(strSql, conn);
                return results;
            }
        }

        public Barang GetById(string kodeBarang)
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                string strSql = @"select * from Barang 
                                  where KodeBarang=@KodeBarang";

                var param = new { KodeBarang = kodeBarang };

                var result = conn.Query<Barang>(strSql, param).FirstOrDefault();
                return result;
            }
        }

        public void Create(Barang barang)
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                string strSql = @"insert into Barang(KodeBarang,Nama,HargaBeli,HargaJual,Stok) 
                                  values(@KodeBarang,@Nama,@HargaBeli,@HargaJual,@Stok)";

                var param = new
                {
                    KodeBarang = barang.KodeBarang,
                    Nama = barang.Nama,
                    HargaBeli = barang.HargaBeli,
                    HargaJual = barang.HargaJual,
                    Stok = barang.Stok
                };

                try
                {
                    conn.Execute(strSql, param);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Number + " "+sqlEx.Message);
                }
            }
        }

        public void Update(Barang barang)
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                string strSql = @"update Barang set Nama=@Nama,
                                  HargaBeli=@HargaBeli,HargaJual=@HargaJual,
                                  Stok=@Stok where KodeBarang=@KodeBarang";

                var param = new
                {
                    KodeBarang = barang.KodeBarang,
                    Nama = barang.Nama,
                    HargaBeli = barang.HargaBeli,
                    HargaJual = barang.HargaJual,
                    Stok = barang.Stok
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

        public void Delete(string kodeBarang)
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                string strSql = @"delete from Barang 
                                  where KodeBarang=@KodeBarang";

                var param = new
                {
                    KodeBarang = kodeBarang
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
