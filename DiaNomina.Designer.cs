namespace ProcesadorNominaas
{
    partial class DiaNomina
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
            this.DataGridDia = new System.Windows.Forms.DataGridView();
            this.lblDia = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridDia)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridDia
            // 
            this.DataGridDia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridDia.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DataGridDia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridDia.Location = new System.Drawing.Point(-1, 51);
            this.DataGridDia.Name = "DataGridDia";
            this.DataGridDia.ReadOnly = true;
            this.DataGridDia.RowHeadersWidth = 51;
            this.DataGridDia.RowTemplate.Height = 24;
            this.DataGridDia.Size = new System.Drawing.Size(1668, 908);
            this.DataGridDia.TabIndex = 0;
            // 
            // lblDia
            // 
            this.lblDia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDia.AutoSize = true;
            this.lblDia.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDia.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDia.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblDia.Location = new System.Drawing.Point(842, 9);
            this.lblDia.Name = "lblDia";
            this.lblDia.Size = new System.Drawing.Size(0, 29);
            this.lblDia.TabIndex = 1;
            // 
            // DiaNomina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1664, 958);
            this.Controls.Add(this.lblDia);
            this.Controls.Add(this.DataGridDia);
            this.Name = "DiaNomina";
            this.Text = "DiaNomina";
            this.Load += new System.EventHandler(this.DiaNomina_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridDia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridDia;
        private System.Windows.Forms.Label lblDia;
    }
}