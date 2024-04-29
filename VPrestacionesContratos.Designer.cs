namespace ProcesadorNominaas
{
    partial class VPrestacionesContratos
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
            this.BtnContratos = new FontAwesome.Sharp.IconButton();
            this.BtnVacaciones = new FontAwesome.Sharp.IconButton();
            this.BtnAguinaldos = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnContratos
            // 
            this.BtnContratos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(213)))), ((int)(((byte)(236)))));
            this.BtnContratos.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnContratos.IconChar = FontAwesome.Sharp.IconChar.File;
            this.BtnContratos.IconColor = System.Drawing.Color.White;
            this.BtnContratos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnContratos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnContratos.Location = new System.Drawing.Point(106, 90);
            this.BtnContratos.Margin = new System.Windows.Forms.Padding(2);
            this.BtnContratos.Name = "BtnContratos";
            this.BtnContratos.Size = new System.Drawing.Size(179, 44);
            this.BtnContratos.TabIndex = 3;
            this.BtnContratos.Text = "Contratos";
            this.BtnContratos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnContratos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnContratos.UseVisualStyleBackColor = false;
            // 
            // BtnVacaciones
            // 
            this.BtnVacaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(213)))), ((int)(((byte)(236)))));
            this.BtnVacaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnVacaciones.IconChar = FontAwesome.Sharp.IconChar.File;
            this.BtnVacaciones.IconColor = System.Drawing.Color.White;
            this.BtnVacaciones.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnVacaciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnVacaciones.Location = new System.Drawing.Point(342, 90);
            this.BtnVacaciones.Margin = new System.Windows.Forms.Padding(2);
            this.BtnVacaciones.Name = "BtnVacaciones";
            this.BtnVacaciones.Size = new System.Drawing.Size(193, 44);
            this.BtnVacaciones.TabIndex = 4;
            this.BtnVacaciones.Text = "Vacaciones";
            this.BtnVacaciones.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnVacaciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnVacaciones.UseVisualStyleBackColor = false;
            this.BtnVacaciones.Click += new System.EventHandler(this.BtnVacaciones_Click);
            // 
            // BtnAguinaldos
            // 
            this.BtnAguinaldos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(213)))), ((int)(((byte)(236)))));
            this.BtnAguinaldos.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAguinaldos.IconChar = FontAwesome.Sharp.IconChar.File;
            this.BtnAguinaldos.IconColor = System.Drawing.Color.White;
            this.BtnAguinaldos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnAguinaldos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAguinaldos.Location = new System.Drawing.Point(601, 90);
            this.BtnAguinaldos.Margin = new System.Windows.Forms.Padding(2);
            this.BtnAguinaldos.Name = "BtnAguinaldos";
            this.BtnAguinaldos.Size = new System.Drawing.Size(193, 44);
            this.BtnAguinaldos.TabIndex = 5;
            this.BtnAguinaldos.Text = "Aguinaldos";
            this.BtnAguinaldos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAguinaldos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnAguinaldos.UseVisualStyleBackColor = false;
            this.BtnAguinaldos.Click += new System.EventHandler(this.BtnAguinaldos_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label1.Location = new System.Drawing.Point(323, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Prestaciones y Contratos";
            // 
            // VPrestacionesContratos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(937, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnAguinaldos);
            this.Controls.Add(this.BtnVacaciones);
            this.Controls.Add(this.BtnContratos);
            this.Name = "VPrestacionesContratos";
            this.Text = "VPrestacionesContratos";
            this.Load += new System.EventHandler(this.VPrestacionesContratos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton BtnContratos;
        private FontAwesome.Sharp.IconButton BtnVacaciones;
        private FontAwesome.Sharp.IconButton BtnAguinaldos;
        private System.Windows.Forms.Label label1;
    }
}