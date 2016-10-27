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
        public FormPemasok()
        {
            InitializeComponent();
        }

        private void FormPemasok_Load(object sender, EventArgs e)
        {
            PemasokDAL pemasokDAL = new PemasokDAL();
            var results = pemasokDAL.GetAll();

            
            dgvPemasok.DataSource = results;
        }
    }
}
