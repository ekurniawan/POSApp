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
    public partial class FormPemasok : Form
    {
        private BindingSource bs;

        public FormPemasok()
        {
            InitializeComponent();
        }

        #region InisialisasiBinding
        private void HapusBinding()
        {
            txtKode.DataBindings.Clear();
            txtNama.DataBindings.Clear();
            txtAlamat.DataBindings.Clear();
            txtTelp.DataBindings.Clear();
        }

        private void TambahBinding()
        {
            HapusBinding();
            txtKode.DataBindings.Add("Text", bs, "KodePemasok");
            txtNama.DataBindings.Add("Text", bs, "Nama");
            txtAlamat.DataBindings.Add("Text", bs, "Alamat");
            txtTelp.DataBindings.Add("Text", bs, "Telp");
        }
        #endregion

        #region Inisialisasi Kontrol
        private void InisialisasiAwal()
        {
            foreach(var ctr in this.Controls)
            {
                if(ctr is TextBox)
                {
                    var myTxt = ctr as TextBox;
                    myTxt.Enabled = false;
                }
                else if(ctr is Button)
                {
                    var myBtn = ctr as Button;
                    myBtn.Enabled = true;
                }
            }

            btnSave.Enabled = false;
        }
        #endregion

        private void FormPemasok_Load(object sender, EventArgs e)
        {
            PemasokDAL pemasokDAL = new PemasokDAL();

            bs = new BindingSource();
            bs.DataSource = pemasokDAL.GetAll();
            TambahBinding();
            InisialisasiAwal();
            
            dgvPemasok.DataSource = bs;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            bs.MoveFirst();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            bs.MovePrevious();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bs.MoveNext();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            bs.MoveLast();
        }
    }
}
