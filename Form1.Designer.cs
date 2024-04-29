namespace ProcesadorNominaas
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.PanelLogo = new System.Windows.Forms.Panel();
            this.pic_logo = new System.Windows.Forms.PictureBox();
            this.PanelSideMenu = new System.Windows.Forms.Panel();
            this.lblCarniceria = new System.Windows.Forms.Label();
            this.SubPanelNormandia = new System.Windows.Forms.Panel();
            this.BtnPyCNormandia = new System.Windows.Forms.Button();
            this.BtnConfigNormandia = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.BtnAguinaldosNormandia = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.BtnNomina = new System.Windows.Forms.Button();
            this.BtnNormandiaEmpleados = new System.Windows.Forms.Button();
            this.BtnProcesadorNormandia = new System.Windows.Forms.Button();
            this.PanelChildForm = new System.Windows.Forms.Panel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.PanelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_logo)).BeginInit();
            this.PanelSideMenu.SuspendLayout();
            this.SubPanelNormandia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // PanelLogo
            // 
            this.PanelLogo.Controls.Add(this.pic_logo);
            this.PanelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PanelLogo.Location = new System.Drawing.Point(0, 0);
            this.PanelLogo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelLogo.Name = "PanelLogo";
            this.PanelLogo.Size = new System.Drawing.Size(205, 73);
            this.PanelLogo.TabIndex = 0;
            // 
            // pic_logo
            // 
            this.pic_logo.Location = new System.Drawing.Point(4, 4);
            this.pic_logo.Margin = new System.Windows.Forms.Padding(4);
            this.pic_logo.Name = "pic_logo";
            this.pic_logo.Size = new System.Drawing.Size(197, 65);
            this.pic_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_logo.TabIndex = 0;
            this.pic_logo.TabStop = false;
            // 
            // PanelSideMenu
            // 
            this.PanelSideMenu.AllowDrop = true;
            this.PanelSideMenu.AutoScroll = true;
            this.PanelSideMenu.BackColor = System.Drawing.Color.White;
            this.PanelSideMenu.Controls.Add(this.lblCarniceria);
            this.PanelSideMenu.Controls.Add(this.SubPanelNormandia);
            this.PanelSideMenu.Controls.Add(this.PanelLogo);
            this.PanelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.PanelSideMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelSideMenu.Name = "PanelSideMenu";
            this.PanelSideMenu.Size = new System.Drawing.Size(205, 933);
            this.PanelSideMenu.TabIndex = 0;
            // 
            // lblCarniceria
            // 
            this.lblCarniceria.AutoSize = true;
            this.lblCarniceria.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarniceria.Location = new System.Drawing.Point(4, 84);
            this.lblCarniceria.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCarniceria.Name = "lblCarniceria";
            this.lblCarniceria.Size = new System.Drawing.Size(184, 31);
            this.lblCarniceria.TabIndex = 4;
            this.lblCarniceria.Text = "CARNICERIA";
            // 
            // SubPanelNormandia
            // 
            this.SubPanelNormandia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.SubPanelNormandia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.SubPanelNormandia.Controls.Add(this.BtnPyCNormandia);
            this.SubPanelNormandia.Controls.Add(this.BtnConfigNormandia);
            this.SubPanelNormandia.Controls.Add(this.button16);
            this.SubPanelNormandia.Controls.Add(this.BtnAguinaldosNormandia);
            this.SubPanelNormandia.Controls.Add(this.button13);
            this.SubPanelNormandia.Controls.Add(this.button14);
            this.SubPanelNormandia.Controls.Add(this.button12);
            this.SubPanelNormandia.Controls.Add(this.button11);
            this.SubPanelNormandia.Controls.Add(this.BtnNomina);
            this.SubPanelNormandia.Controls.Add(this.BtnNormandiaEmpleados);
            this.SubPanelNormandia.Controls.Add(this.BtnProcesadorNormandia);
            this.SubPanelNormandia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubPanelNormandia.Location = new System.Drawing.Point(0, 123);
            this.SubPanelNormandia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SubPanelNormandia.Name = "SubPanelNormandia";
            this.SubPanelNormandia.Size = new System.Drawing.Size(205, 831);
            this.SubPanelNormandia.TabIndex = 3;
            // 
            // BtnPyCNormandia
            // 
            this.BtnPyCNormandia.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnPyCNormandia.FlatAppearance.BorderSize = 0;
            this.BtnPyCNormandia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(134)))), ((int)(((byte)(180)))));
            this.BtnPyCNormandia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(203)))), ((int)(((byte)(227)))));
            this.BtnPyCNormandia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPyCNormandia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPyCNormandia.Location = new System.Drawing.Point(0, 499);
            this.BtnPyCNormandia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnPyCNormandia.Name = "BtnPyCNormandia";
            this.BtnPyCNormandia.Padding = new System.Windows.Forms.Padding(27, 0, 0, 0);
            this.BtnPyCNormandia.Size = new System.Drawing.Size(205, 60);
            this.BtnPyCNormandia.TabIndex = 16;
            this.BtnPyCNormandia.Text = " Prestaciones y      Contratos";
            this.BtnPyCNormandia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnPyCNormandia.UseVisualStyleBackColor = true;
            this.BtnPyCNormandia.Click += new System.EventHandler(this.BtnPyCNormandia_Click);
            // 
            // BtnConfigNormandia
            // 
            this.BtnConfigNormandia.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnConfigNormandia.FlatAppearance.BorderSize = 0;
            this.BtnConfigNormandia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(134)))), ((int)(((byte)(180)))));
            this.BtnConfigNormandia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(203)))), ((int)(((byte)(227)))));
            this.BtnConfigNormandia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnConfigNormandia.Location = new System.Drawing.Point(0, 449);
            this.BtnConfigNormandia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnConfigNormandia.Name = "BtnConfigNormandia";
            this.BtnConfigNormandia.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.BtnConfigNormandia.Size = new System.Drawing.Size(205, 50);
            this.BtnConfigNormandia.TabIndex = 15;
            this.BtnConfigNormandia.Text = "Configuración";
            this.BtnConfigNormandia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnConfigNormandia.UseVisualStyleBackColor = true;
            // 
            // button16
            // 
            this.button16.Dock = System.Windows.Forms.DockStyle.Top;
            this.button16.FlatAppearance.BorderSize = 0;
            this.button16.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(134)))), ((int)(((byte)(180)))));
            this.button16.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(203)))), ((int)(((byte)(227)))));
            this.button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button16.Location = new System.Drawing.Point(0, 399);
            this.button16.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button16.Name = "button16";
            this.button16.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.button16.Size = new System.Drawing.Size(205, 50);
            this.button16.TabIndex = 13;
            this.button16.Text = "Historico Semanas";
            this.button16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button16.UseVisualStyleBackColor = true;
            // 
            // BtnAguinaldosNormandia
            // 
            this.BtnAguinaldosNormandia.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnAguinaldosNormandia.FlatAppearance.BorderSize = 0;
            this.BtnAguinaldosNormandia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(134)))), ((int)(((byte)(180)))));
            this.BtnAguinaldosNormandia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(203)))), ((int)(((byte)(227)))));
            this.BtnAguinaldosNormandia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAguinaldosNormandia.Location = new System.Drawing.Point(0, 345);
            this.BtnAguinaldosNormandia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnAguinaldosNormandia.Name = "BtnAguinaldosNormandia";
            this.BtnAguinaldosNormandia.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.BtnAguinaldosNormandia.Size = new System.Drawing.Size(205, 54);
            this.BtnAguinaldosNormandia.TabIndex = 12;
            this.BtnAguinaldosNormandia.Text = "Aguinaldos";
            this.BtnAguinaldosNormandia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAguinaldosNormandia.UseVisualStyleBackColor = true;
            this.BtnAguinaldosNormandia.Click += new System.EventHandler(this.BtnAguinaldosNormandia_Click);
            // 
            // button13
            // 
            this.button13.Dock = System.Windows.Forms.DockStyle.Top;
            this.button13.FlatAppearance.BorderSize = 0;
            this.button13.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(134)))), ((int)(((byte)(180)))));
            this.button13.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(203)))), ((int)(((byte)(227)))));
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.Location = new System.Drawing.Point(0, 301);
            this.button13.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button13.Name = "button13";
            this.button13.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.button13.Size = new System.Drawing.Size(205, 44);
            this.button13.TabIndex = 11;
            this.button13.Text = "Vacaciones";
            this.button13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button13.UseVisualStyleBackColor = true;
            // 
            // button14
            // 
            this.button14.Dock = System.Windows.Forms.DockStyle.Top;
            this.button14.FlatAppearance.BorderSize = 0;
            this.button14.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(134)))), ((int)(((byte)(180)))));
            this.button14.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(203)))), ((int)(((byte)(227)))));
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button14.Location = new System.Drawing.Point(0, 248);
            this.button14.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button14.Name = "button14";
            this.button14.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.button14.Size = new System.Drawing.Size(205, 53);
            this.button14.TabIndex = 10;
            this.button14.Text = "Cuenta";
            this.button14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button14.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.Dock = System.Windows.Forms.DockStyle.Top;
            this.button12.FlatAppearance.BorderSize = 0;
            this.button12.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(134)))), ((int)(((byte)(180)))));
            this.button12.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(203)))), ((int)(((byte)(227)))));
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Location = new System.Drawing.Point(0, 193);
            this.button12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button12.Name = "button12";
            this.button12.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.button12.Size = new System.Drawing.Size(205, 55);
            this.button12.TabIndex = 8;
            this.button12.Text = "Renuncia";
            this.button12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button12.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Dock = System.Windows.Forms.DockStyle.Top;
            this.button11.FlatAppearance.BorderSize = 0;
            this.button11.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(134)))), ((int)(((byte)(180)))));
            this.button11.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(203)))), ((int)(((byte)(227)))));
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Location = new System.Drawing.Point(0, 147);
            this.button11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button11.Name = "button11";
            this.button11.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.button11.Size = new System.Drawing.Size(205, 46);
            this.button11.TabIndex = 7;
            this.button11.Text = "Recibos";
            this.button11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button11.UseVisualStyleBackColor = true;
            // 
            // BtnNomina
            // 
            this.BtnNomina.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnNomina.FlatAppearance.BorderSize = 0;
            this.BtnNomina.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(134)))), ((int)(((byte)(180)))));
            this.BtnNomina.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(203)))), ((int)(((byte)(227)))));
            this.BtnNomina.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNomina.Location = new System.Drawing.Point(0, 103);
            this.BtnNomina.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnNomina.Name = "BtnNomina";
            this.BtnNomina.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.BtnNomina.Size = new System.Drawing.Size(205, 44);
            this.BtnNomina.TabIndex = 6;
            this.BtnNomina.Text = "Nomina";
            this.BtnNomina.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnNomina.UseVisualStyleBackColor = true;
            this.BtnNomina.Click += new System.EventHandler(this.BtnNomina_Click);
            // 
            // BtnNormandiaEmpleados
            // 
            this.BtnNormandiaEmpleados.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnNormandiaEmpleados.FlatAppearance.BorderSize = 0;
            this.BtnNormandiaEmpleados.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(134)))), ((int)(((byte)(180)))));
            this.BtnNormandiaEmpleados.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(203)))), ((int)(((byte)(227)))));
            this.BtnNormandiaEmpleados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNormandiaEmpleados.Location = new System.Drawing.Point(0, 53);
            this.BtnNormandiaEmpleados.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnNormandiaEmpleados.Name = "BtnNormandiaEmpleados";
            this.BtnNormandiaEmpleados.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.BtnNormandiaEmpleados.Size = new System.Drawing.Size(205, 50);
            this.BtnNormandiaEmpleados.TabIndex = 3;
            this.BtnNormandiaEmpleados.Text = "Empleados";
            this.BtnNormandiaEmpleados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnNormandiaEmpleados.UseVisualStyleBackColor = true;
            this.BtnNormandiaEmpleados.Click += new System.EventHandler(this.BtnNormandiaEmpleados_Click);
            // 
            // BtnProcesadorNormandia
            // 
            this.BtnProcesadorNormandia.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnProcesadorNormandia.FlatAppearance.BorderSize = 0;
            this.BtnProcesadorNormandia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(134)))), ((int)(((byte)(180)))));
            this.BtnProcesadorNormandia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(203)))), ((int)(((byte)(227)))));
            this.BtnProcesadorNormandia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnProcesadorNormandia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnProcesadorNormandia.Location = new System.Drawing.Point(0, 0);
            this.BtnProcesadorNormandia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnProcesadorNormandia.Name = "BtnProcesadorNormandia";
            this.BtnProcesadorNormandia.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.BtnProcesadorNormandia.Size = new System.Drawing.Size(205, 53);
            this.BtnProcesadorNormandia.TabIndex = 2;
            this.BtnProcesadorNormandia.Text = "Procesar";
            this.BtnProcesadorNormandia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnProcesadorNormandia.UseVisualStyleBackColor = true;
            this.BtnProcesadorNormandia.Click += new System.EventHandler(this.BtnProcesadorNormandia_Click);
            // 
            // PanelChildForm
            // 
            this.PanelChildForm.BackColor = System.Drawing.Color.White;
            this.PanelChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelChildForm.Location = new System.Drawing.Point(205, 0);
            this.PanelChildForm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelChildForm.MinimumSize = new System.Drawing.Size(887, 735);
            this.PanelChildForm.Name = "PanelChildForm";
            this.PanelChildForm.Size = new System.Drawing.Size(1326, 933);
            this.PanelChildForm.TabIndex = 1;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1531, 933);
            this.Controls.Add(this.PanelChildForm);
            this.Controls.Add(this.PanelSideMenu);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1142, 779);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.PanelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_logo)).EndInit();
            this.PanelSideMenu.ResumeLayout(false);
            this.PanelSideMenu.PerformLayout();
            this.SubPanelNormandia.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Panel PanelSideMenu;
        private System.Windows.Forms.Panel PanelLogo;
        private System.Windows.Forms.Panel PanelChildForm;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel SubPanelNormandia;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button BtnAguinaldosNormandia;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button BtnNomina;
        private System.Windows.Forms.Button BtnNormandiaEmpleados;
        private System.Windows.Forms.Button BtnProcesadorNormandia;
        private System.Windows.Forms.Button BtnConfigNormandia;
        private System.Windows.Forms.Button BtnPyCNormandia;
        private System.Windows.Forms.Label lblCarniceria;
        private System.Windows.Forms.PictureBox pic_logo;
    }
}

