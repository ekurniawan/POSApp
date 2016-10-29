using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BO
{
    [Table("Pelanggan")]
    public class Pelanggan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KodePelanggan { get; set; }
        public string Nama { get; set; }
        public string Alamat { get; set; }
        public string Telp { get; set; }
    }
}
