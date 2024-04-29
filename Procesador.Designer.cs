namespace ProcesadorNominaas
{
    partial class Procesador
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
            this.label2 = new System.Windows.Forms.Label();
            this.TxtBoxRutaLunes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnDeleteRutaLunes = new FontAwesome.Sharp.IconButton();
            this.BtnProcesar = new FontAwesome.Sharp.IconButton();
            this.DataGridNoRegistrados = new System.Windows.Forms.DataGridView();
            this.LblNoRegistrados = new System.Windows.Forms.Label();
            this.BtnCargaLunes = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridNoRegistrados)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(125, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(506, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Establece las rutas del archivo que contiene los registros.";
            // 
            // TxtBoxRutaLunes
            // 
            this.TxtBoxRutaLunes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtBoxRutaLunes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBoxRutaLunes.Location = new System.Drawing.Point(12, 160);
            this.TxtBoxRutaLunes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtBoxRutaLunes.Name = "TxtBoxRutaLunes";
            this.TxtBoxRutaLunes.Size = new System.Drawing.Size(861, 30);
            this.TxtBoxRutaLunes.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(55, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 32);
            this.label3.TabIndex = 12;
            this.label3.Text = "Archivo :";
            // 
            // BtnDeleteRutaLunes
            // 
            this.BtnDeleteRutaLunes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BtnDeleteRutaLunes.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.BtnDeleteRutaLunes.IconColor = System.Drawing.Color.White;
            this.BtnDeleteRutaLunes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnDeleteRutaLunes.IconSize = 20;
            this.BtnDeleteRutaLunes.Location = new System.Drawing.Point(416, 103);
            this.BtnDeleteRutaLunes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnDeleteRutaLunes.Name = "BtnDeleteRutaLunes";
            this.BtnDeleteRutaLunes.Size = new System.Drawing.Size(63, 42);
            this.BtnDeleteRutaLunes.TabIndex = 37;
            this.BtnDeleteRutaLunes.UseVisualStyleBackColor = false;
            this.BtnDeleteRutaLunes.Click += new System.EventHandler(this.BtnDeleteRutaLunes_Click);
            // 
            // BtnProcesar
            // 
            this.BtnProcesar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BtnProcesar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnProcesar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.BtnProcesar.IconColor = System.Drawing.Color.White;
            this.BtnProcesar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnProcesar.IconSize = 20;
            this.BtnProcesar.Location = new System.Drawing.Point(745, 111);
            this.BtnProcesar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnProcesar.Name = "BtnProcesar";
            this.BtnProcesar.Size = new System.Drawing.Size(208, 34);
            this.BtnProcesar.TabIndex = 44;
            this.BtnProcesar.Text = "PROCESAR";
            this.BtnProcesar.UseVisualStyleBackColor = false;
            this.BtnProcesar.Click += new System.EventHandler(this.BtnProcesar_Click);
            // 
            // DataGridNoRegistrados
            // 
            this.DataGridNoRegistrados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridNoRegistrados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridNoRegistrados.Location = new System.Drawing.Point(16, 266);
            this.DataGridNoRegistrados.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DataGridNoRegistrados.Name = "DataGridNoRegistrados";
            this.DataGridNoRegistrados.RowHeadersWidth = 51;
            this.DataGridNoRegistrados.Size = new System.Drawing.Size(1003, 315);
            this.DataGridNoRegistrados.TabIndex = 45;
            this.DataGridNoRegistrados.Visible = false;
            // 
            // LblNoRegistrados
            // 
            this.LblNoRegistrados.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblNoRegistrados.AutoSize = true;
            this.LblNoRegistrados.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNoRegistrados.ForeColor = System.Drawing.Color.Red;
            this.LblNoRegistrados.Location = new System.Drawing.Point(233, 218);
            this.LblNoRegistrados.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblNoRegistrados.Name = "LblNoRegistrados";
            this.LblNoRegistrados.Size = new System.Drawing.Size(334, 29);
            this.LblNoRegistrados.TabIndex = 46;
            this.LblNoRegistrados.Text = "Empleados No Registrados";
            this.LblNoRegistrados.Visible = false;
            // 
            // BtnCargaLunes
            // 
            this.BtnCargaLunes.BackColor = System.Drawing.Color.MediumAquamarine;
            this.BtnCargaLunes.IconChar = FontAwesome.Sharp.IconChar.FileExcel;
            this.BtnCargaLunes.IconColor = System.Drawing.Color.White;
            this.BtnCargaLunes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnCargaLunes.IconSize = 20;
            this.BtnCargaLunes.Location = new System.Drawing.Point(252, 103);
            this.BtnCargaLunes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnCargaLunes.Name = "BtnCargaLunes";
            this.BtnCargaLunes.Size = new System.Drawing.Size(145, 42);
            this.BtnCargaLunes.TabIndex = 47;
            this.BtnCargaLunes.UseVisualStyleBackColor = false;
            this.BtnCargaLunes.Click += new System.EventHandler(this.BtnCargaLunes_Click_1);
            // 
            // Procesador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1043, 704);
            this.Controls.Add(this.BtnCargaLunes);
            this.Controls.Add(this.LblNoRegistrados);
            this.Controls.Add(this.DataGridNoRegistrados);
            this.Controls.Add(this.BtnProcesar);
            this.Controls.Add(this.BtnDeleteRutaLunes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtBoxRutaLunes);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Procesador";
            this.Text = "Procesador";
            this.Load += new System.EventHandler(this.Procesador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridNoRegistrados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtBoxRutaLunes;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconButton BtnDeleteRutaLunes;
        private FontAwesome.Sharp.IconButton BtnProcesar;
        private System.Windows.Forms.DataGridView DataGridNoRegistrados;
        private System.Windows.Forms.Label LblNoRegistrados;
        private FontAwesome.Sharp.IconButton BtnCargaLunes;
    }
}