using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;
using NPOI.SS.Formula.Functions;
using System.Security.Policy;
using System.Data.SqlTypes;
using NPOI.XWPF.UserModel;
using System.Net.Mail;

namespace ProcesadorNominaas
{
    public partial class AltaEmpleado : Form
    {

        public string conexion;
        public AltaEmpleado(int opcion, string carniceria_param)
        
        {
            conexion = "Server=monorail.proxy.rlwy.net;Port=15455;Database=" + carniceria_param + ";Uid=root;password=HBFHC45b5A2BE4a552G-Cf13AeEA-DFE;";
            MySqlConnection connection = new MySqlConnection("Server=monorail.proxy.rlwy.net;Port=15455;Database=" + carniceria_param + ";Uid=root;password=HBFHC45b5A2BE4a552G-Cf13AeEA-DFE;");
            InitializeComponent();
            if (opcion == 1)
            {
                selectedOp = 1;
                MetodosInterfazAlta();
                textBoxBusquedaPorNombre.Visible = false;   
                lblBusquedaNombre.Visible = false;  
            }
            if (opcion == 2)
            {
                selectedOp = 2;
                BloqueaControles();
                MetodosInterfazBaja();
                CargaAutoComplete();
            }
            if (opcion == 3)
            {
                selectedOp = 3;
                BloqueaControles();
                MetodosInterfazActualizacion();
                CargaAutoComplete();
            }
            if (opcion == 4)
            {
                selectedOp = 4;
                BloqueaControles();
                MetodosInterfazVer();
                CargaAutoComplete();
            }
        }
        List<String> listaMeses = new List<String>() { "Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic" };
        public int selectedOp = 0, claveCargada = 0;
        


        private void AltaEmpleado_Load(object sender, EventArgs e)
        {
            //metodos para llenar combo box
            LlenaCombos();
            /*
            using (connection)
            {
                try
                {
                    connection.Open();

                    // Aquí puedes ejecutar tus consultas SQL

                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            */
        }

        //METODOS DE OPTIONS

        public void MetodosInterfazAlta()
        {
            EscondeBotones();
            BtnAltaEmpleado.Visible = true;
            lblTest.Text = "ALTA DE EMPLEADO";
            BtnAltaEmpleado.Enabled = true;
        }
        public void MetodosInterfazBaja()
        {
            lblTest.Text = "BAJA DE EMPLEADO";
            btnBajaEmpleado.Visible = true;
            btnBajaEmpleado.Enabled = false;
        }
        public void MetodosInterfazActualizacion()
        {
            lblTest.Text = "ACTUALIZACION DE EMPLEADO";
            btnActualizarEmpleado.Visible = true;
            btnActualizarEmpleado.Enabled = false;
        }
        public void MetodosInterfazVer()
        {
            lblTest.Text = "VER EMPLEADO";
        }

        public void BloqueaControles()
        {
            foreach (Control control in this.Controls)  
            {
                if (control is TextBox)
                {
                    TextBox txt = (TextBox)control;

                    txt.Enabled = false;
                }

                if (control is ComboBox)
                {
                    ComboBox combo = (ComboBox)control;

                    combo.Enabled = false;
                }
            }
            textBoxBusquedaPorNombre.Enabled = true;
            textBoxClave.Enabled = true;
        }

        public void DesbloqueaControles()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    TextBox txt = (TextBox)control;

                    txt.Enabled = true;
                }

