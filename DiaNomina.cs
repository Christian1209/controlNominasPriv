using MySql.Data.MySqlClient;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;                   
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace ProcesadorNominaas
{
    public partial class DiaNomina : Form
    {
        string dia;
        string fechaDeHoy;
        //conexion a base de datos.
        string conexion = ("Server=monorail.proxy.rlwy.net;Port=15455;Database=railway;Uid=root;password=HBFHC45b5A2BE4a552G-Cf13AeEA-DFE;");
        string sucursal = "";

        public DiaNomina(string diaEnviado, string sucursal)
        {
            InitializeComponent();
            dia = diaEnviado;
            lblDia.Text = dia;
            this.sucursal = sucursal;
        }

        private void DiaNomina_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool valida = ValidaSemana(dia);
            if (valida)
            {
                //MessageBox.Show("ES VALIDO");
                //obtener las fechas del dia, de acuerdo a la semana actual.
                string fecha = ObtenFechaDia(dia);
                string querySQL = "SELECT" +
                    "\r\n    Dias.id_empleado AS 'id'," +
                    "\r\n    " + sucursal + ".Empleados.nombres AS 'Nombre Del Empleado'," +
                    "\r\n    " + sucursal + ".Dias.fecha AS 'Fecha'," +
                    "\r\n    " + sucursal + ".Dias.asistencia As 'Asistencia'," +
                    "\r\n    " + sucursal + ".Dias.retardo AS 'Retardo'," +
                    "\r\n    " + sucursal + ".Dias.salida AS 'Salida'," +
                    "\r\n    " + sucursal + ".Dias.turno_extra AS 'T/E'," +
                    "\r\n    " + sucursal + ".Dias.comida AS 'Comida'," +
                    "\r\n    " + sucursal + ".Dias.descanso_trabajado AS 'Descanso Trabajado'," +
                    "\r\n    " + sucursal + ".Dias.horas_trabajadas AS 'Horas Trabajadas'," +
                    "\r\n    " + sucursal + ".Dias.hora_llegada AS 'Hora LLegada'," +
                    "\r\n    " + sucursal + ".Dias.hora_salida AS 'Hora Salida'," +
                    "\r\n    " + sucursal + ".Empleados.entrada As 'Horario Entrada'," +
                    "\r\n    " + sucursal + ".Empleados.salida AS 'Horario Salida'," +
                    "\r\n    " + sucursal + ".Empleados.dia_descanso AS 'Dia Descanso'" +
                    "\r\nFROM " + sucursal + ".Dias" +
                    "\r\nINNER JOIN " + sucursal + ".Empleados ON " + sucursal + ".Dias.id_empleado = " + sucursal + ".Empleados.id_checador WHERE " + sucursal + ".Dias.fecha = '" + fecha + "'";
                LlenaDatagrid(querySQL, fecha);
            }
            else
            {
                MessageBox.Show("El dia que intentas ver aun no es procesado de acuerdo a la semana actual");
                this.Close();
            }
            Cursor.Current = Cursors.Arrow;
        }


        public string ObtenFechaDia(string dia)
        {


            DateTime hoy = DateTime.Now;
            int numeroDia = DaNumeroDia(dia);
            int numeroHoy = DaNumeroDia(hoy.DayOfWeek.ToString());
            //este contador nos va a servir para obtener la diferencia de dias entre el dia de hoy y el dia que se quiere mostrar
            int contador = 0;
            if (numeroDia > numeroHoy)
            {
                int numeroDiaAux = numeroDia;
                int numeroHoyAux = numeroHoy;
                while(numeroHoyAux != numeroDiaAux)
                {
                    numeroHoyAux++;
                    contador++;
                }
            }
            if (numeroDia < numeroHoy)
            {
                int numeroDiaAux = numeroDia;
                int numeroHoyAux = numeroHoy;
                while (numeroHoyAux != numeroDiaAux)
                {
                    numeroHoyAux--;
                    contador--;
                }
            }

            hoy = hoy.AddDays(contador);

           

            return hoy.Year.ToString() + "-" + hoy.Month.ToString() + "-" + hoy.Day.ToString();
           
        }

        public bool ValidaSemana(string dia)
        {
            DateTime hoy = DateTime.Now;

            int numeroDia = DaNumeroDia(dia);
            int numeroHoy = DaNumeroDia(hoy.DayOfWeek.ToString());
            if(numeroHoy - numeroDia  >= 0)
            {
                return true;
            }

            return false;
        }

        public int DaNumeroDia(string dia)
        {
            string diaAux = ConvierteDia(dia);
            return AsignaNumero(diaAux);
        }

        public int AsignaNumero(string diaAux)
        {
            switch (diaAux)
            {
                case "Monday":
                    return 4;
                case "Tuesday":
                    return 5;
                case "Wednesday":
                    return 6;
                case "Thursday":
                    return 7;
                case "Friday":
                    return 1;
                case "Saturday":
                    return 2;
                case "Sunday":
                    return 3;
                default:
                    return 0; // En caso de que el string no coincida con ningún día
            }
        }

        public string ConvierteDia(string descanso)
        {
            if (descanso == "Lunes")
                return "Monday";
            if (descanso == "Martes")
                return "Tuesday";
            if (descanso == "Miercoles")
                return "Wednesday";
            if (descanso == "Jueves")
                return "Thursday";
            if (descanso == "Viernes")
                return "Friday";
            if (descanso == "Sabado")
                return "Saturday";
            if (descanso == "Domingo")
                return "Sunday";
            return descanso;
        }

        public void LlenaDatagrid(string querySQL, string fecha)
        {
            //MessageBox.Show(dia);
            using (var connection = new MySqlConnection(conexion))
            {
                try
                {
                    connection.Open();
                    // Adaptador SQL para ejecutar la consulta y llenar el DataTable
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(querySQL, connection);
                    DataTable dataTable = new DataTable();

                    // Llenar el DataTable
                    adaptador.Fill(dataTable);
                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No hay ningún registro procesado, procesa el archivo de checada correspondiente al dia que intentas ver. (" + fecha + ")");
                        // Aquí puedes manejar el caso de "no hay registros"
                        this.Close();
                    }
                    else
                    {
                        // Asignar el DataTable como DataSource del DataGridView
                        DataGridDia.DataSource = dataTable;
                        DataGridDia.CellFormatting += new DataGridViewCellFormattingEventHandler(myDataGridView_CellFormatting);
                    }
   
                }
                catch (Exception ex)
                {
                    //MessageBox.Show($"Ocurrió un error al buscar el registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void myDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Asumiendo que quieres cambiar el color en la columna con índice 0
            //retardo
            if (e.ColumnIndex == 4)
            {
                var cellValue = e.Value; // Obtienes el valor de la celda

                // Aquí aplicas la condición deseada, en este ejemplo, cambiar si el valor es específico
                if (cellValue != null && cellValue.ToString() == "SI")
                {
                    // Cambia el color del texto a rojo
                    e.CellStyle.ForeColor = Color.Red;

                }
            }
            //faltó
            if (e.ColumnIndex == 3)
            {
                var cellValue = e.Value; // Obtienes el valor de la celda

                // Aquí aplicas la condición deseada, en este ejemplo, cambiar si el valor es específico
                if (cellValue != null && cellValue.ToString() == "Faltó")
                {
                    // Cambia el color del texto a rojo
                    e.CellStyle.ForeColor = Color.Red;
                }
                if (cellValue != null && cellValue.ToString() == "Descansó")
                {
                    // Cambia el color del texto a rojo
                    e.CellStyle.ForeColor = Color.Blue;
                }
            }
            //Salida
            if (e.ColumnIndex == 5)
            {
                var cellValue = e.Value; // Obtienes el valor de la celda

                // Aquí aplicas la condición deseada, en este ejemplo, cambiar si el valor es específico
                if (cellValue != null && cellValue.ToString() == "SI")
                {
                    // Cambia el color del texto a rojo
                    e.CellStyle.ForeColor = Color.Red;

                }
            }
            //Turno Extra
            if (e.ColumnIndex == 6)
            {
                var cellValue = e.Value; // Obtienes el valor de la celda

                // Aquí aplicas la condición deseada, en este ejemplo, cambiar si el valor es específico
                if (cellValue != null && cellValue.ToString() == "SI")
                {
                    // Cambia el color del texto a rojo
                    e.CellStyle.ForeColor = Color.Green;
                }
            }
            //Descanso trabajado
            if (e.ColumnIndex == 8)
            {
                var cellValue = e.Value; // Obtienes el valor de la celda

                // Aquí aplicas la condición deseada, en este ejemplo, cambiar si el valor es específico
                if (cellValue != null && cellValue.ToString() == "SI")
                {
                    // Cambia el color del texto a rojo
                    e.CellStyle.ForeColor = Color.Green;

                }
                if (cellValue != null && cellValue.ToString() == "NO REPUSO")
                {
                    // Cambia el color del texto a rojo
                    e.CellStyle.ForeColor = Color.Red;

                }
                if (cellValue != null && cellValue.ToString() == "REPUSO")
                {
                    // Cambia el color del texto a rojo
                    e.CellStyle.ForeColor = Color.Blue;

                }
            }
        }

        private void DataGridDia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
