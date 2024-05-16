using MySql.Data.MySqlClient;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProcesadorNominaas
{
    public partial class Procesador : Form
    {
        //conexion a base de datos.
        string conexion = ("Server=monorail.proxy.rlwy.net;Port=15455;Database=railway;Uid=root;password=HBFHC45b5A2BE4a552G-Cf13AeEA-DFE;");
        string sucursal = "";
        //lista de empleados obtenidos de la base de datos.
        List<Empleado> empleadosBdd = new List<Empleado>();

        //lista de empleados que no están registrados en la base de datos pero si en el checador.
        List<Empleado> noRegistrados = new List<Empleado>();


        string ruta;

        //VARIABLES GLOBALES.


        bool invalido = true;

        public Procesador(string sucursal)
        {
            InitializeComponent();
            this.sucursal = sucursal;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void BtnDeleteRutaLunes_Click(object sender, EventArgs e)
        {
            TxtBoxRutaLunes.Text = "";
        }

        public bool ValidaVacio()
        {
            if(TxtBoxRutaLunes.Text == "")
            {
                MessageBox.Show("Ruta vacia, asigna un archivo a procesar");
                return false;
            }
            return true;
        }

        private void BtnProcesar_Click(object sender, EventArgs e)
        {
            DataGridNoRegistrados.Visible = false;
            DataGridNoRegistrados.DataSource = null;
            LblNoRegistrados.Visible = false;
            invalido = true;
            string fecha = "";
            string dia = "";
            //validamos que el textbox de ruta no este vacio
            invalido = ValidaVacio();
            Cursor.Current = Cursors.WaitCursor;
            //aqui ocurre el procesamiento.
            if (invalido)
            {
                empleadosBdd.Clear();
                noRegistrados.Clear();
                //primero cargamos los empleados desde la base de datos.
                CargaEmpleadosBdd();
                //cargo el archivo de checadas y asigno a cada empleado sus checadas.
                ProcesaExcel(TxtBoxRutaLunes.Text);
                //Obtengo fecha.
                fecha = ObtenFecha();
                dia = ObtenDia(fecha);
                dia = ConvierteDiaEsp(dia);
                //Les asigno sus excepciones en caso de que existan.
                CargaExcepciones(fecha);
                DialogResult result = MessageBox.Show("Se va a procesar el dia: (" + dia + ").  " + fecha + "." + " ¿Deseas Continuar?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // El usuario hizo clic en "Sí".


                    //validar que su dia anterior se encuentre procesado a menos que sea viernes.
                    if(dia == "VIERNES")
                    {
                        bool existe = BuscarFecha(fecha);
                        if (existe)
                        {
                            DialogResult result2 = MessageBox.Show("El dia: (" + dia + ").  " + fecha + ". Ya fue procesado." + " ¿Deseas Procesarlo de nuevo? Se eliminaran los registros que ya estaban en ese día y todos los días posteriores de esa semana", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result2 == DialogResult.Yes)
                            {
                                //eliminamos los registros anteriormente procesados con ese dia y posteriores.
                                ReiniciaDescansos();
                                bool band = EliminaRegistros(fecha, dia);


                                if (band)
                                    ProcesaLista(fecha);
                            }
                        }
                        else
                        {
                            ProcesaLista(fecha);
                        }
                    }
                    else
                    {
                        bool seProceso = SeProcesoAnterior(fecha);
                        if(seProceso)
                        {
                            //asi resuelvo  la entrada al domingo.
                            if (dia == "DOMINGO")
                                CambiaADomingo();
                            bool existe = BuscarFecha(fecha);
                            if (existe)
                            {
                                DialogResult result2 = MessageBox.Show("El dia: (" + dia + ").  " + fecha + ". Ya fue procesado." + " ¿Deseas Procesarlo de nuevo? Se eliminaran los registros que ya estaban en ese día y todos los días posteriores de esa semana", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (result2 == DialogResult.Yes)
                                {
                                    //eliminamos los registros anteriormente procesados con ese dia 
                                    bool band = EliminaRegistros(fecha, dia);


                                    if (band)
                                        ProcesaLista(fecha);
                                }
                            }
                            else
                            {
                                ProcesaLista(fecha);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se ha procesado el dia anterior, primero procesa el dia anterior, y luego vuelve a procesar este dia: (" + dia + "). " + fecha +".");
                        }
                    }


                }
            }
            Cursor.Current = Cursors.Arrow;

        }

        public void CambiaADomingo()
        {
            foreach (Empleado empleado in empleadosBdd)
                empleado.Entrada = empleado.EntradaDomingo;
        }

        public bool SeProcesoAnterior(string fecha)
        {
            DateTime fechaAux = DateTime.Parse(fecha);
            fechaAux = fechaAux.AddDays(-1);
            bool existe = false;
            string fecha2 = fechaAux.Year.ToString() + "-" + fechaAux.Month.ToString() + "-" + fechaAux.Day.ToString();
            using (var connection = new MySqlConnection(conexion))
            {
                try
                {
                    connection.Open();
                    var query = $"SELECT COUNT(*) FROM " + sucursal + ".Dias WHERE fecha =" + '"' + fecha2 + '"';
                    int a = 0;
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        existe = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show($"Ocurrió un error al buscar el registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return existe;

        }

        public void ReiniciaDescansos()
        {
            using (var connection = new MySqlConnection(conexion))
            {
                try
                {
                    connection.Open();
                    var query = $"UPDATE Normandia.Empleados SET perdio_descanso = 'NO' where id > 0";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error, intenta de nuevo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void ProcesaLista(string fecha)
        {
            for (int i = 0; i < empleadosBdd.Count; i++)
            {
                empleadosBdd[i].Fecha = fecha;
                ProcesaEmpleado(empleadosBdd[i], fecha);
                InsertaCambios(empleadosBdd[i]);
            }
            if (noRegistrados.Count > 0)
            {
                ColumnasNoRegistrados();
            }
        }
        
        public bool EliminaRegistros(string fecha, string dia)
        {

            //obtener numero actual
            int numeroDia = DaNumeroDia(dia);
            int numeroJueves = DaNumeroDia("JUEVES");
            int diferencia = numeroJueves - numeroDia;
            //ver cuanto falta para el jueves.
            bool correcto = false;
            using (var connection = new MySqlConnection(conexion))
            {
                try
                {
                    connection.Open();
                    var query = $"DELETE FROM " + sucursal + ".Dias WHERE fecha = " + '"' +  fecha + '"' + " AND id_empleado > 0";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                    correcto = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error, intenta de nuevo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            DateTime fechaAux = DateTime.Parse(fecha);
            for (int i = 0; i <diferencia; i++)
            {
                fechaAux = fechaAux.AddDays(+1);
                using (var connection = new MySqlConnection(conexion))
                {
                    try
                    {
                        connection.Open();
                        var query = $"DELETE FROM " + sucursal + ".Dias WHERE fecha = " + '"' + fechaAux.Year.ToString() + "-" + fechaAux.Month.ToString() + "-" + fechaAux.Day.ToString() +  '"' + " AND id_empleado > 0";
                        using (var cmd = new MySqlCommand(query, connection))
                        {
                            MySqlCommand command = new MySqlCommand(query, connection);
                            command.ExecuteNonQuery();
                        }
                        connection.Close();
                        correcto = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocurrió un error, intenta de nuevo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            //hace un addday con while para eliminar todos. 
            return correcto;
        }

        public void ColumnasNoRegistrados()
        {
            DataGridNoRegistrados.DataSource = noRegistrados;
            DataGridNoRegistrados.Visible = true;
            LblNoRegistrados.Visible = true;
            DataGridNoRegistrados.Columns.Remove("nombre");
            DataGridNoRegistrados.Columns.Remove("entrada");
            DataGridNoRegistrados.Columns.Remove("salidaEsperada");
            DataGridNoRegistrados.Columns.Remove("entradaDomingo");
            DataGridNoRegistrados.Columns.Remove("sueldo");
            DataGridNoRegistrados.Columns.Remove("bono");
            DataGridNoRegistrados.Columns.Remove("porcentaje");
            DataGridNoRegistrados.Columns.Remove("descanso");
            DataGridNoRegistrados.Columns.Remove("sucursal");
            DataGridNoRegistrados.Columns.Remove("asistencia");
            DataGridNoRegistrados.Columns.Remove("retardo");
            DataGridNoRegistrados.Columns.Remove("turnoExtra");
            DataGridNoRegistrados.Columns.Remove("turnoExtraPaga");
            DataGridNoRegistrados.Columns.Remove("descansoTrabajado");
            DataGridNoRegistrados.Columns.Remove("anotaciones");
            DataGridNoRegistrados.Columns.Remove("incidencia");
            DataGridNoRegistrados.Columns.Remove("horasTrabajadas");
            DataGridNoRegistrados.Columns.Remove("comida");
            DataGridNoRegistrados.Columns.Remove("totalPagado");
            DataGridNoRegistrados.Columns.Remove("salida");
            DataGridNoRegistrados.Columns.Remove("fecha");
            DataGridNoRegistrados.Columns.Remove("id");
            DataGridNoRegistrados.Columns.Remove("sueldoImss");
            DataGridNoRegistrados.Columns.Remove("turno");
            DataGridNoRegistrados.Columns.Remove("estatus");
            DataGridNoRegistrados.Columns.Remove("perdioDescanso");
            DataGridNoRegistrados.Columns.Remove("pagoDiario");
            DataGridNoRegistrados.Columns["idChecador"].Width = 100;
            DataGridNoRegistrados.Columns["nombreExcel"].Width = 300;
            DataGridNoRegistrados.Columns["horaEntrada"].Width = 250;
            DataGridNoRegistrados.Columns["horaSalida"].Width = 250;
        }

        public bool BuscarFecha(string fecha)
        {
                bool existe = false;
                using (var connection = new MySqlConnection(conexion))
                {
                    try
                    {
                        connection.Open();
                        var query = $"SELECT COUNT(*) FROM " + sucursal + ".Dias WHERE fecha =" + '"' + fecha + '"';
                        int a = 0;
                            using (var cmd = new MySqlCommand(query, connection))
                            {
                                existe = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                            }
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show($"Ocurrió un error al buscar el registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                return existe;
        }

        public string ObtenDia(string fecha)
        {
            DateTime fechaAux = new DateTime();

            try
            {
                fechaAux = DateTime.Parse(fecha);
            }
            catch
            {
                invalido = false;
                MessageBox.Show("El archivo no se puede procesar, revisar que el contenido se encuentre en el formato adecuado.");
            }
            string dia = fechaAux.DayOfWeek.ToString();
            return dia;

        }

        public void InsertaCambios(Empleado empleado)
        {
            string sqlString = "INSERT INTO " + sucursal + ".Dias (id_empleado,fecha,asistencia,retardo,salida,turno_extra,turno_extra_paga,total,incidencia,descanso_trabajado,anotaciones,horas_trabajadas,hora_llegada,sueldo_diario,hora_salida) VALUES (";
            sqlString = sqlString + "'" + empleado.IdChecador + "'" + ",";
            sqlString = sqlString + "'" + empleado.Fecha + "'" + ",";
            sqlString = sqlString + "'" + empleado.Asistencia + "'" + ",";
            sqlString = sqlString + "'" + empleado.Retardo + "'" + ",";
            sqlString = sqlString + "'" + empleado.Salida + "'" + ",";
            sqlString = sqlString + "'" + empleado.TurnoExtra + "'" + ",";
            sqlString = sqlString + "'" + empleado.TurnoExtraPaga + "'" + ",";
            sqlString = sqlString + "'" + empleado.TotalPagado + "'" + ",";
            sqlString = sqlString + "'" + empleado.Incidencia + "'" + ",";
            sqlString = sqlString + "'" + empleado.DescansoTrabajado + "'" + ",";
            sqlString = sqlString + "'" + empleado.Anotaciones + "'" + ",";
            sqlString = sqlString + "'" + empleado.HorasTrabajadas + "'" + ","; // Corregido typo: de "hoars_trabajadas" a "HorasTrabajadas"
            sqlString = sqlString + "'" + empleado.HoraEntrada + "'" + ",";
            sqlString = sqlString + "'" + empleado.PagoDiario + "'" + ",";
            sqlString = sqlString + "'" + empleado.HoraSalida + "'"; // Último valor, no lleva coma al final
            sqlString = sqlString + ");"; // Cerramos la sentencia SQL
            using (var connection = new MySqlConnection(conexion))
            {
                try
                {
                    connection.Open();

                    MySqlCommand comando = new MySqlCommand(sqlString, connection);
                    comando.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

        }


        //cargar base de datos a memoria dinamica.
        public void CargaEmpleadosBdd()
        {
            using (var connection = new MySqlConnection(conexion))
            {
                try
                {
                    connection.Open();
                    MySqlDataAdapter adaptador = new MySqlDataAdapter("SELECT * FROM "+ sucursal +".Empleados", connection);
                    DataTable datos = new DataTable();
                    adaptador.Fill(datos);

                    //aqui obtenemos a los empleados de la base de datos y los almacenamos en una lista en memoria dinamica

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        Empleado auxiliar = new Empleado();
                        auxiliar.IdChecador = int.Parse(datos.Rows[i]["id_checador"].ToString());
                        auxiliar.Nombre = datos.Rows[i]["nombres"].ToString();
                        auxiliar.Entrada = datos.Rows[i]["entrada"].ToString();
                        auxiliar.SalidaEsperada = datos.Rows[i]["salida"].ToString();
                        auxiliar.EntradaDomingo = datos.Rows[i]["domingo"].ToString();
                        auxiliar.Sueldo = float.Parse(datos.Rows[i]["sueldo_base"].ToString());
                        auxiliar.Bono = int.Parse(datos.Rows[i]["bono"].ToString());
                        auxiliar.Porcentaje = int.Parse(datos.Rows[i]["porcentaje"].ToString());
                        auxiliar.Descanso = datos.Rows[i]["dia_descanso"].ToString();
                        auxiliar.PerdioDescanso = datos.Rows[i]["perdio_descanso"].ToString();

                        empleadosBdd.Add(auxiliar);
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }


        //carga excepciones
        public void CargaExcepciones(string fecha)
        {
            DateTime fechaFiltrar = new DateTime();
            fechaFiltrar = DateTime.Parse(fecha);
            using (var connection = new MySqlConnection(conexion))
            {
                try
                {
                    connection.Open();
                    string query = $"SELECT * FROM {sucursal}.Excepciones WHERE fecha = '{fechaFiltrar.Year}-{fechaFiltrar.Month}-{fechaFiltrar.Day}' ";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable data = new DataTable();
                    adapter.Fill(data);

                    // Iterar sobre cada fila de la tabla de excepciones
                    foreach (DataRow row in data.Rows)
                    {
                        int idEmpleadoExcepcion = Convert.ToInt32(row["id_empleado"]);
                        string categoria = row["categoria"].ToString();

                        // Verificar si el ID del empleado está en la lista
                        foreach (Empleado empleado in empleadosBdd)
                        {
                            if(empleado.IdChecador == idEmpleadoExcepcion)
                            {
                                empleado.Asistencia = categoria;
                            }
                        }  
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        public void ProcesaExcel(string ruta)
        {
            /// <summary>
            /// Using Microsoft.Office.Interop to convert XLS to XLSX format, to work with EPPlus library
            /// </summary>
            /// <param name="filesFolder"></param>
            var app = new Microsoft.Office.Interop.Excel.Application();
            var xlsFile = ruta;
            var workbooks = app.Workbooks;
            var workbook = workbooks.Open(xlsFile);
            var xlsxFile = xlsFile + "x";

            workbook.SaveAs(Filename: xlsxFile, FileFormat: Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook);
            workbook.Close();
            app.Quit();

            Marshal.ReleaseComObject(workbook);
            Marshal.ReleaseComObject(workbooks);
            Marshal.ReleaseComObject(app);

            FileStream excelStream = new FileStream(xlsxFile, FileMode.Open, FileAccess.Read);
            var book = new XSSFWorkbook(excelStream);
            excelStream.Close();

            var sheet = book.GetSheetAt(0);
            var headerRow = sheet.GetRow(0);
            var rowCount = sheet.LastRowNum;
            for (int i = sheet.FirstRowNum + 1; i < rowCount + 1; i++)
            {
                //trabajar aqui
                var row = sheet.GetRow(i);
                if (row != null)
                {

                    int claveChecador = int.Parse(row.Cells[0].RichStringCellValue.String);
                    //ahora que tenemos la clave del checador, se buscara al empleado correspondiente en la base de datos.
                    Empleado auxiliar = EncuentraEmpleado(claveChecador);
              
                    //obtenemos los datos del archivo
                    string nombre = row.Cells[1].RichStringCellValue.String;
                    string tiempo = row.Cells[2].RichStringCellValue.String;
                    //estado es entrada o salida
                    string estado = row.Cells[3].RichStringCellValue.String;
                    string dispositvos = row.Cells[4].RichStringCellValue.String;


                    if (estado == "Entrada" && auxiliar.HoraEntrada == "0")
                    {
                        auxiliar.NombreExcel = nombre;
                        auxiliar.HoraEntrada = tiempo;
                        auxiliar.Sucursal = dispositvos;
                    }
                    else if (estado == "Salida" && auxiliar.HoraSalida == "0")
                    {
                        auxiliar.HoraSalida = tiempo;
                        auxiliar.NombreExcel = nombre;
                        auxiliar.Sucursal = dispositvos;
                    }

                }
            }

            File.Delete(xlsxFile);

        }



        //helpers prrocesa excel

        //metodo para encontrar empleado de la base de datos con los empleados obtenidos del checador. 
        public Empleado EncuentraEmpleado(int claveChecador)
        {
            //aqui se busca el empleado en la base de datos
            for (int i = 0; i < empleadosBdd.Count; i++)
            {
                if (empleadosBdd[i].IdChecador == claveChecador)
                {
                    return empleadosBdd[i];
                }
            }
            //aqui se busca en los no registrados
            for(int i = 0; i < noRegistrados.Count; i++)
            {
                if (noRegistrados[i].IdChecador == claveChecador)
                {
                    return noRegistrados[i];
                }
            }
            Empleado aux = new Empleado();
            aux.IdChecador = claveChecador;
            noRegistrados.Add(aux);
            return aux;
        }


        //metodo para procesar el empleado.
        public void ProcesaEmpleado( Empleado empleado, string fecha)
        {
            empleado.Asistencia = ObtenAsistencia(empleado, fecha);
            empleado.DescansoTrabajado = ObtenDescansoTrabajado(empleado);
            if (empleado.Asistencia == "Asistió" || empleado.DescansoTrabajado == "SI")
            {
                empleado.Salida = ObtenSalida(empleado);
                empleado.Retardo = ObtenRetardo(empleado);
                empleado.TurnoExtra = ObtenTurnoExtraComida(empleado);
                empleado.TurnoExtraPaga = ObtenTurnoExtraPaga(empleado);
                empleado.TotalPagado = ObtenTotalPagado(empleado);
                empleado.HorasTrabajadas = ObtenHorasTrabajadas(empleado);
                
            }
            //horas trabaadas y comida ya se obtuvieron.
            //Incidencia
            //anotaciones
        }

        //metodos para procesar empleado

        public string ObtenHorasTrabajadas(Empleado empleado)
        {
            TimeSpan HoraLlegada = TimeSpan.Parse(empleado.HoraEntrada.ToString());
            TimeSpan HoraSalida = TimeSpan.Parse(empleado.HoraSalida.ToString());
            TimeSpan diferencia = HoraLlegada - HoraSalida;
            return diferencia.ToString(@"hh\:mm\:ss");
        }


        public string ObtenDescansoTrabajado(Empleado empleado)
        {
            if (Descansa(empleado.Fecha, empleado.Descanso))
            {
                if(empleado.HoraSalida != "0" || empleado.HoraEntrada != "0")
                {
                    return "SI";
                }
            }
            return "NO";
        }

        public string ObtenTotalPagado(Empleado empleado)
        {

            if(empleado.Asistencia == "Faltó")
            {
                empleado.TotalPagado = "0";
            }

            if(empleado.Asistencia == "Asistió"  || empleado.DescansoTrabajado == "SI")
            {
                empleado.TotalPagado = (empleado.Sueldo / 7).ToString();
                empleado.TotalPagado = double.Parse(empleado.TotalPagado).ToString();
            }
            empleado.TotalPagado = (double.Parse(empleado.TotalPagado) + double.Parse(empleado.Comida) + double.Parse(empleado.TurnoExtraPaga)).ToString();

            return empleado.TotalPagado;
        }

        public string ObtenTurnoExtraPaga(Empleado empleado)
        {
            if(empleado.TurnoExtra == "SI")
            {
                float pagaTurnoExtra = 0;
                pagaTurnoExtra = (float)(empleado.Sueldo / 7 * empleado.Porcentaje/100);
                return pagaTurnoExtra.ToString();
            }
            return "0";
        }
        
        public string ObtenTurnoExtraComida(Empleado empleado)
        {
            if(empleado.HoraEntrada != "0" && empleado.HoraSalida != "0")
            {
                DateTime entrada = new DateTime();
                DateTime salida = new DateTime();
                entrada = DateTime.Parse(empleado.HoraEntrada);
                salida = DateTime.Parse(empleado.HoraSalida);
                TimeSpan diferencia = salida.TimeOfDay - entrada.TimeOfDay;
                empleado.HorasTrabajadas = diferencia.ToString();
                //Procesar con variable de hora el turno extra.
                if (diferencia.TotalHours > 13.3)
                {
                    return "SI";
                }
            }
            return "NO";
        }

        public string ObtenRetardo(Empleado empleado)
        {
            DateTime horario = new DateTime();
            DateTime horaLlegada = new DateTime();
            DateTime horaSalida = new DateTime();
            horario = DateTime.Parse(empleado.Entrada);
            horaLlegada = DateTime.Parse(empleado.HoraEntrada);
            horaSalida = DateTime.Parse(empleado.HoraSalida);
            //aprovecho para sacar entrada y salida en horas
            empleado.HoraEntrada = horaLlegada.TimeOfDay.ToString();
            empleado.HoraSalida = horaSalida.TimeOfDay.ToString();
            if (empleado.Asistencia == "Asistió" || empleado.DescansoTrabajado == "SI" )
            {
                if (empleado.HoraEntrada == "0")
                    return "SI";



                TimeSpan diferencia = horaLlegada.TimeOfDay - horario.TimeOfDay;

                if (diferencia.Minutes > 5)
                    return "SI";

            }
            return "NO";
        }

        public string ObtenSalida(Empleado empleado)
        {
            if(empleado.Asistencia == "Asistió" || empleado.DescansoTrabajado == "SI")
            {
                if (empleado.HoraSalida == "0")
                    return "SI";
                return "NO";
            }
            return "NO";
        }


        public string ObtenFecha()
        {
            for(int i = 0; i < empleadosBdd.Count; i++)
            {
                if (empleadosBdd[i].HoraEntrada != "0")
                {
                    DateTime fecha = new DateTime();
                    fecha = DateTime.Parse(empleadosBdd[i].HoraEntrada);
                    string fecha2 = fecha.Year.ToString() + "-" + fecha.Month.ToString() + "-" + fecha.Day.ToString();
                    return fecha2;
                }
            }
            return "0";
        }

        public string ObtenAsistencia(Empleado empleado, string fecha)
        {
            //tambien aqui aprovechamos para hacer el pago diario. descanso no genera un pago. 
            if (Descansa(empleado.Fecha, empleado.Descanso))
                return "Descansó";

            string asistencia = "";
            if (empleado.Asistencia != "")
                asistencia = empleado.Asistencia;
            if (empleado.HoraEntrada != "0" && empleado.HoraSalida != "0")
            if (empleado.HoraEntrada != "0" && empleado.HoraSalida != "0")
            {
                asistencia = "Asistió";
                    //aqui evaluar que nos va a generar pago diario. 
                empleado.PagoDiario = empleado.Sueldo / 7;
                return asistencia;
            }
            //aqui vamos a procesar permisos licencias etc hay que hacerle un pago diario siempre que asista o este en licencia.
            if(empleado.Asistencia == "Vacacion")
            {
                empleado.PagoDiario = empleado.Sueldo / 7;
                return asistencia;
            }

            if (empleado.Asistencia != "")
                return asistencia;
            /*if (empleado.PerdioDescanso != "SI")
                ProcesaFalta(empleado, fecha);*/
            return "Faltó";
        }

        public void ProcesaFalta(Empleado empleado, string fecha)
        {
            //ahorita no se usa
            //actualiza que perdio descanso en empleados.
            PerdioDescanso(empleado);
            //revisa si ya descansó y modifica su trabajo descanso a no repuso en caso de que no haya trabajado, y si trabajo descanso modifica a repuso.
            YaDescanso(empleado, fecha);



           //posteriormente en descansó hacer validaciones
        }

        public void YaDescanso(Empleado empleado,string fecha)
        {
            DateTime fechaAux = DateTime.Parse(fecha);

            int numeroDescanso = DaNumeroDia(empleado.Descanso);
            int numeroFecha = DaNumeroDia(fechaAux.DayOfWeek.ToString());

            if (numeroFecha - numeroDescanso >= 0)
            {
                //OBTENGO EL DIA DE DESCANSO DE ACUERDO A LA FECHA QUE SE PROCESA, OSEA ESA SEMANA
                int diferencia = RetornaDiferencia(numeroDescanso, numeroFecha);
                //LA CONVIERTO Y ASI YA PODRIA EDITARLO. 
                fechaAux = fechaAux.AddDays(diferencia);
                //AHORA VOY A HACER UN METODO PARA EDITAR EL PAGO TOTAL Y MODIFICAR EL TRABAJO DESCANSO.
                ModificaDescanso(fechaAux, empleado);
                int a = 0;
            }
            //si no ha descansado no hariamos nada





        }


        //fecha que se está procesando, obtengo la diferencia para poder obtener el descanso de esa semana y hacer los ajustes.
        public int RetornaDiferencia(int numeroDia, int numeroHoy)
        {
            int contador = 0;
            if (numeroDia > numeroHoy)
            {
                int numeroDiaAux = numeroDia;
                int numeroHoyAux = numeroHoy;
                while (numeroHoyAux != numeroDiaAux)
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
            return contador;
        }

        public string ConvierteDiaEsp(string descanso)
        {
            if (descanso == "Monday")
                return "LUNES";
            if (descanso == "Tuesday")
                return "MARTES";
            if (descanso == "Wednesday")
                return "MIERCOLES";
            if (descanso == "Thursday")
                return "JUEVES";
            if (descanso == "Friday")
                return "VIERNES";
            if (descanso == "Saturday")
                return "SABADO";
            if (descanso == "Sunday")
                return "DOMINGO";
            return descanso;
        }
        public string ConvierteDia(string descanso)
        {
            if (descanso == "LUNES")
                return "Monday";
            if (descanso == "MARTES")
                return "Tuesday";
            if (descanso == "MIERCOLES")
                return "Wednesday";
            if (descanso == "JUEVES")
                return "Thursday";
            if (descanso == "VIERNES")
                return "Friday";
            if (descanso == "SABADO")
                return "Saturday";
            if (descanso == "DOMINGO")
                return "Sunday";
            return descanso;
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
        int DaNumeroDia(string dia)
        {
            string diaAux = ConvierteDia(dia);
            return AsignaNumero(diaAux);
        }


        public void ModificaDescanso(DateTime Descanso, Empleado empleado)
        {
            string fecha = ObtenFechaDescanso(Descanso);
            try
            {
                //OBTENER EL DIA PARA EVALUARLO.
                using (var connection = new MySqlConnection(conexion))
                {
                    connection.Open();

                    string selectQuery = "SELECT asistencia, descanso_trabajado, total, sueldo_diario FROM " + sucursal + ".Dias WHERE id_empleado = " + empleado.IdChecador + " AND fecha = " + '"' + fecha + '"';
                    MySqlCommand selectCommand = new MySqlCommand(selectQuery, connection);
                    Dia dia = new Dia();
                    // Ejecuta el select y obtén un lector de datos
                    using (MySqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        // Itera a través de las filas del resultado
                        while (reader.Read())
                        {
                            // Crea un nuevo objeto y asigna los valores de las columnas
                            dia.Id = empleado.IdChecador;
                            dia.DescansoTrabajado = reader["descanso_trabajado"].ToString();
                            dia.Total = Convert.ToSingle(reader["total"]);
                            dia.SueldoDiario = Convert.ToSingle(reader["sueldo_diario"]);

                        }
                    }

                    ProcesaDescanso(dia);


                    // Realiza tu operación de update
                    string query = "UPDATE " + sucursal + ".Dias SET total = " + dia.Total.ToString() +  ", descanso_trabajado = " + "'" + dia.DescansoTrabajado.ToString() + "'" + " WHERE id_empleado = " + dia.Id + " AND fecha = " + '"' + fecha + '"';
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            //SEGUIR AQUI.
            string ObtenFechaDescanso(DateTime descanso)
            {
                return descanso.Year.ToString() + "-" + descanso.Month.ToString() + "-" + descanso.Day.ToString() ;
            }

            void ProcesaDescanso(Dia dia)
            {
                if (dia.DescansoTrabajado.ToString() == "NO")
                {
                    dia.DescansoTrabajado = "NO REPUSO";
                }
                else if (dia.DescansoTrabajado.ToString() == "SI")
                {
                    dia.DescansoTrabajado = "REPUSO";
                }

            }

        }

        public void PerdioDescanso(Empleado empleado)
        {
            using (var connection = new MySqlConnection(conexion))
            {
                try
                {
                    connection.Open();
                    var query = $"UPDATE " + sucursal + ".Empleados SET perdio_descanso = 'SI' WHERE id_checador = " + empleado.IdChecador;
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error, intenta de nuevo (perdio desanso)." + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        public bool Descansa(string fecha, string descanso)
        {
            DateTime fechaHoy = new DateTime();
            fechaHoy = DateTime.Parse(fecha);
            string descansoAux = ConvierteDescanso(descanso);

            if(descansoAux == fechaHoy.DayOfWeek.ToString())
            {
                return true;
            }

            return false;
        }

        public string ConvierteDescanso(string descanso)
        {
            if (descanso == "LUNES")
                return "Monday";
            if (descanso == "MARTES")
                return "Tuesday";
            if (descanso == "MIERCOLES")
                return "Wednesday";
            if (descanso == "JUEVES")
                return "Thursday";
            if (descanso == "VIERNES")
                return "Friday";
            if (descanso == "SABADO")
                return "Saturday";
            if (descanso == "DOMINGO")
                return "Sunday";
            return "0";
        }

        private void Procesador_Load(object sender, EventArgs e)
        {

        }

        private void BtnCargaLunes_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDia = new OpenFileDialog();
            if (openFileDia.ShowDialog() == DialogResult.OK)
            {
                string extension = Path.GetExtension(openFileDia.FileName);

                if (extension != ".xls")
                {
                    MessageBox.Show("La extensión del archivo no es válida. Por favor, selecciona un archivo con extensión .xls.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ruta = openFileDia.FileName;
                    TxtBoxRutaLunes.Text = ruta;
                }

            }
        }
    }
}
