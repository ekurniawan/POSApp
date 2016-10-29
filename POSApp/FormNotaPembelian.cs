using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DAL;
using BO;

namespace POSApp
{
    public partial class FormNotaPembelian : Form
    {

        #region singleton
        private static FormNotaPembelian _instance;
        public static FormNotaPembelian Instance()
        {
            if (_instance == null)
                _instance = new FormNotaPembelian();

            return _instance;
        }
        #endregion


        public FormNotaPembelian()
        {
            InitializeComponent();
        }

        #region exposed property

        public TextBox TxtKodePelanggan
        {
            get
            {
                return txtKodePelanggan;
            }
            set
            {
                txtKodePelanggan = value;
            }
        }
        public TextBox TxtNamaPelanggan
        {
            get
            {
                return txtNamaPelanggan;
            }
            set
            {
                txtNamaPelanggan = value;
            }
        }
        public TextBox TxtAlamat
        {
            get
            {
                return txtAlamat;
            }
            set
            {
                txtAlamat = value;
            }
        }
        public TextBox TxtTelp
        {
            get
            {
                return txtTelp;
            }
            set
            {
                txtTelp = value;
            }
        }

        #endregion

        private void BuatNota()
        {
            txtTanggal.Value = DateTime.Now;

            //buat nomor nota baru
            NotaPembelianDAL notaBeliDAL = new NotaPembelianDAL();
            var newNota = new NotaPembelian
            {
                KodePemasok = 1,
                Tanggal = txtTanggal.Value
            };

            try
            {
                var nonota = notaBeliDAL.GetNoNotaPembelian(newNota);
                txtNoNota.Text = nonota.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Keterangan", MessageBoxButtons.OK,
                      MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void FormNotaPembelian_Load(object sender, EventArgs e)
        {
            
        }
    }
}
