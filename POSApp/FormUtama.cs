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
    public partial class FormUtama : Form
    {
        private static FormUtama _instance;
        public static FormUtama Instance()
        {
            if (_instance == null)
                _instance = new FormUtama();

            return _instance;
        }

        public FormUtama()
        {
            InitializeComponent();
        }
    }
}
