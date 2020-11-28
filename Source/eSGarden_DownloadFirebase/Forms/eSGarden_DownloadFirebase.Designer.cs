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
            this.label1 = new System.Windows.Forms.Label();
            this.LB_Name = new System.Windows.Forms.Label();
            this.LB_Vegetable = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxGardens
            // 
            this.listBoxGardens.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxGardens.FormattingEnabled = true;
            this.listBoxGardens.ItemHeight = 19;
            this.listBoxGardens.Location = new System.Drawing.Point(12, 12);
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
            this.listBoxCampos.Location = new System.Drawing.Point(282, 12);
            this.listBoxCampos.Name = "listBoxCampos";
            this.listBoxCampos.Size = new System.Drawing.Size(229, 308);
            this.listBoxCampos.TabIndex = 1;
            this.listBoxCampos.SelectedIndexChanged += new System.EventHandler(this.listBoxCampos_SelectedIndexChanged);
            // 
            // btnDescargarCSV
            // 
            this.btnDescargarCSV.Location = new System.Drawing.Point(618, 275);
            this.btnDescargarCSV.Name = "btnDescargarCSV";
            this.btnDescargarCSV.Size = new System.Drawing.Size(75, 45);
            this.btnDescargarCSV.TabIndex = 2;
            this.btnDescargarCSV.Text = "Descargar CSV";
            this.btnDescargarCSV.UseVisualStyleBackColor = true;
            this.btnDescargarCSV.Click += new System.EventHandler(this.btnDescargarCSV_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(547, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name:";
            // 
            // LB_Name
            // 
            this.LB_Name.AutoSize = true;
            this.LB_Name.Location = new System.Drawing.Point(594, 57);
            this.LB_Name.Name = "LB_Name";
            this.LB_Name.Size = new System.Drawing.Size(35, 13);
            this.LB_Name.TabIndex = 4;
            this.LB_Name.Text = "Name";
            // 
            // LB_Vegetable
            // 
            this.LB_Vegetable.AutoSize = true;
            this.LB_Vegetable.Location = new System.Drawing.Point(594, 87);
            this.LB_Vegetable.Name = "LB_Vegetable";
            this.LB_Vegetable.Size = new System.Drawing.Size(55, 13);
            this.LB_Vegetable.TabIndex = 6;
            this.LB_Vegetable.Text = "Vegetable";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(527, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Vegetable:";
            // 
            // eSGarden_DownloadFirebase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 343);
            this.Controls.Add(this.LB_Vegetable);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LB_Name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDescargarCSV);
            this.Controls.Add(this.listBoxCampos);
            this.Controls.Add(this.listBoxGardens);
            this.Name = "eSGarden_DownloadFirebase";
            this.Text = "Huertos";
            this.Load += new System.EventHandler(this.Huertos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxGardens;
        private System.Windows.Forms.ListBox listBoxCampos;
        private System.Windows.Forms.Button btnDescargarCSV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LB_Name;
        private System.Windows.Forms.Label LB_Vegetable;
        private System.Windows.Forms.Label label2;
    }
}

