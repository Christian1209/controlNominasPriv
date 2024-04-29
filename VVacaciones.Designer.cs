namespace ProcesadorNominaas
{
    partial class VVacaciones
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
            this.BtnHistorialVacaciones = new FontAwesome.Sharp.IconButton();
            this.btn_solicitar = new FontAwesome.Sharp.IconButton();
            this.txtBox_BusquedaPorNombre = new System.Windows.Forms.TextBox();
            this.lblBusquedaNombre = new System.Windows.Forms.Label();
            this.btnBusquedaNombre = new FontAwesome.Sharp.IconButton();
            this.dataGrid_Vacaciones = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dias_restantes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dias_tomados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Vacaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnHistorialVacaciones
            // 
            this.BtnHistorialVacaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(213)))), ((int)(((byte)(236)))));
            this.BtnHistorialVacaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnHistorialVacaciones.IconChar = FontAwesome.Sharp.IconChar.File;
            this.BtnHistorialVacaciones.IconColor = System.Drawing.Color.White;
            this.BtnHistorialVacaciones.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnHistorialVacaciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnHistorialVacaciones.Location = new System.Drawing.Point(122, 50);
            this.BtnHistorialVacaciones.Margin = new System.Windows.Forms.Padding(2);
            this.BtnHistorialVacaciones.Name = "BtnHistorialVacaciones";
            this.BtnHistorialVacaciones.Size = new System.Drawing.Size(193, 44);
            this.BtnHistorialVacaciones.TabIndex = 5;
            this.BtnHistorialVacaciones.Text = "Historial";
            this.BtnHistorialVacaciones.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnHistorialVacaciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnHistorialVacaciones.UseVisualStyleBackColor = false;
            // 
            // btn_solicitar
            // 
            this.btn_solicitar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(213)))), ((int)(((byte)(236)))));
            this.btn_solicitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_solicitar.IconChar = FontAwesome.Sharp.IconChar.File;
            this.btn_solicitar.IconColor = System.Drawing.Color.White;
            this.btn_solicitar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_solicitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_solicitar.Location = new System.Drawing.Point(536, 50);
            this.btn_solicitar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_solicitar.Name = "btn_solicitar";
            this.btn_solicitar.Size = new System.Drawing.Size(193, 44);
            this.btn_solicitar.TabIndex = 6;
            this.btn_solicitar.Text = "Solicitar";
            this.btn_solicitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_solicitar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_solicitar.UseVisualStyleBackColor = false;
            this.btn_solicitar.Click += new System.EventHandler(this.btn_solicitar_Click);
            // 
            // txtBox_BusquedaPorNombre
            // 
            this.txtBox_BusquedaPorNombre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtBox_BusquedaPorNombre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtBox_BusquedaPorNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_BusquedaPorNombre.Location = new System.Drawing.Point(193, 141);
            this.txtBox_BusquedaPorNombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtBox_BusquedaPorNombre.Name = "txtBox_BusquedaPorNombre";
            this.txtBox_BusquedaPorNombre.Size = new System.Drawing.Size(426, 26);
            this.txtBox_BusquedaPorNombre.TabIndex = 165;
            this.txtBox_BusquedaPorNombre.Visible = false;
            // 
            // lblBusquedaNombre
            // 
            this.lblBusquedaNombre.AutoSize = true;
            this.lblBusquedaNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusquedaNombre.Location = new System.Drawing.Point(297, 109);
            this.lblBusquedaNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBusquedaNombre.Name = "lblBusquedaNombre";
            this.lblBusquedaNombre.Size = new System.Drawing.Size(245, 20);
            this.lblBusquedaNombre.TabIndex = 164;
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
            this.btnBusquedaNombre.Location = new System.Drawing.Point(377, 171);
            this.btnBusquedaNombre.Margin = new System.Windows.Forms.Padding(2);
            this.btnBusquedaNombre.Name = "btnBusquedaNombre";
            this.btnBusquedaNombre.Size = new System.Drawing.Size(53, 37);
            this.btnBusquedaNombre.TabIndex = 163;
            this.btnBusquedaNombre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBusquedaNombre.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBusquedaNombre.UseVisualStyleBackColor = false;
            this.btnBusquedaNombre.Visible = false;
            this.btnBusquedaNombre.Click += new System.EventHandler(this.btnBusquedaNombre_Click);
            // 
            // dataGrid_Vacaciones
            // 
            this.dataGrid_Vacaciones.AllowUserToAddRows = false;
            this.dataGrid_Vacaciones.AllowUserToDeleteRows = false;
            this.dataGrid_Vacaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_Vacaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nombre,
            this.dias_restantes,
            this.dias_tomados});
            this.dataGrid_Vacaciones.Location = new System.Drawing.Point(193, 213);
            this.dataGrid_Vacaciones.Name = "dataGrid_Vacaciones";
            this.dataGrid_Vacaciones.ReadOnly = true;
            this.dataGrid_Vacaciones.Size = new System.Drawing.Size(426, 341);
            this.dataGrid_Vacaciones.TabIndex = 166;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // nombre
            // 
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dias_restantes
            // 
            this.dias_restantes.HeaderText = "Dias Restantes";
            this.dias_restantes.Name = "dias_restantes";
            this.dias_restantes.ReadOnly = true;
            this.dias_restantes.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dias_tomados
            // 
            this.dias_tomados.HeaderText = "Dias Tomados";
            this.dias_tomados.Name = "dias_tomados";
            this.dias_tomados.ReadOnly = true;
            this.dias_tomados.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // VVacaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(800, 609);
            this.Controls.Add(this.dataGrid_Vacaciones);
            this.Controls.Add(this.txtBox_BusquedaPorNombre);
            this.Controls.Add(this.lblBusquedaNombre);
            this.Controls.Add(this.btnBusquedaNombre);
            this.Controls.Add(this.btn_solicitar);
            this.Controls.Add(this.BtnHistorialVacaciones);
            this.Name = "VVacaciones";
            this.Text = "VVacaciones";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Vacaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton BtnHistorialVacaciones;
        private FontAwesome.Sharp.IconButton btn_solicitar;
        private System.Windows.Forms.TextBox txtBox_BusquedaPorNombre;
        private System.Windows.Forms.Label lblBusquedaNombre;
        private FontAwesome.Sharp.IconButton btnBusquedaNombre;
        private System.Windows.Forms.DataGridView dataGrid_Vacaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn dias_restantes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dias_tomados;
    }
}