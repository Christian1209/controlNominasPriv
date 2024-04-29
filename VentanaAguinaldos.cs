using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ProcesadorNominaas.Properties;
using static ICSharpCode.SharpZipLib.Zip.ExtendedUnixData;

namespace ProcesadorNominaas
{
    public partial class VentanaAguinaldos : Form
    {
        public string carniceria {  get; set; }
        public MySqlConnection connection;
        public VentanaAguinaldos(string carniceria_param)
        {
            InitializeComponent();
            carniceria = carniceria_param;
            connection = new MySqlConnection("Server=monorail.proxy.rlwy.net;Port=15455;Database="+carniceria+";Uid=root;password=HBFHC45b5A2BE4a552G-Cf13AeEA-DFE;");
        }

        private void VentanaAguinaldos_Load(object sender, EventArgs e)
        {

        }

        public void CargaAutoComplete()
        {
            using (connection)
            {
                try
                {
                    connection.Open();
                    AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                    MySqlDataAdapter adaptador = new MySqlDataAdapter("SELECT * FROM Empleados", connection);
                    DataTable datos = new DataTable();
                    adaptador.Fill(datos);
                    //LLenar autocomplete
                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        lista.Add(datos.Rows[i]["nombres"].ToString());
                    }
                    textBoxBusquedaPorNombre.AutoCompleteCustomSource = lista;

                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            TablaAguinaldos.Rows.Clear();
            TablaAguinaldos.Visible = true;
            btnBusquedaNombre.Visible = true;
            lblBusquedaNombre.Visible=true;
            textBoxBusquedaPorNombre.Visible = true;

            CargaAutoComplete();
            Cursor.Current = Cursors.Default;
        }

        private void btnBusquedaNombre_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int flag;
            using (connection)
            {
                try
                {
                    connection.Open();

                    string sqlString = "SELECT * FROM Empleados WHERE nombres = " + "'" + textBoxBusquedaPorNombre.Text + "'" + ";"; 
                    MySqlCommand comando = new MySqlCommand(sqlString, connection);
                    //Bandera para saber si se encontro almenos 1 consulta que coincida
                    flag = Convert.ToInt32(comando.ExecuteScalar());
                    if (flag == 1) MessageBox.Show(" Se ha encontrado al empleado ");
                    if (flag == 0)
                    {
                        MessageBox.Show("Este Empleado no está registrado");
                        return;
                    }
                    MySqlDataReader lector;
                    lector = comando.ExecuteReader();

                    if (lector.Read())
                    {
                        // Obtener el año actual
                        int year = DateTime.Now.Year;
                        // Crear una fecha para el último dia de diciembre del año actual porque el aguinaldo se calcula hasta el ultimo dia de diciembre
                        DateTime ultDiaDiciembre = new DateTime(year, 12, DateTime.DaysInMonth(year, 12));

                        double aguinaldo_total = 0;
                        //Obtener la fecha de ingreso
                        DateTime fechaInicio = Convert.ToDateTime(lector["fecha_ingreso"]);
                        //Obtener Dias trabajados
                        TimeSpan diast = ultDiaDiciembre.Subtract(fechaInicio);
                        //Para saber si lleva mas de 1 año trabajando
                        int añosTrabajados = DateTime.Today.Year - fechaInicio.Year;


                        if (añosTrabajados >= 1) aguinaldo_total = 15 * (float.Parse(lector["sueldo_base"].ToString())/7);//Calcular aguinaldo si lleva mas de 1 año
                        //si lleva menos de un año
                        if (añosTrabajados <= 0)
                        { // Calcular pero con la fecha actual no la de 31 de diciembre

                            diast = DateTime.Today.Subtract(fechaInicio);
                            aguinaldo_total = (0.041096 * diast.TotalDays) * (float.Parse(lector["sueldo_base"].ToString()) / 7);//Calcular aguinaldo si lleva menos de 1 año
                        }


                        //Agregar al datagrid los datos del empleado con el aguinaldo calculado
                        TablaAguinaldos.Rows.Add(lector["id"].ToString(), lector["nombres"].ToString(), lector["sueldo_base"].ToString(), fechaInicio.ToShortDateString(), (añosTrabajados <=0)? DateTime.Today.ToShortDateString(): ultDiaDiciembre.ToShortDateString(), diast.TotalDays, aguinaldo_total);
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            TablaAguinaldos.Rows.Clear();
            btnBusquedaNombre.Visible = false;
            lblBusquedaNombre.Visible = false;
            textBoxBusquedaPorNombre.Visible = false;
            DialogResult response = MessageBox.Show("¿Estas seguro que deseas Cargar los aguinaldos \n de todos los empleados? " , "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (response == DialogResult.No)return;
            TablaAguinaldos.Visible = true;

            using (connection)
            {
                try
                {
                    connection.Open();

                    string sqlString = "SELECT * FROM Empleados ;"; 
                    MySqlCommand comando = new MySqlCommand(sqlString, connection);
                    MySqlDataReader lector;
                    lector = comando.ExecuteReader();

                        while (lector.Read())
                        {
                            
                            // Obtener el año actual
                            int year = DateTime.Now.Year;
                            // Crear una fecha para el ultimo dia de diciembre del año actual porque el aguinaldo se calcula hasta el ultimo dia de diciembre
                            DateTime ultDiaDiciembre = new DateTime(year, 12, DateTime.DaysInMonth(year, 12));

                            double aguinaldo_total = 0;
                            //Obtener la fecha de ingreso
                            DateTime fechaInicio = Convert.ToDateTime(lector["fecha_ingreso"]);
                            //Obtener Dias trabajados
                            TimeSpan diast = ultDiaDiciembre.Subtract(fechaInicio);
                            //Para saber si lleva mas de 1 año trabajando
                            int añosTrabajados = DateTime.Today.Year - fechaInicio.Year;


                            if (añosTrabajados >= 1) aguinaldo_total = 15 * (float.Parse(lector["sueldo_base"].ToString()) / 7);//Calcular aguinaldo si lleva mas de 1 año
                                                                                                                               
                            if (añosTrabajados <= 0) //si lleva menos de un año
                            { // Calcular pero con la fecha actual no la de 31 de diciembre

                                diast = DateTime.Today.Subtract(fechaInicio);
                                aguinaldo_total = (0.041096 * diast.TotalDays) * (float.Parse(lector["sueldo_base"].ToString()) / 7);//Calcular aguinaldo si lleva menos de 1 año
                            }


                            //Agregar al datagrid los datos del empleado con el aguinaldo calculado
                            TablaAguinaldos.Rows.Add(lector["id"].ToString(), lector["nombres"].ToString(), lector["sueldo_base"].ToString(), fechaInicio.ToShortDateString(), (añosTrabajados <= 0) ? DateTime.Today.ToShortDateString() : ultDiaDiciembre.ToShortDateString(), diast.TotalDays, aguinaldo_total);
                        }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void TablaAguinaldos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 6)
            {
                // Obtener el valor de la celda clickeada
                DataGridViewCell cell = TablaAguinaldos.Rows[e.RowIndex].Cells[1];
                MessageBox.Show("¿Deseas pagar el aguinaldo de este empleado?: " + cell.Value.ToString());
            }
        }
    }
}
