using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProcesadorNominaas.Properties;


namespace ProcesadorNominaas
{
    public partial class VentanaEmpleado : Form
    {
        public string carniceria {  get; set; }
        public VentanaEmpleado(string carniceria_param)
        {
            InitializeComponent();
            carniceria= carniceria_param;
        }
       
        private void BtnUbicacionCarga_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (ValidarVentana(typeof(AltaEmpleado))) {
                return;
            }
            Form formulario = new AltaEmpleado(1, carniceria);
            formulario.Show();
            Cursor.Current = Cursors.WaitCursor;
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (ValidarVentana(typeof(AltaEmpleado)))
            {
                return;
            }
            Form formulario = new AltaEmpleado(2, carniceria);
            formulario.Show();
            Cursor.Current = Cursors.Default;
        }

        private void btnActualzar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (ValidarVentana(typeof(AltaEmpleado)))
            {
                return;
            }
            Form formulario = new AltaEmpleado(3, carniceria);
            formulario.Show();
            Cursor.Current = Cursors.Default;
        }

        private void btnVerEmpleado_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (ValidarVentana(typeof(AltaEmpleado)))
            {
                return;
            }
            Form formulario = new AltaEmpleado(4, carniceria);
            formulario.Show();
            Cursor.Current = Cursors.Default;
        }

        private void VentanaEmpleado_Load(object sender, EventArgs e)
        {

        }

        private bool ValidarVentana(Type ventana)
        {
            // Recorre los formularios abiertos para saber si esta abierto
            foreach (Form form in Application.OpenForms)
            {
                // Verifica si hay un formulario con el nombre
                if (form.GetType() == ventana && form.Visible)
                {
                    MessageBox.Show("Ya hay una ventana abierta\nCierrela si desea abrir una nueva");
                    return true;
                }
            }
            //Si no esta abierto seguimos
            return false;
        }
    }
}
