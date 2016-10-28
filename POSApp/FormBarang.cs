using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POSApp.Helpers;

using BO;
using DAL;

namespace POSApp
{
    public partial class FormBarang : Form
    {
        private BindingSource bs;
        private bool isNew = false; 

        public FormBarang()
        {
            InitializeComponent();
            bs = new BindingSource();
        }

        #region InisialisasiBinding

        private void TambahBinding()
        {
            BindingHelper.HapusBinding(this);
            txtKode.DataBindings.Add("Text", bs, "KodeBarang");
            txtNama.DataBindings.Add("Text", bs, "Nama");
            txtHargaBeli.DataBindings.Add("Text", bs, "HargaBeli",
                true,DataSourceUpdateMode.Never,null,"N0");
            txtHargaJual.DataBindings.Add("Text", bs, "HargaJual",true,
                DataSourceUpdateMode.Never,null,"N0");
            txtJumlah.DataBindings.Add("Text", bs, "Stok");
        }
        #endregion

        #region Inisialisasi Kontrol

        private void IsiData()
        {
            BarangDAL barangDAL = new BarangDAL();

            bs = new BindingSource();
            bs.DataSource = barangDAL.GetAll();
            TambahBinding();
            InisialisasiAwal();

            dgvBarang.DataSource = bs;
            isNew = false;
        }

        private void InisialisasiAwal()
        {
            foreach (var ctr in this.Controls)
            {
                if (ctr is TextBox)
                {
                    var myTxt = ctr as TextBox;
                    myTxt.Enabled = false;
                }
                else if (ctr is Button)
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
            BindingHelper.HapusBinding(this);
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
            BindingHelper.HapusBinding(this);
        }
        #endregion

        private void FormBarang_Load(object sender, EventArgs e)
        {
            IsiData();
        }
    }
}
