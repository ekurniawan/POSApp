using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class DetailPembelian
    {
        public int Id { get; set; }
        public int KodeNotaBeli { get; set; }
        public string KodeBarang { get; set; }
        public decimal Harga { get; set; }
        public int Kuantitas { get; set; }

        public virtual NotaPembelian NotaPembelian { get; set; }
        public virtual Barang Barang { get; set; }
    }
}
