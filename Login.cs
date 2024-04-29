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
    public partial class Login : Form
    {
        static string conexion = ("Server=monorail.proxy.rlwy.net;Port=15455;Database=Cuentas;Uid=root;password=HBFHC45b5A2BE4a552G-Cf13AeEA-DFE;");
        public Login()
        {
            InitializeComponent();
            lbl_salir.MouseEnter += Label_MouseEnter;
            lbl_salir.MouseLeave += Label_MouseLeave;
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string usuario = txt_username.Text;
            string contraseña = txt_password.Text;
            string privilegios = "";
            string nombre = "";
            string carniceria = "";
            new Form1("Normandia").Show();
            this.Hide();
            Cursor.Current = Cursors.Default;
            int flag = 0;
            /*
            using (var connection = new MySqlConnection(conexion))
            {
                try
                {
                    connection.Open();

                    string sqlString = "SELECT * FROM cuentas WHERE usuario = " +"'"+ usuario + "'" + "AND contraseña =" +"'"+ contraseña +"'" +";";
                    MySqlCommand comando = new MySqlCommand(sqlString, connection);
                    //Bandera para saber si se encontro almenos 1 consulta que coincida
                    flag = Convert.ToInt32(comando.ExecuteScalar());
                    if (flag == 1)
                    {
                        MySqlDataReader lector;
                        lector = comando.ExecuteReader();


                        if (lector.Read())
                        {
                            privilegios = lector["privilegio"].ToString();
                            nombre = lector["nombre"].ToString();
                            carniceria = lector["carniceria"].ToString();
                            connection.Close();
                        }
                        MessageBox.Show("Bienvenido: " + nombre + "\n" + "Privilegios: "+privilegios);


                        new Form1(carniceria).Show();
                        this.Hide();
                        Cursor.Current = Cursors.Default;
                    }
                    if (flag == 0)
                    {
                        MessageBox.Show("Credenciales incorrectas");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

            }
                        */
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            
        }

        private void Label_MouseEnter(object sender, EventArgs e)
        {
            // Cambiar el color de fondo del Label cuando el mouse entra en él
            lbl_salir.ForeColor = Color.Gray;
        }

        private void Label_MouseLeave(object sender, EventArgs e)
        {
            // Restaurar el color de fondo original del Label cuando el mouse sale de él
            lbl_salir.ForeColor = Color.DarkRed;
        }
    }
}
