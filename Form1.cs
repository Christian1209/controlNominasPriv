using Microsoft.Office.Interop.Excel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;

namespace ProcesadorNominaas
{
    public partial class Form1 : Form
    {
        public string carniceria { get; set; }

        public Form1(string carniceria_param)
        {
            carniceria = carniceria_param;
            string rutaLogo = "./src/" + carniceria_param + ".png";
            Console.WriteLine(rutaLogo);
            InitializeComponent();
            lblCarniceria.Text = carniceria.ToUpper();
            pic_logo.Image = new System.Drawing.Bitmap(rutaLogo);
            showSubMenu(SubPanelNormandia);
            this.FormClosing += Form1_FormClosing;
        }
        
        

        //variable temporal para

        //metodos referentes a interfaz..
        public void hideSubMenu()
        {
            //SubPanelNormandia.Visible = false;
            //SubPanelDelCampo.Visible = false;
            //SubPanelOrigenBA.Visible = false;
            //SubPanelOrigenValdepeñas.Visible = false;   
            //SubPanelOrigenRN.Visible = false;
            //SubPanelPlanta.Visible = false;
            //SubPanelTonala.Visible = false; 
        }

        public void showSubMenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hideSubMenu();
                submenu.Visible = true;
            }
            else
            {
                submenu.Visible = false;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //hideSubMenu();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("¿Estas seguro que deseas cerrar la aplicacion?", "Alerta", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    System.Windows.Forms.Application.ExitThread();
                    //Environment.Exit(0);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void BtnOrigenRN_Click(object sender, EventArgs e)
        {
           //showSubMenu(SubPanelOrigenRN);
        }

        private void BtnOrigenBA_Click(object sender, EventArgs e)
        {
            //showSubMenu(SubPanelOrigenBA);
        }

        private void BtnOrigenValdepeñas_Click(object sender, EventArgs e)
        {
            //showSubMenu(SubPanelOrigenValdepeñas);
        }

        private void BtnTonala_Click(object sender, EventArgs e)
        {
            //showSubMenu(SubPanelTonala);
        }

        private void BtnDelCampo_Click(object sender, EventArgs e)
        {
            //showSubMenu(SubPanelDelCampo);
        }

        private void BtnPlanta_Click(object sender, EventArgs e)
        {
            //showSubMenu(SubPanelPlanta);
        }

        private Form activeForm = null;
        public void openChildForm(Form childForm)
        {
            if(activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            PanelChildForm.Controls.Add(childForm);
            PanelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void BtnProcesadorNormandia_Click(object sender, EventArgs e)
        {
            LimpiaBotones();
            BtnProcesadorNormandia.BackColor = Color.FromArgb(141, 201, 225);
            openChildForm(new Procesador(carniceria));
        }

        private void BtnConfigNormandia_Click(object sender, EventArgs e)
        {
            LimpiaBotones();
            BtnConfigNormandia.BackColor = Color.FromArgb(141, 201, 225);
            openChildForm(new Configuracion());
        }

        /*private void BtnCargaNormandia_Click(object sender, EventArgs e)
        {
            LimpiaBotones();
            BtnCargaNormandia.BackColor = Color.FromArgb(141, 201, 225);
            openChildForm(new VentanaEmpleado(sucursalSelected));
        }*/



        //metodo de ayuda para controlar botones activos de interfaz.
        public void LimpiaBotones()
        {
            //BtnCargaNormandia.BackColor = Color.FromArgb(233, 239, 246);
            //BtnConfigNormandia.BackColor = Color.FromArgb(233, 239, 246);
            BtnProcesadorNormandia.BackColor = Color.FromArgb(233, 239, 246);
            //BtnAguinaldosNormandia.BackColor = Color.FromArgb(233, 239, 246);
            //BtnNomina.BackColor = Color.FromArgb(233, 239, 246);
            BtnNormandiaEmpleados.BackColor = Color.FromArgb(233, 239, 246);
            BtnProcesadorNormandia.BackColor = Color.FromArgb(233, 239, 246);
            BtnPyCNormandia.BackColor = Color.FromArgb(233, 239, 246);
        }


        private void BtnNormandiaEmpleados_Click(object sender, EventArgs e)
        {

            LimpiaBotones();
            BtnNormandiaEmpleados.BackColor = Color.FromArgb(141, 201, 225);
            openChildForm(new VentanaEmpleado(carniceria));
        }


        private void BtnAguinaldosNormandia_Click(object sender, EventArgs e)
        {
            LimpiaBotones();
            BtnAguinaldosNormandia.BackColor = Color.FromArgb(141, 201, 225);
        }

        private void BtnNomina_Click(object sender, EventArgs e)
        {
            LimpiaBotones();
            BtnNomina.BackColor = Color.FromArgb(141, 201, 225);
            openChildForm(new ContenedorNomina(carniceria));
        }
        private void BtnPyCNormandia_Click(object sender, EventArgs e)
        {
            LimpiaBotones();
            BtnPyCNormandia.BackColor = Color.FromArgb(141, 201, 225);
            openChildForm(new VPrestacionesContratos(carniceria));
        }







        //fin de metodos para interfaz

    }
}
