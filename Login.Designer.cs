namespace ProcesadorNominaas
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.lbl_login = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_login2 = new System.Windows.Forms.Label();
            this.icon_user = new System.Windows.Forms.PictureBox();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.icon_password = new System.Windows.Forms.PictureBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.lbl_salir = new System.Windows.Forms.Label();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.txt_password = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.icon_user)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icon_password)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_login
            // 
            this.lbl_login.AutoSize = true;
            this.lbl_login.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_login.ForeColor = System.Drawing.Color.IndianRed;
            this.lbl_login.Location = new System.Drawing.Point(79, 164);
            this.lbl_login.Name = "lbl_login";
            this.lbl_login.Size = new System.Drawing.Size(95, 44);
            this.lbl_login.TabIndex = 1;
            this.lbl_login.Text = "LOG";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Crimson;
            this.panel1.Location = new System.Drawing.Point(31, 263);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(236, 1);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Crimson;
            this.panel2.Location = new System.Drawing.Point(31, 315);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(236, 1);
            this.panel2.TabIndex = 5;
            // 
            // lbl_login2
            // 
            this.lbl_login2.AutoSize = true;
            this.lbl_login2.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_login2.ForeColor = System.Drawing.Color.DarkRed;
            this.lbl_login2.Location = new System.Drawing.Point(167, 164);
            this.lbl_login2.Name = "lbl_login2";
            this.lbl_login2.Size = new System.Drawing.Size(62, 44);
            this.lbl_login2.TabIndex = 6;
            this.lbl_login2.Text = "IN";
            // 
            // icon_user
            // 
            this.icon_user.Image = ((System.Drawing.Image)(resources.GetObject("icon_user.Image")));
            this.icon_user.Location = new System.Drawing.Point(31, 221);
            this.icon_user.Name = "icon_user";
            this.icon_user.Size = new System.Drawing.Size(41, 43);
            this.icon_user.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.icon_user.TabIndex = 2;
            this.icon_user.TabStop = false;
            // 
            // Logo
            // 
            this.Logo.Image = ((System.Drawing.Image)(resources.GetObject("Logo.Image")));
            this.Logo.Location = new System.Drawing.Point(31, 21);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(236, 140);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Logo.TabIndex = 0;
            this.Logo.TabStop = false;
            // 
            // icon_password
            // 
            this.icon_password.Image = ((System.Drawing.Image)(resources.GetObject("icon_password.Image")));
            this.icon_password.Location = new System.Drawing.Point(31, 279);
            this.icon_password.Name = "icon_password";
            this.icon_password.Size = new System.Drawing.Size(38, 34);
            this.icon_password.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.icon_password.TabIndex = 7;
            this.icon_password.TabStop = false;
            // 
            // btn_login
            // 
            this.btn_login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(137)))), ((int)(((byte)(146)))));
            this.btn_login.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btn_login.FlatAppearance.BorderSize = 2;
            this.btn_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_login.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_login.ForeColor = System.Drawing.Color.DarkRed;
            this.btn_login.Location = new System.Drawing.Point(31, 357);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(236, 34);
            this.btn_login.TabIndex = 8;
            this.btn_login.Text = "LOG IN";
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // lbl_salir
            // 
            this.lbl_salir.AutoSize = true;
            this.lbl_salir.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_salir.ForeColor = System.Drawing.Color.DarkRed;
            this.lbl_salir.Location = new System.Drawing.Point(118, 404);
            this.lbl_salir.Name = "lbl_salir";
            this.lbl_salir.Size = new System.Drawing.Size(56, 23);
            this.lbl_salir.TabIndex = 9;
            this.lbl_salir.Text = "Salir";
            this.lbl_salir.Click += new System.EventHandler(this.label2_Click);
            // 
            // txt_username
            // 
            this.txt_username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_username.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_username.Location = new System.Drawing.Point(78, 233);
            this.txt_username.MaxLength = 50;
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(189, 22);
            this.txt_username.TabIndex = 10;
            // 
            // txt_password
            // 
            this.txt_password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_password.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_password.Location = new System.Drawing.Point(78, 285);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(189, 22);
            this.txt_password.TabIndex = 11;
            this.txt_password.UseSystemPasswordChar = true;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(292, 447);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.txt_username);
            this.Controls.Add(this.lbl_salir);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.icon_password);
            this.Controls.Add(this.lbl_login2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.icon_user);
            this.Controls.Add(this.lbl_login);
            this.Controls.Add(this.Logo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.icon_user)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icon_password)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Label lbl_login;
        private System.Windows.Forms.PictureBox icon_user;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_login2;
        private System.Windows.Forms.PictureBox icon_password;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Label lbl_salir;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.TextBox txt_password;
    }
}