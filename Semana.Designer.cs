namespace ProcesadorNominaas
{
    partial class Semana
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
            this.DataGridSemana = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnCargaLunes = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridSemana)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridSemana
            // 
            this.DataGridSemana.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridSemana.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DataGridSemana.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridSemana.Location = new System.Drawing.Point(3, 42);
            this.DataGridSemana.Name = "DataGridSemana";
            this.DataGridSemana.RowHeadersWidth = 51;
            this.DataGridSemana.RowTemplate.Height = 24;
            this.DataGridSemana.Size = new System.Drawing.Size(1516, 707);
            this.DataGridSemana.TabIndex = 1;
            this.DataGridSemana.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridSemana_CellContentClick);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(707, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "SEMANA";
            // 
            // BtnCargaLunes
            // 
            this.BtnCargaLunes.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnCargaLunes.BackColor = System.Drawing.Color.MediumAquamarine;
            this.BtnCargaLunes.IconChar = FontAwesome.Sharp.IconChar.DollarSign;
            this.BtnCargaLunes.IconColor = System.Drawing.Color.White;
            this.BtnCargaLunes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnCargaLunes.IconSize = 30;
            this.BtnCargaLunes.Location = new System.Drawing.Point(681, 766);
            this.BtnCargaLunes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnCargaLunes.Name = "BtnCargaLunes";
            this.BtnCargaLunes.Size = new System.Drawing.Size(145, 39);
            this.BtnCargaLunes.TabIndex = 48;
            this.BtnCargaLunes.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(534, 766);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 29);
            this.label2.TabIndex = 49;
            this.label2.Text = "PAGAR:";
            // 
            // Semana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1522, 816);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnCargaLunes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DataGridSemana);
            this.Name = "Semana";
            this.Text = "Semana";
            this.Load += new System.EventHandler(this.Semana_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridSemana)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridSemana;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton BtnCargaLunes;
        private System.Windows.Forms.Label label2;
    }
}