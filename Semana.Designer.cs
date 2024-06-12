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
            this.label2 = new System.Windows.Forms.Label();
            this.BtnImprimeTodo = new FontAwesome.Sharp.IconButton();
            this.lblSemanaLabel = new System.Windows.Forms.Label();
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
            this.DataGridSemana.Location = new System.Drawing.Point(3, 59);
            this.DataGridSemana.Name = "DataGridSemana";
            this.DataGridSemana.RowHeadersWidth = 51;
            this.DataGridSemana.RowTemplate.Height = 24;
            this.DataGridSemana.Size = new System.Drawing.Size(1495, 664);
            this.DataGridSemana.TabIndex = 1;
            this.DataGridSemana.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridSemana_CellContentClick);
            this.DataGridSemana.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridSemana_CellEnter);
            this.DataGridSemana.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridSemana_CellValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(568, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "SEMANA:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(291, 740);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(414, 29);
            this.label2.TabIndex = 49;
            this.label2.Text = "IMPRIMIR TODOS LOS RECIBOS:";
            // 
            // BtnImprimeTodo
            // 
            this.BtnImprimeTodo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnImprimeTodo.BackColor = System.Drawing.Color.MediumAquamarine;
            this.BtnImprimeTodo.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.BtnImprimeTodo.IconColor = System.Drawing.Color.White;
            this.BtnImprimeTodo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnImprimeTodo.IconSize = 30;
            this.BtnImprimeTodo.Location = new System.Drawing.Point(870, 736);
            this.BtnImprimeTodo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnImprimeTodo.Name = "BtnImprimeTodo";
            this.BtnImprimeTodo.Size = new System.Drawing.Size(120, 44);
            this.BtnImprimeTodo.TabIndex = 48;
            this.BtnImprimeTodo.UseVisualStyleBackColor = false;
            // 
            // lblSemanaLabel
            // 
            this.lblSemanaLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSemanaLabel.AutoSize = true;
            this.lblSemanaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSemanaLabel.Location = new System.Drawing.Point(732, 9);
            this.lblSemanaLabel.Name = "lblSemanaLabel";
            this.lblSemanaLabel.Size = new System.Drawing.Size(20, 29);
            this.lblSemanaLabel.TabIndex = 50;
            this.lblSemanaLabel.Text = ".";
            // 
            // Semana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1501, 791);
            this.Controls.Add(this.lblSemanaLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnImprimeTodo);
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
        private FontAwesome.Sharp.IconButton BtnImprimeTodo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSemanaLabel;
    }
}