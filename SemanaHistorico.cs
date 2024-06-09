using Microsoft.Office.Interop.Excel;
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
    public partial class SemanaHistorico : Form
    {
        string sucursal;
        int contador = 0;

        public SemanaHistorico(string sucursal)
        {
            InitializeComponent();
            this.sucursal = sucursal;   
        }

        private Semana activeForm = null;

        private void SemanaHistorico_Load(object sender, EventArgs e)
        {
            AbreFormularioSemana("actual");
        }
        Semana form2 = null;
        public void AbreFormularioSemana(string anterior)
        {
            form2 = new Semana(sucursal, anterior, 0);

            // Establecer el formulario secundario como hijo
            form2.TopLevel = false;
            form2.FormBorderStyle = FormBorderStyle.None;
            form2.Dock = DockStyle.Fill;

            // Agregar el formulario secundario al Panel y mostrarlo
            panel.Controls.Add(form2);
            form2.Show();
        }

        public void btnSemanaAnterior_Click(object sender, EventArgs e)
        {
            form2.Close(); 
            panel.Controls.Clear();
            contador = contador + 7;
            form2 = new Semana(sucursal, "anterior", contador);

            // Establecer el formulario secundario como hijo
            form2.TopLevel = false;
            form2.FormBorderStyle = FormBorderStyle.None;
            form2.Dock = DockStyle.Fill;

            // Agregar el formulario secundario al Panel y mostrarlo
            panel.Controls.Add(form2);
            form2.Show();
        }

        public void btnSiguienteSemana_Click(object sender, EventArgs e)
        {
            contador = contador - 7;
            if (contador < 0)
            {
                contador = 0;
                MessageBox.Show("No hay semanas posteriores a la actual.");
                return;
            }

            form2.Close();
            panel.Controls.Clear();

            if(contador == 0)
                form2 = new Semana(sucursal, "actual", contador);
            else
                form2 = new Semana(sucursal, "anterior", contador);

            // Establecer el formulario secundario como hijo
            form2.TopLevel = false;
            form2.FormBorderStyle = FormBorderStyle.None;
            form2.Dock = DockStyle.Fill;

            // Agregar el formulario secundario al Panel y mostrarlo
            panel.Controls.Add(form2);
            form2.Show();
        }
    }
}
