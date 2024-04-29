namespace ProcesadorNominaas
{
    partial class VentanaAguinaldos
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
            this.btnEmpleado = new System.Windows.Forms.Button();
            this.btnEmpleados = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxBusquedaPorNombre = new System.Windows.Forms.TextBox();
            this.lblBusquedaNombre = new System.Windows.Forms.Label();
            this.btnBusquedaNombre = new FontAwesome.Sharp.IconButton();
            this.TablaAguinaldos = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sueldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.f_ingreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.f_actual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diastra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aguinaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.TablaAguinaldos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEmpleado
            // 
            this.btnEmpleado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(213)))), ((int)(((byte)(236)))));
            this.btnEmpleado.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
            this.btnEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.btnEmpleado.ForeColor = System.Drawing.Color.Black;
            this.btnEmpleado.Location = new System.Drawing.Point(118, 81);
            this.btnEmpleado.Name = "btnEmpleado";
            this.btnEmpleado.Size = new System.Drawing.Size(159, 39);
            this.btnEmpleado.TabIndex = 0;
            this.btnEmpleado.Text = "Empleado";
            this.btnEmpleado.UseVisualStyleBackColor = false;
            this.btnEmpleado.Click += new System.EventHandler(this.btnEmpleado_Click);
            // 
            // btnEmpleados
            // 
            this.btnEmpleados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(213)))), ((int)(((byte)(236)))));
            this.btnEmpleados.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
            this.btnEmpleados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmpleados.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.btnEmpleados.ForeColor = System.Drawing.Color.Black;
            this.btnEmpleados.Location = new System.Drawing.Point(702, 81);
            this.btnEmpleados.Name = "btnEmpleados";
            this.btnEmpleados.Size = new System.Drawing.Size(159, 39);
            this.btnEmpleados.TabIndex = 1;
            this.btnEmpleados.Text = "Empleados";
            this.btnEmpleados.UseVisualStyleBackColor = false;
            this.btnEmpleados.Click += new System.EventHandler(this.btnEmpleados_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(444, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Aguinaldos";
            // 
            // textBoxBusquedaPorNombre
            // 
            this.textBoxBusquedaPorNombre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoxBusquedaPorNombre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxBusquedaPorNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBusquedaPorNombre.Location = new System.Drawing.Point(277, 179);
            this.textBoxBusquedaPorNombre.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxBusquedaPorNombre.Name = "textBoxBusquedaPorNombre";
            this.textBoxBusquedaPorNombre.Size = new System.Drawing.Size(426, 26);
            this.textBoxBusquedaPorNombre.TabIndex = 162;
            this.textBoxBusquedaPorNombre.Visible = false;
            // 
            // lblBusquedaNombre
            // 
            this.lblBusquedaNombre.AutoSize = true;
            this.lblBusquedaNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusquedaNombre.Location = new System.Drawing.Point(381, 147);
            this.lblBusquedaNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBusquedaNombre.Name = "lblBusquedaNombre";
            this.lblBusquedaNombre.Size = new System.Drawing.Size(245, 20);
            this.lblBusquedaNombre.TabIndex = 161;
            this.lblBusquedaNombre.Text = "Busqueda por Nombre Completo:";
            this.lblBusquedaNombre.Visible = false;
            // 
            // btnBusquedaNombre
            // 
            this.btnBusquedaNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(182)))), ((int)(((byte)(236)))));
            this.btnBusquedaNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBusquedaNombre.IconChar = FontAwesome.Sharp.IconChar.Searchengin;
            this.btnBusquedaNombre.IconColor = System.Drawing.Color.Black;
            this.btnBusquedaNombre.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBusquedaNombre.IconSize = 28;
            this.btnBusquedaNombre.Location = new System.Drawing.Point(461, 209);
            this.btnBusquedaNombre.Margin = new System.Windows.Forms.Padding(2);
            this.btnBusquedaNombre.Name = "btnBusquedaNombre";
            this.btnBusquedaNombre.Size = new System.Drawing.Size(53, 37);
            this.btnBusquedaNombre.TabIndex = 160;
            this.btnBusquedaNombre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBusquedaNombre.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBusquedaNombre.UseVisualStyleBackColor = false;
            this.btnBusquedaNombre.Visible = false;
            this.btnBusquedaNombre.Click += new System.EventHandler(this.btnBusquedaNombre_Click);
            // 
            // TablaAguinaldos
            // 
            this.TablaAguinaldos.AllowUserToAddRows = false;
            this.TablaAguinaldos.AllowUserToDeleteRows = false;
            this.TablaAguinaldos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaAguinaldos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nombre,
            this.sueldo,
            this.f_ingreso,
            this.f_actual,
            this.diastra,
            this.aguinaldo});
            this.TablaAguinaldos.Location = new System.Drawing.Point(118, 252);
            this.TablaAguinaldos.Name = "TablaAguinaldos";
            this.TablaAguinaldos.ReadOnly = true;
            this.TablaAguinaldos.Size = new System.Drawing.Size(743, 386);
            this.TablaAguinaldos.TabIndex = 163;
            this.TablaAguinaldos.Visible = false;
            this.TablaAguinaldos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TablaAguinaldos_CellContentClick);
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // nombre
            // 
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // sueldo
            // 
            this.sueldo.HeaderText = "Sueldo";
            this.sueldo.Name = "sueldo";
            this.sueldo.ReadOnly = true;
            // 
            // f_ingreso
            // 
            this.f_ingreso.HeaderText = "F_Ingreso";
            this.f_ingreso.Name = "f_ingreso";
            this.f_ingreso.ReadOnly = true;
            // 
            // f_actual
            // 
            this.f_actual.HeaderText = "F_Actual";
            this.f_actual.Name = "f_actual";
            this.f_actual.ReadOnly = true;
            // 
            // diastra
            // 
            this.diastra.HeaderText = "DiasTra";
            this.diastra.Name = "diastra";
            this.diastra.ReadOnly = true;
            // 
            // aguinaldo
            // 
            this.aguinaldo.HeaderText = "Aguinaldo";
            this.aguinaldo.Name = "aguinaldo";
            this.aguinaldo.ReadOnly = true;
            // 
            // VentanaAguinaldos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(991, 659);
            this.Controls.Add(this.TablaAguinaldos);
            this.Controls.Add(this.textBoxBusquedaPorNombre);
            this.Controls.Add(this.lblBusquedaNombre);
            this.Controls.Add(this.btnBusquedaNombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEmpleados);
            this.Controls.Add(this.btnEmpleado);
            this.Name = "VentanaAguinaldos";
            this.Text = "VentanaAguinaldos";
            this.Load += new System.EventHandler(this.VentanaAguinaldos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TablaAguinaldos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEmpleado;
        private System.Windows.Forms.Button btnEmpleados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxBusquedaPorNombre;
        private System.Windows.Forms.Label lblBusquedaNombre;
        private FontAwesome.Sharp.IconButton btnBusquedaNombre;
        private System.Windows.Forms.DataGridView TablaAguinaldos;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn sueldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn f_ingreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn f_actual;
        private System.Windows.Forms.DataGridViewTextBoxColumn diastra;
        private System.Windows.Forms.DataGridViewTextBoxColumn aguinaldo;
    }
}