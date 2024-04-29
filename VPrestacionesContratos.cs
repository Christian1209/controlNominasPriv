using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcesadorNominaas
{
    public partial class VPrestacionesContratos : Form
    {
        public string carniceria {  get; set; }
        public VPrestacionesContratos(string carniceria_param)
        {
            InitializeComponent();
            carniceria = carniceria_param;
        }

        private void BtnAguinaldos_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (ValidarVentana(typeof(AltaEmpleado)))
            {
                return;
            }
            Form formulario = new VentanaAguinaldos(carniceria);
            formulario.Show();
            Cursor.Current = Cursors.Default;
        }

        private void VPrestacionesContratos_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (ValidarVentana(typeof(AltaEmpleado)))
            {
                return;
            }
        }

        private void BtnVacaciones_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (ValidarVentana(typeof(AltaEmpleado)))
            {
                return;
            }
            Form formulario = new VVacaciones(carniceria);
            formulario.Show();
            Cursor.Current = Cursors.Default;
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
