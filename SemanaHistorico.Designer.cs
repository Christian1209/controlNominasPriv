namespace ProcesadorNominaas
{
    partial class SemanaHistorico
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
            this.panel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSiguienteSemana = new FontAwesome.Sharp.IconButton();
            this.btnSemanaAnterior = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.Location = new System.Drawing.Point(-2, 73);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1506, 721);
            this.panel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(646, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "HISTORICO SEMANAS";
            // 
            // btnSiguienteSemana
            // 
            this.btnSiguienteSemana.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSiguienteSemana.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(182)))), ((int)(((byte)(236)))));
            this.btnSiguienteSemana.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSiguienteSemana.IconChar = FontAwesome.Sharp.IconChar.ArrowRight;
            this.btnSiguienteSemana.IconColor = System.Drawing.Color.Black;
            this.btnSiguienteSemana.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSiguienteSemana.IconSize = 28;
            this.btnSiguienteSemana.Location = new System.Drawing.Point(513, 11);
            this.btnSiguienteSemana.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSiguienteSemana.Name = "btnSiguienteSemana";
            this.btnSiguienteSemana.Size = new System.Drawing.Size(75, 51);
            this.btnSiguienteSemana.TabIndex = 161;
            this.btnSiguienteSemana.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSiguienteSemana.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSiguienteSemana.UseVisualStyleBackColor = false;
            this.btnSiguienteSemana.Click += new System.EventHandler(this.btnSiguienteSemana_Click);
            // 
            // btnSemanaAnterior
            // 
            this.btnSemanaAnterior.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSemanaAnterior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(182)))), ((int)(((byte)(236)))));
            this.btnSemanaAnterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSemanaAnterior.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft;
            this.btnSemanaAnterior.IconColor = System.Drawing.Color.Black;
            this.btnSemanaAnterior.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSemanaAnterior.IconSize = 28;
            this.btnSemanaAnterior.Location = new System.Drawing.Point(440, 11);
            this.btnSemanaAnterior.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSemanaAnterior.Name = "btnSemanaAnterior";
            this.btnSemanaAnterior.Size = new System.Drawing.Size(67, 51);
            this.btnSemanaAnterior.TabIndex = 162;
            this.btnSemanaAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSemanaAnterior.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSemanaAnterior.UseVisualStyleBackColor = false;
            this.btnSemanaAnterior.Click += new System.EventHandler(this.btnSemanaAnterior_Click);
            // 
            // SemanaHistorico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1500, 791);
            this.Controls.Add(this.btnSemanaAnterior);
            this.Controls.Add(this.btnSiguienteSemana);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel);
            this.Name = "SemanaHistorico";
            this.Text = "SemanaHistorico";
            this.Load += new System.EventHandler(this.SemanaHistorico_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton btnSiguienteSemana;
        private FontAwesome.Sharp.IconButton btnSemanaAnterior;
    }
}