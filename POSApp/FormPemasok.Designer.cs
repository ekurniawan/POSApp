namespace POSApp
{
    partial class FormPemasok
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
            this.dgvPemasok = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPemasok)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPemasok
            // 
            this.dgvPemasok.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPemasok.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvPemasok.Location = new System.Drawing.Point(0, 112);
            this.dgvPemasok.Name = "dgvPemasok";
            this.dgvPemasok.Size = new System.Drawing.Size(551, 176);
            this.dgvPemasok.TabIndex = 0;
            // 
            // FormPemasok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 288);
            this.Controls.Add(this.dgvPemasok);
            this.Name = "FormPemasok";
            this.Text = "FormPemasok";
            this.Load += new System.EventHandler(this.FormPemasok_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPemasok)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPemasok;
    }
}