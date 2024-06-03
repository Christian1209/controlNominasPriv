using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlTypes;
using MySql.Data.MySqlClient;


namespace ProcesadorNominaas
{
    public partial class FormVariablesSucursal : Form
    {

        string conexion = ("Server=monorail.proxy.rlwy.net;Port=15455;Database=railway;Uid=root;password=HBFHC45b5A2BE4a552G-Cf13AeEA-DFE;");
        string sucursal = "";

        //variables de la sucursal
        float comida = 0;
        float retardo = 0;
        float salida = 0;
        float sueldo_alto = 0;
        float salida_baja = 0;
        float retardo_bajo = 0;

        int minutos_tarde = 0;
        int minutos_mañana = 0;


        public FormVariablesSucursal(string sucursal)
        {
            InitializeComponent();
            this.sucursal = sucursal;
        }

        private void FormVariablesSucursal_Load(object sender, EventArgs e)
        {
            CargaVariables();
            AsignaTextBox();
            BloqueaTextBox();
        }


        public void CargaVariables()
        {
            try
            {
                string query = "SELECT * FROM " + sucursal + ".Variables "; // Ajusta la consulta según tus necesidades
                using (var connection = new MySqlConnection(conexion))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        comida = float.Parse(reader["comida"].ToString());
                        retardo = float.Parse(reader["retardo"].ToString());
                        salida = float.Parse(reader["salida"].ToString());
                        sueldo_alto = float.Parse(reader["sueldo_alto"].ToString());
                        salida_baja = float.Parse(reader["salida_baja"].ToString());
                        retardo_bajo = float.Parse(reader["retardo_bajo"].ToString());
                        minutos_mañana = int.Parse(reader["minutos_tolerancia_mañana"].ToString());
                        minutos_tarde = int.Parse(reader["minutos_tolerancia_tarde"].ToString());

                    }

                    reader.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error de SQL: " + ex.Message);
                // Maneja el error de SQL (por ejemplo, problemas de conexión, errores de consulta, etc.)
            }
        }

        public void BloqueaTextBox()
        {
            txtMinutosTarde.ReadOnly = true;
            txtMinutosMañana.ReadOnly = true;
            txtComida.ReadOnly = true;
            txtMultaSalida.ReadOnly = true;
            txtMultaRetardo.ReadOnly = true;
            txtMultaSalidaBajo.ReadOnly = true;
            txtMultaRetardoBajo.ReadOnly = true;
            txtSueldoAltoTope.ReadOnly = true;
        }


        public void LiberaTextBox()
        {
            txtMinutosTarde.ReadOnly = false;
            txtMinutosMañana.ReadOnly = false;
            txtComida.ReadOnly = false;
            txtMultaSalida.ReadOnly = false;
            txtMultaRetardo.ReadOnly = false;
            txtMultaSalidaBajo.ReadOnly = false;
            txtMultaRetardoBajo.ReadOnly = false;
            txtSueldoAltoTope.ReadOnly = false;
        }

        public void AsignaTextBox()
        {
            txtMinutosTarde.Text = minutos_tarde.ToString();
            txtMinutosMañana.Text = minutos_mañana.ToString();
            txtComida.Text = comida.ToString();
            txtMultaSalida.Text = salida.ToString();
            txtMultaRetardo.Text = retardo.ToString();
            txtMultaSalidaBajo.Text = salida_baja.ToString();
            txtMultaRetardoBajo.Text = retardo_bajo.ToString();
            txtSueldoAltoTope.Text = sueldo_alto.ToString();
           
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            AsignaTextBox();
        }


        public void Inserta()
        {
            string sqlString = "INSERT INTO " + sucursal + ".Variables (minutos_tolerancia_tarde,minutos_tolerancia_mañana,comida,retardo,salida,retardo_bajo,salida_baja,sueldo_alto) VALUES (";
            sqlString = sqlString +  txtMinutosTarde.Text.ToString() + "'" + ",";
            sqlString = sqlString + "'" + txtMinutosMañana.Text.ToString() + "'" + ",";
            sqlString = sqlString + "'" + txtComida.Text.ToString()+ "'" + ",";
            sqlString = sqlString + "'" + txtMultaRetardo.Text.ToString() + "'" + ",";
            sqlString = sqlString + "'" + txtMultaSalida.Text.ToString() + "'" + ",";
            sqlString = sqlString + "'" + txtMultaRetardoBajo.Text.ToString() + "'" + ",";
            sqlString = sqlString + "'" + txtMultaSalidaBajo.Text.ToString() + "'" + ",";
            sqlString = sqlString + "'" + txtSueldoAltoTope.Text.ToString() + "'" + ")";


            using (var connection = new MySqlConnection(conexion))
            {
                try
                {
                    connection.Open();

                    MySqlCommand comando = new MySqlCommand(sqlString, connection);
                    comando.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Se actualizó correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un Error: " + ex.Message);
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Introduce contraseña");
            LiberaTextBox();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Inserta();
        }
    }

}
