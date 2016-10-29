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
    public class DetailPembelianDAL
    {
        public string GetConnString()
        {
            return ConfigurationManager
                .ConnectionStrings["POSDbConnectionString"].ConnectionString;
        }

        public IEnumerable<DetailPembelian> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                string strSql = @"select * from DetailPembelian left join NotaPembelian 
                                  on DetailPembelian.KodeNotaBeli=NotaPembelian.KodeNotaBeli left join Barang 
                                  on DetailPembelian.KodeBarang = Barang.KodeBarang";

                var results = conn.Query<DetailPembelian, NotaPembelian, Barang, DetailPembelian>(strSql, (d, n, b) =>
                 {
                     d.NotaPembelian = n;
                     d.Barang = b;
                     return d;
                 }, splitOn: "KodeNotaBeli,KodeBarang");

                return results;
            }
        }

        public DetailPembelian GetByNota(int kodeNotaBeli)
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                string strSql = @"select * from DetailPembelian left join NotaPembelian 
                                  on DetailPembelian.KodeNotaBeli=NotaPembelian.KodeNotaBeli left join Barang 
                                  on DetailPembelian.KodeBarang = Barang.KodeBarang 
                                  where DetailPembelian.KodeNotaBeli=@KodeNotaBeli";

                var param = new { KodeNotaBeli = kodeNotaBeli };

                var results = conn.Query<DetailPembelian, NotaPembelian, Barang, DetailPembelian>(strSql, (d, n, b) =>
                {
                    d.NotaPembelian = n;
                    d.Barang = b;
                    return d;
                }, param, splitOn: "KodeNotaBeli,KodeBarang");

                return results.FirstOrDefault();
            }
        }

        public void Create(DetailPembelian detailPembelian)
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                string strSql = @"insert into DetailPembelian(KodeNotaBeli,KodeBarang,Harga,Kuantitas,Subtotal) 
                                  values(@KodeNotaBeli,@KodeBarang,@Harga,@Kuantitas,@Subtotal)";

                var param = new
                {
                    KodeNotaBeli = detailPembelian.KodeNotaBeli,
                    KodeBarang = detailPembelian.KodeBarang,
                    Harga = detailPembelian.Harga,
                    Kuantitas = detailPembelian.Kuantitas,
                    Subtotal = detailPembelian.Subtotal
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

        public void Update(DetailPembelian detailPembelian)
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                string strSql = @"update DetailPembelian KodeNotaBeli=@KodeNotaBeli,
                                  KodeBarang=@KodeBarang,Harga=@Harga,
                                  Kuantitas=@Kuantitas,Subtotal=@Subtotal) 
                                  where ";

                var param = new
                {
                    KodeNotaBeli = detailPembelian.KodeNotaBeli,
                    KodeBarang = detailPembelian.KodeBarang,
                    Harga = detailPembelian.Harga,
                    Kuantitas = detailPembelian.Kuantitas,
                    Subtotal = detailPembelian.Subtotal
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
