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
    }
}
