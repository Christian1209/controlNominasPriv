namespace ProcesadorNominaas
{
    partial class VentanaEmpleado
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
            this.BtnAltaEmpleado = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBaja = new FontAwesome.Sharp.IconButton();
            this.btnActualzar = new FontAwesome.Sharp.IconButton();
            this.btnVerEmpleado = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // BtnAltaEmpleado
            // 
            this.BtnAltaEmpleado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(213)))), ((int)(((byte)(236)))));
            this.BtnAltaEmpleado.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.BtnAltaEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAltaEmpleado.IconChar = FontAwesome.Sharp.IconChar.File;
            this.BtnAltaEmpleado.IconColor = System.Drawing.Color.White;
            this.BtnAltaEmpleado.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnAltaEmpleado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAltaEmpleado.Location = new System.Drawing.Point(13, 53);
            this.BtnAltaEmpleado.Margin = new System.Windows.Forms.Padding(2);
            this.BtnAltaEmpleado.Name = "BtnAltaEmpleado";
            this.BtnAltaEmpleado.Size = new System.Drawing.Size(270, 44);
            this.BtnAltaEmpleado.TabIndex = 2;
            this.BtnAltaEmpleado.Text = "Alta de empleados";
            this.BtnAltaEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAltaEmpleado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnAltaEmpleado.UseVisualStyleBackColor = false;
            this.BtnAltaEmpleado.Click += new System.EventHandler(this.BtnUbicacionCarga_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Control de empleados";
            // 
            // btnBaja
            // 
            this.btnBaja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(213)))), ((int)(((byte)(236)))));
            this.btnBaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaja.IconChar = FontAwesome.Sharp.IconChar.File;
            this.btnBaja.IconColor = System.Drawing.Color.White;
            this.btnBaja.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBaja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaja.Location = new System.Drawing.Point(13, 114);
            this.btnBaja.Margin = new System.Windows.Forms.Padding(2);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(270, 44);
            this.btnBaja.TabIndex = 42;
            this.btnBaja.Text = "Baja de empleado";
            this.btnBaja.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBaja.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBaja.UseVisualStyleBackColor = false;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // btnActualzar
            // 
            this.btnActualzar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(213)))), ((int)(((byte)(236)))));
            this.btnActualzar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualzar.IconChar = FontAwesome.Sharp.IconChar.File;
            this.btnActualzar.IconColor = System.Drawing.Color.White;
            this.btnActualzar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnActualzar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualzar.Location = new System.Drawing.Point(13, 173);
            this.btnActualzar.Margin = new System.Windows.Forms.Padding(2);
            this.btnActualzar.Name = "btnActualzar";
            this.btnActualzar.Size = new System.Drawing.Size(270, 44);
            this.btnActualzar.TabIndex = 43;
            this.btnActualzar.Text = "Actualizar empleado";
            this.btnActualzar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualzar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualzar.UseVisualStyleBackColor = false;
            this.btnActualzar.Click += new System.EventHandler(this.btnActualzar_Click);
            // 
            // btnVerEmpleado
            // 
            this.btnVerEmpleado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(213)))), ((int)(((byte)(236)))));
            this.btnVerEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerEmpleado.IconChar = FontAwesome.Sharp.IconChar.File;
            this.btnVerEmpleado.IconColor = System.Drawing.Color.White;
            this.btnVerEmpleado.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVerEmpleado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerEmpleado.Location = new System.Drawing.Point(13, 229);
            this.btnVerEmpleado.Margin = new System.Windows.Forms.Padding(2);
            this.btnVerEmpleado.Name = "btnVerEmpleado";
            this.btnVerEmpleado.Size = new System.Drawing.Size(270, 44);
            this.btnVerEmpleado.TabIndex = 44;
            this.btnVerEmpleado.Text = "Ver Empleado";
            this.btnVerEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVerEmpleado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVerEmpleado.UseVisualStyleBackColor = false;
            this.btnVerEmpleado.Click += new System.EventHandler(this.btnVerEmpleado_Click);
            // 
            // VentanaEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(902, 698);
            this.Controls.Add(this.btnVerEmpleado);
            this.Controls.Add(this.btnActualzar);
            this.Controls.Add(this.btnBaja);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnAltaEmpleado);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(669, 605);
            this.Name = "VentanaEmpleado";
            this.Text = "Carga";
            this.Load += new System.EventHandler(this.VentanaEmpleado_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private FontAwesome.Sharp.IconButton BtnAltaEmpleado;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btnBaja;
        private FontAwesome.Sharp.IconButton btnActualzar;
        private FontAwesome.Sharp.IconButton btnVerEmpleado;
    }
}