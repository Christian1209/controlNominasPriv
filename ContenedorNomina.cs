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
    public partial class ContenedorNomina : Form
    {
        string sucursal = "";
        public ContenedorNomina(string sucursal)
        {
            InitializeComponent();
            this.sucursal = sucursal;   
        }

        private void BtnLunes_Click(object sender, EventArgs e)
        {
            DiaNomina form1 = new DiaNomina("Lunes", sucursal);
            form1.ShowDialog();
        }

        private void BtnMartes_Click(object sender, EventArgs e)
        {
            DiaNomina form1 = new DiaNomina("Martes", sucursal);
            form1.ShowDialog();
        }

        private void BtnMiercoles_Click(object sender, EventArgs e)
        {
            DiaNomina form1 = new DiaNomina("Miercoles", sucursal);
            form1.ShowDialog();
        }

        private void BtnJueves_Click(object sender, EventArgs e)
        {
            DiaNomina form1 = new DiaNomina("Jueves", sucursal);
            form1.ShowDialog();
        }

        private void BtnViernes_Click(object sender, EventArgs e)
        {
            DiaNomina form1 = new DiaNomina("Viernes", sucursal);
            form1.ShowDialog();
        }

        private void BtnSabado_Click(object sender, EventArgs e)
        {
            DiaNomina form1 = new DiaNomina("Sabado", sucursal);
            form1.ShowDialog();
        }

        private void BtnDomingo_Click(object sender, EventArgs e)
        {
            DiaNomina form1 = new DiaNomina("Domingo", sucursal);
            form1.ShowDialog();
        }

        private void BtnSemana_Click(object sender, EventArgs e)
        {
            Semana form1 = new Semana(sucursal);
            form1.ShowDialog();
        }
    }
}
