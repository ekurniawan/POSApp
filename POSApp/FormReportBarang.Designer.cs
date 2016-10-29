namespace POSApp
{
    partial class FormReportBarang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewerBarang = new Microsoft.Reporting.WinForms.ReportViewer();
            this.BarangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.BarangBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewerBarang
            // 
            this.reportViewerBarang.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.BarangBindingSource;
            this.reportViewerBarang.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewerBarang.LocalReport.ReportEmbeddedResource = "POSApp.Reports.ReportBarang.rdlc";
            this.reportViewerBarang.Location = new System.Drawing.Point(0, 0);
            this.reportViewerBarang.Name = "reportViewerBarang";
            this.reportViewerBarang.Size = new System.Drawing.Size(666, 453);
            this.reportViewerBarang.TabIndex = 0;
            // 
            // BarangBindingSource
            // 
            this.BarangBindingSource.DataSource = typeof(BO.Barang);
            // 
            // FormReportBarang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 453);
            this.Controls.Add(this.reportViewerBarang);
            this.Name = "FormReportBarang";
            this.Text = "FormReportBarang";
            this.Load += new System.EventHandler(this.FormReportBarang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BarangBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerBarang;
        private System.Windows.Forms.BindingSource BarangBindingSource;
    }
}