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
        public DateTimePicker TxtTanggal
        {
            get
            {
                return txtTanggal;
            }
            set
            {
                txtTanggal = value;
            }
        }
        public TextBox TxtNoNota
        {
            get
            {
                return txtNoNota;
            }
            set
            {
                txtNoNota = value;
            }
        }

        public TextBox TxtKodeBarang
        {
            get
            {
                return txtKodeBarang;
            }
            set
            {
                txtKodeBarang = value;
            }
        }
        public TextBox TxtNamaBarang
        {
            get
            {
                return txtNamaBarang;
            }
            set
            {
                txtNamaBarang = value;
            }
        }
        public TextBox TxtHargaJual
        {
            get
            {
                return txtHargaJual;
            }
            set
            {
                txtHargaJual = value;
            }
        }
        public TextBox TxtJumlah
        {
            get
            {
                return txtJumlah;
            }
            set
            {
                txtJumlah = value;
            }
        }

        public TextBox TxtKodePemasok
        {
            get
            {
                return txtKodePemasok;
            }
            set
            {
                txtKodePemasok = value;
            }
        }
        public TextBox TxtNamaPemasok
        {
            get
            {
                return txtNamaPemasok;
            }
            set
            {
                txtNamaPemasok = value;
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
            BuatNota();
        }

        private void btnShowPemasok_Click(object sender, EventArgs e)
        {
            FormPemasok.Instance().Show();
        }

        private void txtKodeBarang_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                FormBarang.Instance().Show();
            }
        }

        private void txtJumlah_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                var subtotal = Convert.ToDecimal(txtJumlah.Text) * Convert.ToDecimal(txtHargaJual.Text);
                txtSubtotal.Text = string.Format("{0:N0}", subtotal);
            }
        }
    }
}
