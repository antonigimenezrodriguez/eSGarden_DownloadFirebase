namespace eSGarden_DownloadFirebase
{
    partial class eSGarden_DownloadFirebase
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxGardens = new System.Windows.Forms.ListBox();
            this.listBoxCampos = new System.Windows.Forms.ListBox();
            this.btnDescargarCSV = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxGardens
            // 
            this.listBoxGardens.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxGardens.FormattingEnabled = true;
            this.listBoxGardens.ItemHeight = 19;
            this.listBoxGardens.Location = new System.Drawing.Point(52, 62);
            this.listBoxGardens.Name = "listBoxGardens";
            this.listBoxGardens.Size = new System.Drawing.Size(229, 308);
            this.listBoxGardens.TabIndex = 0;
            this.listBoxGardens.SelectedIndexChanged += new System.EventHandler(this.listBoxGardens_SelectedIndexChanged);
            // 
            // listBoxCampos
            // 
            this.listBoxCampos.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxCampos.FormattingEnabled = true;
            this.listBoxCampos.ItemHeight = 19;
            this.listBoxCampos.Location = new System.Drawing.Point(442, 62);
            this.listBoxCampos.Name = "listBoxCampos";
            this.listBoxCampos.Size = new System.Drawing.Size(229, 308);
            this.listBoxCampos.TabIndex = 1;
            // 
            // btnDescargarCSV
            // 
            this.btnDescargarCSV.Location = new System.Drawing.Point(792, 177);
            this.btnDescargarCSV.Name = "btnDescargarCSV";
            this.btnDescargarCSV.Size = new System.Drawing.Size(75, 45);
            this.btnDescargarCSV.TabIndex = 2;
            this.btnDescargarCSV.Text = "Descargar CSV";
            this.btnDescargarCSV.UseVisualStyleBackColor = true;
            this.btnDescargarCSV.Click += new System.EventHandler(this.btnDescargarCSV_Click);
            // 
            // eSGarden_DownloadFirebase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 583);
            this.Controls.Add(this.btnDescargarCSV);
            this.Controls.Add(this.listBoxCampos);
            this.Controls.Add(this.listBoxGardens);
            this.Name = "eSGarden_DownloadFirebase";
            this.Text = "Huertos";
            this.Load += new System.EventHandler(this.Huertos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxGardens;
        private System.Windows.Forms.ListBox listBoxCampos;
        private System.Windows.Forms.Button btnDescargarCSV;
    }
}

