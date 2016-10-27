using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class NotaPembelian
    {
        public int KodeNotaBeli { get; set; }
        public int KodePemasok { get; set; }
        public DateTime Tanggal { get; set; }

        public virtual Pemasok Pemasok { get; set; }
    }
}
