using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSApp
{
    public partial class FormUtama : Form
    {
        private static FormUtama _instance;
        public static FormUtama Instance()
        {
            if (_instance == null)
                _instance = new FormUtama();

            return _instance;
        }

        public FormUtama()
        {
            InitializeComponent();
        }

        private void masterBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBarang.Instance().Show();
        }

        private void masterPemasokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPemasok.Instance().Show();
        }

        private void transaksiPembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNotaPembelian.Instance().Show();
        }
    }
}