                if (control is ComboBox)
                {
                    ComboBox combo = (ComboBox)control;

                    combo.Enabled = true;
                }
            }
            btnActualizarEmpleado.Enabled = true;
            btnBajaEmpleado.Enabled = true;
            BtnAltaEmpleado.Enabled = true;
        }


        public void EscondeBotones()
        {
            btnBusquedaClave.Hide();
            btnBusquedaNombre.Hide();
        }

        public void CargaAutoComplete()
        {
            using (var connection = new MySqlConnection(conexion))
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


        //METODOS DE LA INTERFAZ.
        public void LlenaCombos()
        {
            for (int i = 0; i < 30; i++)
            {
                comboBoxDiaNacimiento.Items.Add(i+1);
                comboBoxDiaIngreso.Items.Add(i+1);
                comboBoxDiaImss.Items.Add(i + 1);
            }
            for (int i = 2005; i < 2030; i++)
            {
                comboBoxAnioIngreso.Items.Add(i + 1);
                comboBoxAñoImss.Items.Add(i + 1);   
            }
            for (int i = 1950; i < 2015; i++)
            {
                comboBoxAñoNacimiento.Items.Add(i + 1);
            }
            foreach (var item in listaMeses)
            {
                comboBoxMesIngreso.Items.Add(item);
                comboBoxMesNacimiento.Items.Add(item);
                comboBoxMesImss.Items.Add(item);
            }
            for (int i = 0; i < 10; i++)
            {
                comboBoxMinutosEntrada.Items.Add('0' + i.ToString());
                comboBoxMinutosSalida.Items.Add('0' + i.ToString());
                comboBoxMinutoEntradaDomingo.Items.Add('0' + i.ToString());
                //if(i != 0)
                //{
                    comboBoxHoraEntrada.Items.Add('0' + (i.ToString()));
                    comboBoxHoraSalida.Items.Add('0' + (i.ToString()));
                    comboBoxHoraEntradaDomingo.Items.Add('0' + (i.ToString()));
                //}
                }
            for (int i = 10; i < 24; i++)
            {
                comboBoxHoraEntrada.Items.Add(i);
                comboBoxHoraSalida.Items.Add(i);
                comboBoxHoraEntradaDomingo.Items.Add(i);
            }
            for (int i = 10; i < 61; i++)
            {
                comboBoxMinutosEntrada.Items.Add(i);
                comboBoxMinutosSalida.Items.Add(i);
                comboBoxMinutoEntradaDomingo.Items.Add(i);
            }
            //
            comboBoxGenero.Items.Add("MASCULINO");
            comboBoxGenero.Items.Add("FEMENINO");
            comboBoxGenero.Items.Add("OTRO");
            comboBoxTipoContrato.Items.Add("INDEFINIDO");
            comboBoxTipoContrato.Items.Add("A PRUEBA");
            comboBoxSexo.Items.Add("HOMBRE");
            comboBoxSexo.Items.Add("MUJER");
            comboBoxArea.Items.Add("ADMINISTRACION\r\n");
            comboBoxArea.Items.Add("CARNICERIA\r\n");
            comboBoxArea.Items.Add("COCINA\r\n");
            comboBoxArea.Items.Add("COMPRAS\r\n");
            comboBoxArea.Items.Add("CREMERIA\r\n");
            comboBoxArea.Items.Add("FRITA\r\n");
            comboBoxArea.Items.Add("LOGISTICA\r\n");
            comboBoxArea.Items.Add("OPERACIÓN\r\n");
            comboBoxArea.Items.Add("SUPER\r\n");
            comboBoxPuesto.Items.Add("ALMACENISTA DE FRIO");
            comboBoxPuesto.Items.Add("AUXILIAR ADMINISTRATIVO");
            comboBoxPuesto.Items.Add("AUXILIAR DE CARNICERIA");
            comboBoxPuesto.Items.Add("AUXILIAR DE COCINA\r\n");
            comboBoxPuesto.Items.Add("AUXILIAR DE FREIDOR\r\n");
            comboBoxPuesto.Items.Add("AUXILIAR DE SUPERMERCADO\r\n");
            comboBoxPuesto.Items.Add("AUXILIAR OPERATIVO\r\n");
            comboBoxPuesto.Items.Add("CAJERA\r\n");
            comboBoxPuesto.Items.Add("CARNICERO\r\n");
            comboBoxPuesto.Items.Add("CHOFER\r\n");
            comboBoxPuesto.Items.Add("COCINERA\r\n");
            comboBoxPuesto.Items.Add("COMPRAS\r\n");
            comboBoxPuesto.Items.Add("DESHUESE\r\n");
            comboBoxPuesto.Items.Add("ENVIOS\r\n");
            comboBoxPuesto.Items.Add("FREIDOR\r\n");
            comboBoxPuesto.Items.Add("GERENTE ADMINISTRATIVO\r\n");
            comboBoxPuesto.Items.Add("GERENTE OPERATIVO\r\n");
            comboBoxPuesto.Items.Add("JEFA DE CAJAS\r\n");
            comboBoxPuesto.Items.Add("JEFA DE CREMERIA\r\n");
            comboBoxPuesto.Items.Add("JEFA DE SUPER\r\n");
            comboBoxPuesto.Items.Add("JEFE DE CARNICERIA\r\n");
            comboBoxPuesto.Items.Add("JEFE DE COCINA\r\n");
            comboBoxPuesto.Items.Add("JEFE DE REPARTO\r\n");
            comboBoxPuesto.Items.Add("PREPARADOS\r\n");
            comboBoxPuesto.Items.Add("REBANADOR\r\n");
            comboBoxPuesto.Items.Add("RECEPCION CLIENTES\r\n");
            comboBoxPuesto.Items.Add("RECEPCION DE MERCANCIA\r\n");
            comboBoxPuesto.Items.Add("RELLENADOR\r\n");
            comboBoxPuesto.Items.Add("RUTAS\r\n");
            comboBoxPuesto.Items.Add("TELEFONISTA\r\n");
            comboBoxPuesto.Items.Add("VENDEDOR\r\n");
            comboBoxPuesto.Items.Add("VENDEDORA DE CREMERIA\r\n");
            comboBoxPuesto.Items.Add("VIGILANTE\r\n");
            comboBoxTurno.Items.Add("MATUTINO");
            comboBoxTurno.Items.Add("VESPERTINO");
            comboBoxDiaDescanso.Items.Add("LUNES");
            comboBoxDiaDescanso.Items.Add("MARTES");
            comboBoxDiaDescanso.Items.Add("MIERCOLES");
            comboBoxDiaDescanso.Items.Add("JUEVES");
            comboBoxDiaDescanso.Items.Add("VIERNES");
            comboBoxDiaDescanso.Items.Add("SABADO");
            comboBoxDiaDescanso.Items.Add("DOMINGO");
            //
            comboBoxSeguro.Items.Add("SI");
            comboBoxSeguro.Items.Add("NO");
            comboBoxTarjeta.Items.Add("SI");
            comboBoxTarjeta.Items.Add("NO");

            if(selectedOp == 1)
            {
                obtenerID();
                textBoxBusquedaPorNombre.Dispose();
            }

        }

        public void enviarCorreo(string emailD, string asunto)
        {
            Cursor.Current = Cursors.WaitCursor;
            string oEmail = "procesadornominastest@gmail.com";
            string emailDestino = emailD;
            string pass = "ngev ebak rahf kpyj";

            string datos = "\nSucursal: "+"Sucursal"+"\nNombre : " + textBoxNombre.Text + "\nCalle: " + textBoxCalle.Text + "\nNo.Exterior: " + textBoxNoExterior.Text + "\nNo.Interior: " + textBoxNoInterior.Text;
            datos += "\nColonia: " + textBoxColonia.Text + "\nMunicipio: " + textBoxMunicipio.Text + "\nEstado: " + textBoxEstado.Text + "\nCodigo Postal:" + textBoxCodigoPostal.Text;
            datos += "\nSexo: " + ((comboBoxGenero.Text == "MASCULINO") ? "M" : "F") + "\nFecha Nacimiento: " + comboBoxAñoNacimiento.Text + comboBoxMesNacimiento.Text + comboBoxDiaNacimiento.Text + "\nRFC: " + textBoxRFC.Text + "\nCurp: " + textBoxCurp.Text;
            datos += "\nPuesto: " + comboBoxPuesto.Text + "\nNSS: " + textBoxNss.Text + "\nFecha de Ingreso: " + comboBoxAnioIngreso.Text + comboBoxMesIngreso.Text + comboBoxDiaIngreso.Text + "\n¿Cuenta con Infonavit? " + comboBoxInfonavit.Text;

            MailMessage oMailMessage = new MailMessage(oEmail, emailDestino, asunto, datos);

            try
            {
                SmtpClient oSmtpClient = new SmtpClient("smtp.gmail.com");
                oSmtpClient.EnableSsl = true;
                oSmtpClient.UseDefaultCredentials = false;
                oSmtpClient.Port = 587;
                oSmtpClient.Credentials = new System.Net.NetworkCredential(oEmail, pass);

                oSmtpClient.Send(oMailMessage);
                MessageBox.Show("El correo fue enviado correctamente");
                oSmtpClient.Dispose();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }


            Cursor.Current = Cursors.Default;
        }

        public void obtenerID()
        {
            string sqlString = "SELECT id FROM Empleados ORDER BY id DESC LIMIT 1;";

            using (var connection = new MySqlConnection(conexion))
            {
                try
                {
                    connection.Open();

                    MySqlCommand comando = new MySqlCommand(sqlString, connection);
                    MySqlDataReader lector;
                    lector = comando.ExecuteReader();

                    if (lector.Read()) textBoxClave.Text = (Convert.ToInt16(lector["id"]) + 1).ToString();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    
                }
            }
        }

        public void limpiarControles()
        {
            foreach (Control control in this.Controls)
            {
                if(control is TextBox)
                {
                    TextBox txt = (TextBox)control;
                    txt.Text = string.Empty;
                }
                else if(control is ComboBox)
                {
                    ComboBox cmb = (ComboBox)control;
                    cmb.SelectedIndex = -1;
                }
            }
        }

        public string FormateaFechaIngreso()
        {
            string date = "";
            date = comboBoxAnioIngreso.Text;
            string mes = FormateaMes(comboBoxMesIngreso.Text);
            date = date + "-" + mes;
            date = date + "-" + comboBoxDiaIngreso.Text;
            return date;
        }
        public string FormateaFechaNacimiento()
        {
            string date = "";
            date = comboBoxAñoNacimiento.Text;
            string mes = FormateaMes(comboBoxMesNacimiento.Text);
            date = date + "-" + mes;
            date = date + "-" + comboBoxDiaNacimiento.Text;
            return date;
        }

        public string FormateaFechaImss()
        {
            string date = "";
            date = comboBoxAñoImss.Text;
            string mes = FormateaMes(comboBoxMesImss.Text);
            date = date + "-" + mes;
            date = date + "-" + comboBoxDiaImss.Text;
            return date;
        }

        public string FormateaMes(string mes)
        {
            if(mes == "Ene")
            {
                return "01";
            }
            if (mes == "Feb")
            {
                return "02";
            }
            if (mes == "Mar")
            {
                return "03";
            }
            if (mes == "Abr")
            {
                return "04";
            }
            if (mes == "May")
            {
                return "05";
            }
            if (mes == "Jun")
            {
                return "06";
            }
            if (mes == "Jul")
            {
                return "07";
            }
            if (mes == "Ago")
            {
                return "08";
            }
            if (mes == "Sep")
            {
                return "09";
            }
            if (mes == "Oct")
            {
                return "10";
            }
            if (mes == "Nov")
            {
                return "11";
            }
            if (mes == "Dic")
            {
                return "12";
            }
            return " ";
        }

        public string FormateaMesInverso(string mes)
        {
            if (mes == "01")
            {
                return "Ene";
            }
            if (mes == "02")
            {
                return "Feb";
            }
            if (mes == "03")
            {
                return "Mar";
            }
            if (mes == "04")
            {
                return "Abr";
            }
            if (mes == "05")
            {
                return "May";
            }
            if (mes == "06")
            {
                return "Jun";
            }
            if (mes == "07")
            {
                return "Jul";
            }
            if (mes == "08")
            {
                return "Ago";
            }
            if (mes == "09")
            {
                return "Sep";
            }
            if (mes == "10")
            {
                return "Oct";
            }
            if (mes == "11")
            {
                return "Nov";
            }
            if (mes == "12")
            {
                return "Dic";
            }
            return " ";
        }

        // Función para verificar si todos los controles están llenos
        static bool VerificarControlesLlenos(Control.ControlCollection controles)
        {
            foreach (Control control in controles)
            {
                if (control is TextBox && string.IsNullOrWhiteSpace(((TextBox)control).Text))
                {
                    return false; // Devuelve falso si encuentra un TextBox vacio
                }
                else if (control is ComboBox && ((ComboBox)control).SelectedIndex == -1)
                {
                    return false; // Devuelve falso si encuentra un ComboBox sin seleccionar
                }

                // Verifica los controles secundarios de manera recursiva si es un contenedor
                if (control.Controls.Count > 0)
                {
                    if (!VerificarControlesLlenos(control.Controls))
                    {
                        return false;
                    }
                }
            }

            return true; // Todos los TextBox y ComboBox están llenos
        }

        public void asignarTextChanged()
        {
            //Por cada textbox se usara la funcion para añadirle el evento de TextChanged a
            foreach (Control control in this.Controls){
                 if(control is TextBox)
                {
                    TextBox txt = (TextBox)control;
                    if(string.IsNullOrWhiteSpace(txt.Text))txt.BackColor = Color.Tomato;
                    asociar_TextChanged((TextBox)txt);
                }
                 /*else if(control is ComboBox)
                {
                    ComboBox cmb = (ComboBox)control;
                    if(cmb.SelectedIndex == -1)cmb.BackColor = Color.Tomato;
                }*/
            }
        }

        public void asociar_TextChanged(TextBox textBox)
        {
            textBox.TextChanged += (sender, e) =>
            {
                // Verificar si el TextBox esta vacio
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    // Si esta vacío, cambiar el color a rojo
                    textBox.BackColor = Color.Tomato;
                }
                else
                {
                    // Si no esta vacio, restaurar el color predeterminado
                    textBox.BackColor = SystemColors.Window;
                }
            };
        }

        private void BtnAltaEmpleado_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            asignarTextChanged();
            bool controlesNoVacios = VerificarControlesLlenos(AltaEmpleado.ActiveForm.Controls);
            if (!controlesNoVacios)
            {
                MessageBox.Show("Hay campos vacios");
                return;
            }

            DialogResult response = MessageBox.Show("¿Estás seguro de continuar?. Posteriormente podrás editar al empleado." + claveCargada + "?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //Si la respuesta es no, se cancela la operacion
            if (response == DialogResult.No) return;
            MessageBox.Show("Actualizando datos..");
            EnviaAlta();
            Cursor.Current = Cursors.Default;
        }
        
        public void EnviaAlta()
        {
            string sqlString = "INSERT INTO Empleados (id, id_checador, nombre, nombres, apellido_paterno, apellido_materno, calle, no_exterior, no_interior, colonia, municipio, estado, cp, sexo, fecha_nacimiento, rfc, curp, genero, no_emergencia, fecha_ingreso, tipo_contrato, renovacion, area, puesto, turno, domingo, entrada, salida, sueldo_base, bono, porcentaje, dia_descanso, tarjeta, no_cuenta, nss, seguro, fecha_imss, sueldo_imss, anotaciones) VALUES (";
            sqlString = sqlString + "'" + textBoxClave.Text + "'" + ",";
            sqlString = sqlString + "'" + textBoxClaveChecador.Text + "'" + ",";
            sqlString = sqlString + "'" + textBoxNombre.Text + "'" + ",";
            sqlString = sqlString + "'" + textBoxNombre.Text + " " + textBoxPrimerA.Text + " " + textBoxSegundoA.Text + "'" + ",";
            sqlString = sqlString + "'" + textBoxPrimerA.Text + "'" + ",";
            sqlString = sqlString + "'" + textBoxSegundoA.Text + "'" + ",";
            sqlString = sqlString + "'" + textBoxCalle.Text + "'" + ",";
            sqlString = sqlString + "'" + textBoxNoExterior.Text + "'" + ",";
            sqlString = sqlString + "'" + textBoxNoInterior.Text + "'" + ",";
            sqlString = sqlString + "'" + textBoxColonia.Text + "'" + ",";
            sqlString = sqlString + "'" + textBoxMunicipio.Text + "'" + ",";
            sqlString = sqlString + "'" + textBoxEstado.Text + "'" + ",";
            sqlString = sqlString + "'" + textBoxCodigoPostal.Text + "'" + ",";
            sqlString = sqlString + "'" + comboBoxSexo.Text + "'" + ",";
            sqlString = sqlString + "'" + FormateaFechaNacimiento() + "'" + ",";
            sqlString = sqlString + "'" + textBoxRFC.Text + "'" + ",";
            sqlString = sqlString + "'" + textBoxCurp.Text + "'" + ",";
            sqlString = sqlString + "'" + comboBoxGenero.Text + "'" + ",";
            sqlString = sqlString + "'" + textBoxNoEmergencia.Text + "'" + ",";
            sqlString = sqlString + "'" + FormateaFechaIngreso() + "'" + ",";
            sqlString = sqlString + "'" + comboBoxTipoContrato.Text + "'" + ",";
            sqlString = sqlString + "'" + textBoxRenovacion.Text + "'" + ",";
            sqlString = sqlString + "'" + comboBoxArea.Text + "'" + ",";
            sqlString = sqlString + "'" + comboBoxPuesto.Text + "'" + ",";
            sqlString = sqlString + "'" + comboBoxTurno.Text + "'" + ",";
            sqlString = sqlString + "'" + comboBoxHoraEntradaDomingo.Text + ':' + comboBoxMinutoEntradaDomingo.Text + ':' + "00" + "'" + ",";
            sqlString = sqlString + "'" + comboBoxHoraEntrada.Text + ':' + comboBoxMinutosEntrada.Text + ':' + "00" +"'" + ",";
            sqlString = sqlString + "'" + comboBoxHoraSalida.Text + ':' + comboBoxMinutosSalida.Text + ':' + "00" + "'" + ",";
            sqlString = sqlString + "'" + textBoxSueldoBase.Text + "'" + ",";
            sqlString = sqlString + "'" + textBoxBono.Text + "'" + ",";
            sqlString = sqlString + "'" + textBoxPorcentaje.Text + "'" + ",";
            sqlString = sqlString + "'" + comboBoxDiaDescanso.Text + "'" + ',';
            sqlString = sqlString + "'" + comboBoxTarjeta.Text + "'" + ",";
            sqlString = sqlString + "'" + textBoxNoCuenta.Text + "'" + ",";
            sqlString = sqlString + "'" + textBoxNss.Text + "'" + ",";
            sqlString = sqlString + "'" + comboBoxSeguro.Text + "'" + ",";
            sqlString = sqlString + "'" + FormateaFechaImss() + "'" + ",";
            sqlString = sqlString + "'" + textBoxSueldoImss.Text + "'" + ',';
            sqlString = sqlString + "'" + textBoxAnotaciones.Text + "'";
            //sqlString = sqlString + "'" + textBoxNss.Text + "'" + ",";
            //sqlString = sqlString + "'" + comboBoxSeguro.Text + "'" + ",";
            //sqlString = sqlString + "'" + comboBoxDiaImss.Text + '/' + comboBoxMesImss.Text + '/' + comboBoxAñoImss.Text + "'" + ",";
            //sqlString = sqlString + "'" + textBoxSueldoImss.Text + "'";
            sqlString = sqlString + ")";
            using (var connection = new MySqlConnection(conexion))
            {
                try
                {
                    connection.Open();

                    MySqlCommand comando = new MySqlCommand(sqlString, connection);
                    comando.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show(" Se ha insertado ");
                    enviarCorreo("procesadornominastest@gmail.com", "Alta: " + textBoxNombre.Text);
                    limpiarControles();
                    obtenerID();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    MessageBox.Show("Ocurrio un error al enviar los datos \nVerifiquelos");
                }
            }
        }

        private void btnBusquedaClave_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            llenaCamposConConsulta(1);
            Cursor.Current = Cursors.Default;
        }

        private void btnBusquedaNombre_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            llenaCamposConConsulta(2);
            Cursor.Current = Cursors.Default;
        }

        //15/01/2024 mandar tambien el string a buscar
        //esta funcion sirve para hacer la consulta y llenar el formulario, depende de como se llame buscaremos por id o por nombre.
        public void llenaCamposConConsulta(int op)
        {
            Cursor.Current = Cursors.WaitCursor;
            string opcion = "";
            if (op == 1)
                opcion = "id";
            if (op == 2)
                opcion = "nombres";


            int flag = 0, indice = 0;
            using (var connection = new MySqlConnection(conexion))
            {
                try
                {
                    connection.Open();

                    string sqlString = "SELECT * FROM Empleados WHERE " + opcion + " = " + "'" + ((opcion == "nombres") ? textBoxBusquedaPorNombre.Text : textBoxClave.Text) + "'" + ";"; //con un operador ternario se evalua si la busqueda se hara por nombre o por clave
                    MySqlCommand comando = new MySqlCommand(sqlString, connection);
                    //Bandera para saber si se encontro almenos 1 consulta que coincida
                    flag = Convert.ToInt32(comando.ExecuteScalar());
                    if (flag == 1) MessageBox.Show(" Se ha encontrado al empleado ");
                    if (flag == 0)
                    {
                        MessageBox.Show("Este Empleado no está registrado");
                        return;
                    }

                    //mientras la opcion no sea ver empleado los botones se desbloquean
                    if (selectedOp != 4 && selectedOp !=2)DesbloqueaControles();
                    if(selectedOp == 2) btnBajaEmpleado.Enabled = true;
                    MySqlDataReader lector;
                    lector = comando.ExecuteReader();
                    if (lector.Read())
                    {
                        textBoxBusquedaPorNombre.Text = lector["nombres"].ToString();
                        textBoxClave.Text = lector["id"].ToString();
                        textBoxClaveChecador.Text = lector["id_checador"].ToString();
                        textBoxNombre.Text = lector["nombre"].ToString();
                        textBoxPrimerA.Text = lector["apellido_paterno"].ToString();
                        textBoxSegundoA.Text = lector["apellido_materno"].ToString();
                        textBoxNoExterior.Text = lector["no_exterior"].ToString();
                        textBoxNoInterior.Text = lector["no_interior"].ToString();
                        textBoxColonia.Text = lector["colonia"].ToString();
                        textBoxMunicipio.Text = lector["municipio"].ToString();
                        textBoxCalle.Text = lector["calle"].ToString();
                        textBoxEstado.Text = lector["estado"].ToString();
                        textBoxCodigoPostal.Text = lector["cp"].ToString();
                        comboBoxSexo.Text = lector["sexo"].ToString();
                        //El lector guarda la fecha para poder sacar con substring el dia mes y año
                        string preFechaN = lector["fecha_nacimiento"].ToString();
                        comboBoxDiaNacimiento.SelectedIndex = Convert.ToInt16(preFechaN.Substring(0, 2)) - 1;
                        comboBoxMesNacimiento.SelectedIndex = Convert.ToInt16(preFechaN.Substring(3, 2)) - 1; //el formato de la fecha en la base de datos es numerico, se asigna ese valor al index.
                        indice = comboBoxAñoNacimiento.Items.IndexOf(preFechaN.Substring(6, 4)) +1;
                        comboBoxAñoNacimiento.SelectedIndex = indice;
                        textBoxRFC.Text = lector["rfc"].ToString();
                        textBoxCurp.Text = lector["curp"].ToString();
                        comboBoxGenero.Text = lector["genero"].ToString();
                        textBoxNoEmergencia.Text = lector["no_emergencia"].ToString();
                        string preFechaI = lector["fecha_ingreso"].ToString();
                        comboBoxDiaIngreso.SelectedIndex = Convert.ToInt16(preFechaI.Substring(0, 2)) - 1;
                        comboBoxMesIngreso.SelectedIndex = Convert.ToInt16(preFechaI.Substring(3, 2)) -1 ;
                        indice = comboBoxAnioIngreso.Items.IndexOf(preFechaI.Substring(6, 4)) + 1;//compara en que posicion se encuentra el index que sea igual a la cadena.
                        comboBoxAnioIngreso.SelectedIndex = indice;
                        comboBoxTipoContrato.Text = lector["tipo_contrato"].ToString();
                        textBoxRenovacion.Text = lector["renovacion"].ToString();
                        comboBoxArea.Text = lector["area"].ToString();
                        comboBoxPuesto.Text = lector["puesto"].ToString();
                        comboBoxTurno.Text = lector["turno"].ToString();
                        string preEntradaD = lector["domingo"].ToString();
                        comboBoxMinutoEntradaDomingo.SelectedIndex = Convert.ToInt16(preEntradaD.Substring(3, 2));
                        comboBoxHoraEntradaDomingo.SelectedIndex = Convert.ToInt16(preEntradaD.Substring(0, 2)) ;
                        //comboBoxTurnoDomingo.SelectedIndex = (preEntradaD.Substring(6, 2) == "AM") ? 0 : 1; //Si el valor de la cadena sustraida de la cadena preEntradaD en este caso el turno, es AM entonces el index corresponde a 0 que es AM, si no, es 1 - PM
                        string preEntrada = lector["entrada"].ToString();
                        comboBoxHoraEntrada.SelectedIndex = Convert.ToInt16(preEntrada.Substring(0, 2));
                        comboBoxMinutosEntrada.SelectedIndex = Convert.ToInt16(preEntrada.Substring(3, 2));
                        //comboBoxTurnoEntrada.SelectedIndex = (preEntrada.Substring(6, 2) == "AM") ? 0 : 1;
                        string preSalida = lector["salida"].ToString();
                        comboBoxMinutosSalida.SelectedIndex = Convert.ToInt16(preSalida.Substring(3, 2));
                        comboBoxHoraSalida.SelectedIndex = Convert.ToInt16(preSalida.Substring(0, 2));
                        //comboBoxTurnoSalida.SelectedIndex = (preSalida.Substring(6, 2) == "AM") ? 0 : 1;
                        textBoxSueldoBase.Text = lector["sueldo_base"].ToString();
                        textBoxBono.Text = lector["bono"].ToString();
                        textBoxPorcentaje.Text = lector["porcentaje"].ToString();
                        comboBoxDiaDescanso.Text = lector["dia_descanso"].ToString();
                        comboBoxTarjeta.Text = lector["tarjeta"].ToString();
                        textBoxNoCuenta.Text = lector["no_cuenta"].ToString();
                        textBoxNss.Text = lector["nss"].ToString();
                        comboBoxSeguro.Text = lector["seguro"].ToString();
                        string preFechaImss = lector["fecha_imss"].ToString();
                        comboBoxDiaImss.SelectedIndex = Convert.ToInt16(preFechaImss.Substring(0, 2)) - 1;
                        comboBoxMesImss.SelectedIndex = Convert.ToInt16(preFechaImss.Substring(3, 2)) -1;
                        indice = comboBoxAñoImss.Items.IndexOf(preFechaImss.Substring(6, 4))+1;
                        comboBoxAñoImss.SelectedIndex = indice;
                        textBoxSueldoImss.Text = Convert.ToDecimal(lector["sueldo_imss"]).ToString(); //Se aplica la conversion a decimal para que no lo exprese en formato exponencial ya que el numero es grande
                        textBoxAnotaciones.Text = lector["anotaciones"].ToString();
                    }
                    claveCargada = Convert.ToInt32(textBoxClave.Text);
                    
                    connection.Close();
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void btnBajaEmpleado_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool controlesNoVacios = VerificarControlesLlenos(AltaEmpleado.ActiveForm.Controls);
            if (!controlesNoVacios)
            {
                MessageBox.Show("Hay campos vacios");
                return;
            }
            DialogResult response = MessageBox.Show("¿Estas seguro de dar de Baja \nal empleado con el id " + claveCargada + "?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (response == DialogResult.No) return;
            string sqlString = "INSERT INTO Bajas SELECT * FROM Empleados WHERE id = " + "'" + claveCargada + "';";
                
            sqlString += "DELETE FROM Empleados WHERE id = " + "'" + claveCargada + "'" + ";"; //con un operador ternario se evalua si la busqueda se hara por nombre o por clave
            using (var connection = new MySqlConnection(conexion))
            {
                try
                {
                    connection.Open();

                    MySqlCommand comando = new MySqlCommand(sqlString, connection);
                    comando.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("La baja se ha procesado correctamente");
                    limpiarControles();
                    btnBajaEmpleado.Enabled = false;
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            Cursor.Current = Cursors.Default;


        }

        private void textBoxBusquedaPorNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxClave_TextChanged(object sender, EventArgs e)
        {

            }
            
        private void label2_Click(object sender, EventArgs e)
        {

        }
            
        private void lblBusquedaNombre_Click(object sender, EventArgs e)
        {

        }

        private void btnActualizarEmpleado_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            asignarTextChanged();
            bool controlesNoVacios = VerificarControlesLlenos(AltaEmpleado.ActiveForm.Controls);
            if (!controlesNoVacios)
            {
                MessageBox.Show("Hay campos vacios");
                return;
            }

            DialogResult response = MessageBox.Show("¿Estas seguro de actualizar \nlos datos del empleado con el id " + claveCargada + "?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //Si la respuesta es no, se cancela la operacion
            if (response == DialogResult.No) return;
            MessageBox.Show("Actualizando datos..");
            string sqlString = "UPDATE Empleados Set nombre=" + "'" + textBoxNombre.Text + "'," + "nombres=" + "'" + textBoxNombre.Text + " " + textBoxPrimerA.Text + " " + textBoxSegundoA.Text + "'," + "id_checador=" + "'" + textBoxClaveChecador.Text + "'," + "apellido_paterno=" + "'" + textBoxPrimerA.Text + "'," + "apellido_materno=" + "'" + textBoxSegundoA.Text + "'," + "calle=" + "'" + textBoxCalle.Text + "'," + "no_exterior=" + "'" + textBoxNoExterior.Text + "'," + "no_interior=" + "'" + textBoxNoInterior.Text + "'," + "colonia=" + "'" + textBoxColonia.Text + "'," + "municipio=" + "'" + textBoxMunicipio.Text + "'," + "estado=" + "'" + textBoxEstado.Text + "'," + "cp=" + "'" + textBoxCodigoPostal.Text + "'," + "sexo=" + "'" + comboBoxSexo.Text + "'," + "fecha_nacimiento=" + "'" + FormateaFechaNacimiento() + "'," + "rfc=" + "'" + textBoxRFC.Text + "'," + "curp=" + "'" + textBoxCurp.Text + "'," + "no_emergencia=" + "'" + textBoxNoEmergencia.Text + "'," + "fecha_ingreso=" + "'" + FormateaFechaIngreso() + "'," + "genero=" + "'" + comboBoxGenero.Text + "'," + "nss=" + "'" + textBoxNss.Text + "'," + "seguro=" + "'" + comboBoxSeguro.Text + "'," + "fecha_imss=" + "'" + FormateaFechaImss() + "'," + "sueldo_imss=" + "'" + textBoxSueldoImss.Text + "'," + "tipo_contrato=" + "'" + comboBoxTipoContrato.Text + "'," + "renovacion=" + "'" + textBoxRenovacion.Text + "'," + "area=" + "'" + comboBoxArea.Text + "'," + "puesto=" + "'" + comboBoxPuesto.Text + "'," + "turno=" + "'" + comboBoxTurno.Text + "'," + "domingo=" + "'" + comboBoxHoraEntradaDomingo.Text + ':' + comboBoxMinutoEntradaDomingo.Text + ':' + "00" + "'," + "entrada=" + "'" + comboBoxHoraEntrada.Text + ':' + comboBoxMinutosEntrada.Text + ':' + "00" + "'," + "salida=" + "'" + comboBoxHoraSalida.Text + ':' + comboBoxMinutosSalida.Text + ':' + "00" + "'," + "sueldo_base=" + "'" + textBoxSueldoBase.Text + "'," + "bono=" + "'" + textBoxBono.Text + "'," + "porcentaje=" + "'" + textBoxPorcentaje.Text + "'," + "dia_descanso=" + "'" + comboBoxDiaDescanso.Text + "'," + "tarjeta=" + "'" + comboBoxTarjeta.Text + "'," + "no_cuenta=" + "'" + textBoxNoCuenta.Text + "'," + "anotaciones=" + "'" + textBoxAnotaciones.Text + "' " + "WHERE id = " + claveCargada + ";";
            using (var connection = new MySqlConnection(conexion))
            {
                try
                {
                    connection.Open();

                    MySqlCommand comando = new MySqlCommand(sqlString, connection);
                    comando.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show(" Se han actualizado los datos correctamente ");
                    llenaCamposConConsulta(1);
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
