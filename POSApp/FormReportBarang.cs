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
using Microsoft.Reporting.WinForms;

namespace POSApp
{
    public partial class FormReportBarang : Form
    {
        public FormReportBarang()
        {
            InitializeComponent();
        }

        private void FormReportBarang_Load(object sender, EventArgs e)
        {
            BarangDAL barangDAL = new BarangDAL();
            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("paramKode", "LN0001");
            this.reportViewerBarang.LocalReport.SetParameters(parameters);

            BarangBindingSource.DataSource = barangDAL.GetAll();

            this.reportViewerBarang.RefreshReport();
        }
    }
}
