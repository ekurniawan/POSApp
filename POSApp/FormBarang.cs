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
        private Barang currBarang = null;

        public FormBarang()
        {
            InitializeComponent();
            //dgvBarang.AutoGenerateColumns = false;
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
            txtStok.DataBindings.Add("Text", bs, "Stok");
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
            BindingHelper.HapusBinding(this);

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

           
            btnSave.Enabled = true;
            txtKode.Focus();
           
            isNew = true; 
        }

        private void InisialisasiEdit()
        {
            BindingHelper.HapusBinding(this);

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
        }
        #endregion

        private void FormBarang_Load(object sender, EventArgs e)
        {
            IsiData();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            InisialisasiNew();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BarangDAL barangDAL = new BarangDAL();
            if(isNew)
            {
                var newBarang = new Barang
                {
                    KodeBarang = txtKode.Text,
                    Nama = txtNama.Text,
                    HargaBeli = Convert.ToDecimal(txtHargaBeli.Text),
                    HargaJual = Convert.ToDecimal(txtHargaJual.Text),
                    Stok = Convert.ToInt32(txtStok.Text)
                };

                try
                {
                    bs.Add(newBarang);
                    barangDAL.Create(newBarang);
                    InisialisasiAwal();
                    TambahBinding();

                    tssKeterangan.Text = string.Format("Berhasil menambah data {0}", 
                        newBarang.Nama);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message, "Keterangan", MessageBoxButtons.OK,
                       MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                try
                {
                    currBarang.Nama = txtNama.Text;
                    currBarang.HargaBeli = Convert.ToDecimal(txtHargaBeli.Text);
                    currBarang.HargaJual = Convert.ToDecimal(txtHargaJual.Text);
                    currBarang.Stok = Convert.ToInt32(txtStok.Text);

                    barangDAL.Update(currBarang);
                    InisialisasiAwal();
                    TambahBinding();

                    tssKeterangan.Text = string.Format("Berhasil mengedit data {0}",
                       currBarang.Nama);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message, "Keterangan", MessageBoxButtons.OK,
                       MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            currBarang = (Barang)bs.Current;
            InisialisasiEdit();
        }
    }
}
