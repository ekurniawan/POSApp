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
using POSApp.Helpers;

namespace POSApp
{
    public partial class FormPemasok : Form
    {
        #region singleton
        private static FormPemasok _instance;
        public static FormPemasok Instance()
        {
            if (_instance == null)
                _instance = new FormPemasok();

            return _instance;
        }
        #endregion

        private BindingSource bs;
        private bool isNew = false;
        private Pemasok editPemasok;
        private List<Pemasok> listPemasok;

        public FormPemasok()
        {
            InitializeComponent();
        }

        #region InisialisasiBinding

        private void TambahBinding()
        {
            BindingHelper.HapusBinding(this);
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
            listPemasok = pemasokDAL.GetAll().ToList();
            bs.DataSource = listPemasok;
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

            txtSearch.Enabled = true;
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

                    tssKeterangan.Text = "Tambah data berhasil !";
                    //IsiData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show( "Error : " + ex.Message, "Keterangan", MessageBoxButtons.OK,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                
            }
            else
            {
                editPemasok.Nama = txtNama.Text;
                editPemasok.Alamat = txtAlamat.Text;
                editPemasok.Telp = txtTelp.Text;

                try
                {
                    pemasokDAL.Update(editPemasok);
                    TambahBinding();
                    InisialisasiAwal();
                    tssKeterangan.Text = "Data berhasil diupdate !";

                    //pendekatan kedua query data dari tabel
                    //IsiData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show( "Error : " + ex.Message, "Keterangan",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error, 
                        MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            editPemasok = (Pemasok)bs.Current;
            InisialisasiEdit();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            PemasokDAL pemasokDAL = new PemasokDAL();
            editPemasok = (Pemasok)bs.Current;
            try
            {
                if(MessageBox.Show("Apakah anda yakin mendelete data ini ?",
                    "Konfirmasi",MessageBoxButtons.YesNo,MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    pemasokDAL.Delete(editPemasok.KodePemasok);
                    bs.Remove(bs.Current);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Keterangan",
 
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error,
                         MessageBoxDefaultButton.Button1);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            bs.DataSource = listPemasok.Where(p => p.Nama.Contains(txtSearch.Text)).ToList();
        }

        private void dgvPemasok_DoubleClick(object sender, EventArgs e)
        {
            Pemasok currPemasok = (Pemasok)bs.Current;
            FormNotaPembelian.Instance().TxtKodePemasok.Text = currPemasok.KodePemasok.ToString();
            FormNotaPembelian.Instance().TxtNamaPemasok.Text = currPemasok.Nama;
            FormNotaPembelian.Instance().TxtAlamat.Text = currPemasok.Alamat;
            FormNotaPembelian.Instance().TxtTelp.Text = currPemasok.Telp;

            //update nota pembelian
            NotaPembelianDAL notaBeliDAL = new NotaPembelianDAL();
            var editNotaBeli = new NotaPembelian
            {
                KodePemasok = currPemasok.KodePemasok,
                Tanggal = FormNotaPembelian.Instance().TxtTanggal.Value,
                KodeNotaBeli = Convert.ToInt32(FormNotaPembelian.Instance().TxtNoNota.Text)
            };
            notaBeliDAL.Update(editNotaBeli);

            this.Close();
        }
    }
}
