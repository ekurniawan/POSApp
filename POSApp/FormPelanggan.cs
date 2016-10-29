using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BO;
using DAL;

namespace POSApp
{
    public partial class FormPelanggan : Form
    {
        public FormPelanggan()
        {
            InitializeComponent();
        }

        private void FormPelanggan_Load(object sender, EventArgs e)
        {
            PelangganDAL pelangganDAL = new PelangganDAL();
            var results = pelangganDAL.GetAll();

            dgvPelanggan.DataSource = results;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            PelangganDAL pelangganDAL = new PelangganDAL();
            var newPelanggan = new Pelanggan
            {
                Nama = "Bambang",
                Alamat = "Jetis",
                Telp = "556677"
            };

            try
            {
                pelangganDAL.Insert(newPelanggan);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
