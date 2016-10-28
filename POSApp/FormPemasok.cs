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
        private bool isNew = false;

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
            txtKode.DataBindings.Add("Text", bs, "KodePemasok", true, DataSourceUpdateMode.Never, "", "");
            txtNama.DataBindings.Add("Text", bs, "Nama");
            txtAlamat.DataBindings.Add("Text", bs, "Alamat");
            txtTelp.DataBindings.Add("Text", bs, "Telp");
        }
        #endregion

        #region Inisialisasi Kontrol

        private void IsiData()
        {
            PemasokDAL pemasokDAL = new PemasokDAL();

            bs = new BindingSource();
            bs.DataSource = pemasokDAL.GetAll();
            TambahBinding();
            InisialisasiAwal();

            dgvPemasok.DataSource = bs;
            isNew = false;
        }

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

        private void InisialisasiNew()
        {
            foreach (var ctr in this.Controls)
            {
                if (ctr is TextBox)
                {
                    var myTxt = ctr as TextBox;
                    myTxt.Text = string.Empty;
                    myTxt.Enabled = true;
                }
                else if (ctr is Button)
                {
                    var myBtn = ctr as Button;
                    myBtn.Enabled = false;
                }
            }

            txtKode.Enabled = false;
            btnSave.Enabled = true;
            txtNama.Focus();
            isNew = true;
            HapusBinding();
        }

        private void InisialisasiEdit()
        {
            foreach (var ctr in this.Controls)
            {
                if (ctr is TextBox)
                {
                    var myTxt = ctr as TextBox;
                    myTxt.Enabled = true;
                }
                else if (ctr is Button)
                {
                    var myBtn = ctr as Button;
                    myBtn.Enabled = false;
                }
            }

            txtKode.Enabled = false;
            btnSave.Enabled = true;
            txtNama.Focus();
            isNew = false;
            HapusBinding();
        }
        #endregion

        private void FormPemasok_Load(object sender, EventArgs e)
        {
            IsiData();
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            InisialisasiNew();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PemasokDAL pemasokDAL = new PemasokDAL();
            if (isNew)
            {
                var newPemasok = new Pemasok
                {
                    Nama = txtNama.Text,
                    Alamat = txtAlamat.Text,
                    Telp = txtTelp.Text
                };

                try
                {
                    var result = pemasokDAL.Create(newPemasok);
                    newPemasok.KodePemasok = result;
                    bs.Add(newPemasok);

                    TambahBinding();
                    InisialisasiAwal();

                    //IsiData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            InisialisasiEdit();
        }
    }
}
