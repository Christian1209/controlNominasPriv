using MySql.Data.MySqlClient;
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
    public partial class VVacaciones : Form
    {

        public string carniceria { get; set; }
        public MySqlConnection connection;
        public VVacaciones(string carniceria_param)
        {
            InitializeComponent();
            carniceria = carniceria_param;
            connection = new MySqlConnection("Server=monorail.proxy.rlwy.net;Port=15455;Database=" + carniceria + ";Uid=root;password=HBFHC45b5A2BE4a552G-Cf13AeEA-DFE;");
        }

        private void btn_solicitar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            dataGrid_Vacaciones.Rows.Clear();
            btnBusquedaNombre.Visible = true;
            lblBusquedaNombre.Visible = true;
            txtBox_BusquedaPorNombre.Visible = true;

            CargaAutoComplete();
            Cursor.Current = Cursors.Default;
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
                    txtBox_BusquedaPorNombre.AutoCompleteCustomSource = lista;

                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
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

                    string sqlString = "SELECT * FROM Empleados WHERE nombres = " + "'" + txtBox_BusquedaPorNombre.Text + "'" + ";";
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
                        //Obtener la fecha de ingreso
                        DateTime fechaInicio = Convert.ToDateTime(lector["fecha_ingreso"]);
                        //Para saber si lleva mas de 1 año trabajando
                        int añosTrabajados = DateTime.Today.Year - fechaInicio.Year;
                        int diasCorrespondientes = 0;

                        if (añosTrabajados <= 1) diasCorrespondientes = 0;
                        if (añosTrabajados == 1) diasCorrespondientes = 12;
                        if (añosTrabajados == 2) diasCorrespondientes = 14;
                        if (añosTrabajados == 3) diasCorrespondientes = 16;
                        if (añosTrabajados == 4) diasCorrespondientes = 18;
                        if (añosTrabajados == 5) diasCorrespondientes = 20;
                        if (añosTrabajados >= 6 && añosTrabajados <= 10) diasCorrespondientes = 22;
                        if (añosTrabajados >= 11 && añosTrabajados <= 15) diasCorrespondientes = 24;
                        if (añosTrabajados >= 16 && añosTrabajados <= 20) diasCorrespondientes = 26;
                        if (añosTrabajados >= 21 && añosTrabajados <= 25) diasCorrespondientes = 28;
                        if (añosTrabajados >= 26) diasCorrespondientes = 30;


                        dataGrid_Vacaciones.Rows.Add(lector["id"].ToString(), lector["nombres"].ToString(), lector["dias_vacaciones"], (diasCorrespondientes - Convert.ToInt16(lector["dias_vacaciones"])) );
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
    }
}
