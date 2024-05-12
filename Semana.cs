using MySql.Data.MySqlClient;
using NPOI.HSSF.Record.Chart;
using NPOI.OpenXmlFormats.Dml;
using NPOI.OpenXmlFormats.Dml.Chart;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using static NPOI.HSSF.Util.HSSFColor;

namespace ProcesadorNominaas
{
    public partial class Semana : Form
    {

        string conexion = ("Server=monorail.proxy.rlwy.net;Port=15455;Database=railway;Uid=root;password=HBFHC45b5A2BE4a552G-Cf13AeEA-DFE;");
        string sucursal = "";

        public Semana(string sucursal)
        {
            InitializeComponent();
            this.sucursal = sucursal;
        }

        private void DataGridSemana_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica si el clic ocurrió en la columna de botón
            if (e.ColumnIndex == DataGridSemana.Columns["Modificar"].Index && e.RowIndex >= 0)
            {

                MessageBox.Show("Introduce la contraseña" + e.RowIndex);

                DataGridSemana.Rows[e.RowIndex].ReadOnly = false;
                DataGridSemana.Refresh();   

            }
            // Verifica si el clic ocurrió en la columna de botón
            if (e.ColumnIndex == DataGridSemana.Columns["Guardar"].Index && e.RowIndex >= 0)
            {

                MessageBox.Show("Se guardaron los cambios");

                DataGridSemana.Rows[e.RowIndex].ReadOnly = false;
                DataGridSemana.Refresh();

            }
            if (e.ColumnIndex == DataGridSemana.Columns["Guardar"].Index && e.RowIndex >= 0)
            {

                MessageBox.Show("Se cancelaron los cambios");

                DataGridSemana.Rows[e.RowIndex].ReadOnly = false;
                DataGridSemana.Refresh();

            }
        }

        public void myDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            // Asumiendo que quieres cambiar el color en la columna con índice 0
            /*
            if (e.ColumnIndex == 4)
            {
                var cellValue = e.Value; // Obtienes el valor de la celda

                // Aquí aplicas la condición deseada, en este ejemplo, cambiar si el valor es específico
                if (cellValue != null && cellValue.ToString() == "SI")
                {
                    // Cambia el color del texto a rojo
                    e.CellStyle.ForeColor = Color.Red;

                }
            }*/
            DataGridViewButtonColumn c = (DataGridViewButtonColumn)DataGridSemana.Columns["Modificar"];
            c.FlatStyle = FlatStyle.Popup;
            c.DefaultCellStyle.ForeColor = Color.Navy;
            c.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            c.Text = "M";
            c = (DataGridViewButtonColumn)DataGridSemana.Columns["Guardar"];
            c.FlatStyle = FlatStyle.Popup;
            c.DefaultCellStyle.ForeColor = Color.Navy;
            c.DefaultCellStyle.BackColor = Color.Gainsboro;
            c.Text = "G";
            c = (DataGridViewButtonColumn)DataGridSemana.Columns["Cancelar"];
            c.FlatStyle = FlatStyle.Popup;
            c.DefaultCellStyle.ForeColor = Color.Navy;
            c.DefaultCellStyle.BackColor = Color.Gainsboro;
            c.Text = "C";


            //colores headers.
            DataGridSemana.EnableHeadersVisualStyles = false;
            DataGridSemana.Columns["totalPagado2"].HeaderCell.Style.BackColor = Color.LimeGreen;
            DataGridSemana.Columns["totalDeducido"].HeaderCell.Style.BackColor = Color.Tomato;

        }

        private void Semana_Load(object sender, EventArgs e)
        {
            //aqui voy a guardar todos los dias ordenados
            List<List<Dia>> listaDeListasDias = new List<List<Dia>>();

            //aqui voy a guardar las fechas de la semana para consultarlas en la bdd
            List<DateTime> fechasDias = new List<DateTime>();

            //Aqui se guarda la semana de cada empleado.
            List<SemanaClass> listaDeSemanas = new List<SemanaClass>();

            //Aqui se guardan los empleados de la bdd
            List<Empleado> listaDeEmpleados = new List<Empleado>();


            fechasDias = ObtenDias();
            listaDeListasDias = obtenDiasBDD(fechasDias);
            listaDeEmpleados = CargaEmpleadosBdd();


            //cargo empleados de la base de datos.


            ProcesaListaSemanas();
            CargaGrid();

            void CargaGrid()
            {
                DataGridSemana.DataSource = null;
                DataGridSemana.DataSource = listaDeSemanas;

                DataGridSemana.Columns["idChecador"].HeaderCell.Value = "Id_C";
                DataGridSemana.Columns["porcentajeTe"].HeaderCell.Value = "%TE";

                //oculto totales de cada semana
                DataGridSemana.Columns["viernesTotal"].Visible = false;
                DataGridSemana.Columns["sabadoTotal"].Visible = false;
                DataGridSemana.Columns["domingoTotal"].Visible = false;
                DataGridSemana.Columns["lunesTotal"].Visible = false;
                DataGridSemana.Columns["martesTotal"].Visible = false;
                DataGridSemana.Columns["miercolesTotal"].Visible = false;
                DataGridSemana.Columns["juevesTotal"].Visible = false;
                DataGridSemana.Columns["LunesPago"].Visible = false;
                DataGridSemana.Columns["MartesPago"].Visible = false;
                DataGridSemana.Columns["MiercolesPago"].Visible = false;
                DataGridSemana.Columns["JuevesPago"].Visible = false;
                DataGridSemana.Columns["ViernesPago"].Visible = false;
                DataGridSemana.Columns["SabadoPago"].Visible = false;
                DataGridSemana.Columns["DomingoPago"].Visible = false;


                DataGridSemana.Columns["viernes"].HeaderCell.Value = "V";
                DataGridSemana.Columns["viernesRetardo"].HeaderCell.Value = "VR";
                DataGridSemana.Columns["viernesSalida"].HeaderCell.Value = "VS";
                DataGridSemana.Columns["viernesTE"].HeaderCell.Value = "VTE";

                DataGridSemana.Columns["sabado"].HeaderCell.Value = "S";
                DataGridSemana.Columns["sabadoRetardo"].HeaderCell.Value = "SR";
                DataGridSemana.Columns["sabadoSalida"].HeaderCell.Value = "SS";
                DataGridSemana.Columns["sabadoTE"].HeaderCell.Value = "STE";

                DataGridSemana.Columns["domingo"].HeaderCell.Value = "D";
                DataGridSemana.Columns["domingoRetardo"].HeaderCell.Value = "DR";
                DataGridSemana.Columns["domingoSalida"].HeaderCell.Value = "DS";
                DataGridSemana.Columns["domingoTE"].HeaderCell.Value = "DTE";

                DataGridSemana.Columns["lunes"].HeaderCell.Value = "L";
                DataGridSemana.Columns["lunesRetardo"].HeaderCell.Value = "LR";
                DataGridSemana.Columns["lunesSalida"].HeaderCell.Value = "LS";
                DataGridSemana.Columns["lunesTE"].HeaderCell.Value = "LTE";

                DataGridSemana.Columns["martes"].HeaderCell.Value = "M";
                DataGridSemana.Columns["martesRetardo"].HeaderCell.Value = "MR";
                DataGridSemana.Columns["martesSalida"].HeaderCell.Value = "MS";
                DataGridSemana.Columns["martesTE"].HeaderCell.Value = "MTE";

                DataGridSemana.Columns["miercoles"].HeaderCell.Value = "X";
                DataGridSemana.Columns["miercolesRetardo"].HeaderCell.Value = "XR";
                DataGridSemana.Columns["miercolesSalida"].HeaderCell.Value = "XS";
                DataGridSemana.Columns["miercolesTE"].HeaderCell.Value = "XTE";

                DataGridSemana.Columns["jueves"].HeaderCell.Value = "J";
                DataGridSemana.Columns["juevesRetardo"].HeaderCell.Value = "JR";
                DataGridSemana.Columns["juevesSalida"].HeaderCell.Value = "JS";
                DataGridSemana.Columns["juevesTE"].HeaderCell.Value = "JTE";
                
                //cambio de descanso.
                DataGridSemana.Columns["Descanso"].HeaderCell.Value = "Dia Descanso";
                DataGridSemana.Columns["Descanso2"].HeaderCell.Value = "Descanso";




                DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                col.UseColumnTextForButtonValue = true;
                col.Text = "";
                col.Name = "Modificar";
                DataGridSemana.Columns.Add(col);
                col = new DataGridViewButtonColumn(); 
                col.UseColumnTextForButtonValue = true;
                col.Text = "";
                col.Name = "Guardar";
                DataGridSemana.Columns.Add(col);
                col = new DataGridViewButtonColumn();
                col.UseColumnTextForButtonValue = true;
                col.Text = "";
                col.Name = "Cancelar";
                DataGridSemana.Columns.Add(col);


                //colores
                DataGridSemana.CellFormatting += new DataGridViewCellFormattingEventHandler(myDataGridView_CellFormatting);
                foreach (DataGridViewColumn column in DataGridSemana.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    column.Width = column.Width; //This is important, otherwise the following line will nullify your previous command
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                }
                this.DataGridSemana.Columns[2].Frozen = true;

                foreach (DataGridViewRow row in DataGridSemana.Rows)
                {
                    row.ReadOnly = true;
                }

            }



            Dia BuscaDia( int diaDeSemana, int idChecador ) { 
                Dia aux = new Dia();
                foreach (Dia dia in listaDeListasDias[diaDeSemana])
                {
                    if(dia.Id == idChecador)
                    {
                        aux = dia;
                        return aux;
                    }
                }


                return aux;
            }
            
            void ProcesaListaSemanas()
            {
                foreach (Empleado empleado in listaDeEmpleados)
                {
                    ProcesaSemana(empleado);
                    
                }
            }
            
            void ProcesaSemana(Empleado empleado)
            {
                Dia viernes = BuscaDia(0, empleado.IdChecador);
                Dia sabado = BuscaDia(1, empleado.IdChecador);
                Dia domingo = BuscaDia(2, empleado.IdChecador);
                Dia lunes = BuscaDia(3, empleado.IdChecador);
                Dia martes = BuscaDia(4, empleado.IdChecador);
                Dia miercoles = BuscaDia(5, empleado.IdChecador);
                Dia jueves = BuscaDia(6, empleado.IdChecador);

                //ya con los dias vamos a hacer los calculos.
                SemanaClass aux = new SemanaClass();
                //asignar info del empleado en semana.
                AsignaInfo();

                ProcesaDia(aux, viernes);
                ProcesaDia(aux, sabado);
                ProcesaDia(aux, domingo);
                ProcesaDia(aux, lunes);
                ProcesaDia(aux, martes);
                ProcesaDia(aux, miercoles);
                ProcesaDia(aux, jueves);
                //Falta procesar el pago semanal.
                aux.Bono = empleado.Bono;
                ProcesaPago(aux);

                listaDeSemanas.Add(aux);
                //nos falta trabajar la entrada de los domingos. cambiar entrada por entrada domingo.

                void AsignaInfo()
                {
                    aux.Id = empleado.Id;
                    aux.IdChecador = empleado.IdChecador;
                    aux.Nombre = empleado.Nombre;
                    aux.SueldoImss = empleado.SueldoImss;
                    aux.Turno = empleado.Turno;
                    aux.Entrada = empleado.Entrada;
                    aux.Salida = empleado.SalidaEsperada;
                    aux.PorcentajeTe = empleado.Porcentaje;
                    aux.Descanso = empleado.Descanso;
                    aux.SueldoBase = empleado.Sueldo;
                    aux.EntradaDomingo = empleado.EntradaDomingo;
                
                }
            }

            //modifica latera
                
                

            void ProcesaPago(SemanaClass semana)
            {
                ProcesaTotalDiasTrabajados();
                ProcesaDescanso();
                ProcesaTotalPagado();
                ProcesaBono();
                ProcesaTotalDevengado();
                ProcesaDeducido();
                DiasDescanso();
                //hacer descansos
                ProcesaDiasPagados();
                semana.TotalPagado2 = semana.TotalDevengando - semana.TotalDeducido;

                void ProcesaDiasPagados()
                {
                    if (semana.IdChecador == 12)
                        Console.WriteLine("a");

                    int total = 0;
                    if (CuentaDia(semana.Lunes))
                        total = total + 1;
                    if (CuentaDia(semana.Martes))
                        total = total + 1;
                    if (CuentaDia(semana.Miercoles))
                        total = total + 1;
                    if (CuentaDia(semana.Jueves))
                        total = total + 1;
                    if (CuentaDia(semana.Viernes))
                        total = total + 1;
                    if (CuentaDia(semana.Sabado))
                        total = total + 1;
                    if (CuentaDia(semana.Domingo))
                        total = total + 1;
                    semana.TotalDiasPagados = total;
                }

                void DiasDescanso()
                {

                    if (Falta())
                    {
                        semana.DiasDescanso = 0;
                        return;
                    }

                    int total = 0;
                    if (PagaDescanso(semana.Lunes))
                        total = total + 1;
                    if (PagaDescanso(semana.Martes))
                        total = total + 1;
                    if (PagaDescanso(semana.Miercoles))
                        total = total + 1;
                    if (PagaDescanso(semana.Jueves))
                        total = total + 1;
                    if (PagaDescanso(semana.Viernes))
                        total = total + 1;
                    if (PagaDescanso(semana.Sabado))
                        total = total + 1;
                    if (PagaDescanso(semana.Domingo))
                        total = total + 1;
                    semana.DiasDescanso = total;
                    //si falta pierde descanso!


                }


                
                void ProcesaDescanso()
                {
                    int total = 0; 

                    if (semana.Lunes == "D")
                        total += 1;
                    if (semana.Martes == "D" )
                        total += 1;

                    if (semana.Miercoles == "D")
                        total += 1;

                    if (semana.Jueves == "D")
                        total += 1;

                    if (semana.Viernes == "D" )
                        total += 1;

                    if (semana.Sabado == "D")
                        total += 1;

                    if (semana.Domingo == "D")
                        total += 1;

                    semana.Descanso2 = total;
                    total = 0;

                    if (semana.Lunes == "DT")
                        total += 1;

                    if (semana.Martes == "DT")
                        total += 1;

                    if (semana.Miercoles == "DT")
                        total += 1;

                    if (semana.Jueves == "DT")
                        total += 1;

                    if (semana.Viernes == "DT")
                        total += 1;

                    if (semana.Sabado == "DT")
                        total += 1;

                    if (semana.Domingo == "DT")
                        total += 1;

                    semana.DescansoT = total;

                }
                void ProcesaTotalDiasTrabajados()
                {
                    int total = 0;
                    if (semana.Lunes == "1")
                        total += 1;

                    if (semana.Martes == "1")
                        total += 1;

                    if (semana.Miercoles == "1")
                        total += 1;

                    if (semana.Jueves == "1")
                        total += 1;

                    if (semana.Viernes == "1")
                        total += 1;

                    if (semana.Sabado == "1")
                        total += 1;

                    if (semana.Domingo == "1")
                        total += 1;
                    semana.DiasTrabajados = total;

                }
                void ProcesaTotalPagado()
                {
                    float descanso = 0;
                    if (semana.Descanso2 == 1 || semana.DescansoT == 1)
                    {
                        descanso = ((semana.SueldoBase / 7) / 6) * semana.DiasTrabajados;
                    }
                    float aux = 0;
                    aux = aux + semana.ViernesPago;
                    aux = aux + semana.SabadoPago;
                    aux = aux + semana.ViernesPago;
                    aux = aux + semana.LunesPago;
                    aux = aux + semana.MartesPago;
                    aux = aux + semana.MiercolesPago;
                    aux = aux + semana.JuevesPago;
      
                    semana.TotalPagado = aux + descanso;
                }

                void ProcesaTotalDevengado()
                {

                    float aux = semana.TotalDevengando;
                    aux = aux + semana.ViernesTotal;
                    aux = aux + semana.SabadoTotal;
                    aux = aux + semana.DomingoTotal;
                    aux = aux + semana.LunesTotal;
                    aux = aux + semana.MartesTotal;
                    aux = aux + semana.MiercolesTotal;
                    aux = aux + semana.JuevesTotal;
                    semana.TotalDevengando = aux;

                }
                //FALTAN SALIDAS ETC.

                void ProcesaBono(){
                    if (Falta())
                    {
                        semana.DiasBono = 0;
                        semana.BonoTotal = 0;
                        return;
                    }
                    semana.DiasBono = semana.DiasTrabajados;
                    semana.Bono = (semana.Bono / 6) * semana.DiasBono;
                }

                void ProcesaDeducido()
                {
                    float aux = 0;
                    if (semana.ViernesRetardo == "1")
                        aux = aux + 100;
                    if (semana.LunesRetardo == "1")
                        aux = aux + 100;
                    if (semana.MartesRetardo == "1")
                        aux = aux + 100;
                    if (semana.MiercolesRetardo == "1")
                        aux = aux + 100;
                    if (semana.JuevesRetardo == "1")
                        aux = aux + 100;
                    if (semana.ViernesRetardo == "1")
                        aux = aux + 100;
                    if (semana.SabadoRetardo == "1")
                        aux = aux + 100;
                    if (semana.DomingoRetardo == "1")
                        aux = aux + 100;

                    semana.TotalRetardos = aux;

                    if (semana.ViernesSalida == "1")
                        aux = aux + 100;
                    if (semana.LunesSalida == "1")
                        aux = aux + 100;
                    if (semana.MartesSalida == "1")
                        aux = aux + 100;
                    if (semana.MiercolesSalida == "1")
                        aux = aux + 100;
                    if (semana.JuevesSalida == "1")
                        aux = aux + 100;
                    if (semana.ViernesSalida == "1")
                        aux = aux + 100;
                    if (semana.SabadoSalida == "1")
                        aux = aux + 100;
                    if (semana.DomingoSalida == "1")
                        aux = aux + 100;

                    semana.TotalSalidas = aux - semana.TotalRetardos;



                    semana.TotalDeducido = aux;
                }

                bool CuentaDia(string asistencia)
                {
                    if (asistencia == "1" || asistencia == "V" || asistencia == "LP" || asistencia == "LF" || asistencia == "DT")
                        return true;
                    return false;

                }

                bool PagaDescanso(string asistencia)
                {
                    if (asistencia == "1" || asistencia == "V" || asistencia == "LP" || asistencia == "LF")
                        return true;
                    return false;

                }
                bool Falta()
                {
                    if (semana.Lunes == "F")
                        return true;
                    if (semana.Martes == "F")
                        return true;
                    if (semana.Miercoles == "F")
                        return true;
                    if (semana.Jueves == "F")
                        return true;
                    if (semana.Viernes == "F")
                        return true;
                    if (semana.Sabado == "F")
                        return true;
                    if (semana.Domingo == "F")
                        return true;
                    return false;
                }
            }

            void ProcesaDia(SemanaClass semana, Dia dia){
                if(dia.Asistencia == null)
                {
                    return;
                }
                //validar cuando dia sea null
                DateTime fecha = new DateTime();
                fecha = DateTime.Parse(dia.Fecha);
                if(fecha.DayOfWeek.ToString() == "Friday")
                {
                    //Procesar los dias.ñ
                    semana.Viernes = ProcesaAsistencia(dia);
                    semana.ViernesRetardo =  ProcesaRetardo(dia);    
                    semana.ViernesSalida = ProcesaSalida(dia);
                    semana.ViernesTE = ProcesaTE(dia);
                    semana.ViernesTotal = dia.Total;
                    semana.ViernesPago = dia.SueldoDiario;
                }
                if (fecha.DayOfWeek.ToString() == "Saturday")
                {
                    //caso sabado
                    semana.Sabado = ProcesaAsistencia(dia);
                    semana.SabadoRetardo = ProcesaRetardo(dia);
                    semana.SabadoSalida = ProcesaSalida(dia);
                    semana.SabadoTE = ProcesaTE(dia);
                    semana.SabadoTotal = dia.Total;
                    semana.SabadoPago = dia.SueldoDiario;

                }
                if (fecha.DayOfWeek.ToString() == "Sunday")
                {
                    //caso domingo
                    semana.Domingo = ProcesaAsistencia(dia);
                    semana.DomingoRetardo = ProcesaRetardo(dia);
                    semana.DomingoSalida = ProcesaSalida(dia);
                    semana.DomingoTE = ProcesaTE(dia);
                    semana.DomingoTotal = dia.Total;
                    semana.DomingoPago = dia.SueldoDiario;
                }
                if (fecha.DayOfWeek.ToString() == "Monday")
                {
                    //caso Lunes
                    semana.Lunes = ProcesaAsistencia(dia);
                    semana.LunesRetardo = ProcesaRetardo(dia);
                    semana.LunesSalida = ProcesaSalida(dia);
                    semana.LunesTE = ProcesaTE(dia);
                    semana.LunesTotal = dia.Total;
                    semana.LunesPago = dia.SueldoDiario;
                }
                if (fecha.DayOfWeek.ToString() == "Tuesday")
                {
                    //caso Martes
                    semana.Martes = ProcesaAsistencia(dia);
                    semana.MartesRetardo = ProcesaRetardo(dia);
                    semana.MartesSalida = ProcesaSalida(dia);
                    semana.MartesTE = ProcesaTE(dia);
                    semana.MartesTotal = dia.Total;
                    semana.MartesPago = dia.SueldoDiario;
                }
                if (fecha.DayOfWeek.ToString() == "Wednesday")
                {
                    //caso Miercoles
                    semana.Miercoles = ProcesaAsistencia(dia);
                    semana.MiercolesRetardo = ProcesaRetardo(dia);
                    semana.MiercolesSalida = ProcesaSalida(dia);
                    semana.MiercolesTE = ProcesaTE(dia);
                    semana.MiercolesTotal = dia.Total;
                    semana.MiercolesPago = dia.SueldoDiario;
                }
                if (fecha.DayOfWeek.ToString() == "Thursday")
                {
                    //caso Jueves
                    semana.Jueves = ProcesaAsistencia(dia);
                    semana.JuevesRetardo = ProcesaRetardo(dia);
                    semana.JuevesSalida = ProcesaSalida(dia);
                    semana.JuevesTE = ProcesaTE(dia);
                    semana.JuevesTotal = dia.Total;
                    semana.JuevesPago = dia.SueldoDiario;
                }

                String ProcesaAsistencia(Dia diaAux)
                {
                    //aqui vamos a poner todo lo que entre en asistencia, permisos, vacaciones etc
                    if (dia.DescansoTrabajado == "SI")
                        return "DT";
                    if (dia.Asistencia == "Descansó")
                        return "D";
                    if (dia.Asistencia == "Asistió")
                        return "1";
                    if (dia.Asistencia == "Faltó")
                        return "F";
                    return "";
                }
                String ProcesaRetardo(Dia diaAux)
                {
                    if (dia.Retardo == "NO")
                        return "0";
                    if (dia.Retardo == "SI")
                        return "1";
                    return "";
                }
                String ProcesaSalida(Dia diaAux)
                {
                    if (dia.Salida == "NO")
                        return "0";
                    if (dia.Salida == "SI")
                        return "1";
                    return "";
                }
                String ProcesaTE(Dia diaAux)
                {
                    if (dia.TurnoExtra == "NO")
                        return "0";
                    if (dia.TurnoExtra == "SI")
                        return "1";
                    return "";
                }


            }


            List<Empleado> CargaEmpleadosBdd()
            {
                List < Empleado > aux = new List<Empleado> ();
                using (var connection = new MySqlConnection(conexion))
                {
                    try
                    {
                        connection.Open();
                        MySqlDataAdapter adaptador = new MySqlDataAdapter("SELECT * FROM " + sucursal + ".Empleados order by id", connection);
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
                            auxiliar.Turno = datos.Rows[i]["turno"].ToString();
                            auxiliar.SueldoImss = float.Parse(datos.Rows[i]["sueldo_imss"].ToString());
                            
                            aux.Add(auxiliar);
                        }
                        connection.Close();
                        return aux;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
                return aux;
            }

            //metodo para obtener los dias de la semana actual de la bdd
            List<List<Dia>> obtenDiasBDD(List<DateTime> fechas)
            {
                List<List<Dia>> Aux = new List<List<Dia>>();
                List<Dia> lunes = new List<Dia>();
                List<Dia> martes = new List<Dia>();
                List<Dia> miercoles = new List<Dia>();
                List<Dia> jueves = new List<Dia>();
                List<Dia> viernes = new List<Dia>();
                List<Dia> sabado = new List<Dia>();
                List<Dia> domingo = new List<Dia>();

                using (var connection = new MySqlConnection(conexion))
                {
                    try
                    {
                        connection.Open();
                        string sqlString = $"SELECT * " +
                            $"FROM {sucursal}.Dias " +
                            $"WHERE fecha IN ('{fechas[0].ToString("yyyy-MM-dd")}', '{fechas[1].ToString("yyyy-MM-dd")}', '{fechas[2].ToString("yyyy-MM-dd")}', '{fechas[3].ToString("yyyy-MM-dd")}'," +
                            $" '{fechas[4].ToString("yyyy-MM-dd")}', '{fechas[5].ToString("yyyy-MM-dd")}', '{fechas[6].ToString("yyyy-MM-dd")}') " +
                            $"ORDER BY fecha; ";

                        MySqlDataAdapter adaptador = new MySqlDataAdapter(sqlString, connection);
                        DataTable datos = new DataTable();
                        adaptador.Fill(datos);

                        //aqui obtenemos a los empleados de la base de datos y los almacenamos en una lista en memoria dinamica

                        for (int i = 0; i < datos.Rows.Count; i++)
                        {
                            Dia diaAux = new Dia();
                            diaAux.Id = int.Parse(datos.Rows[i]["id_empleado"].ToString());
                            diaAux.Fecha = datos.Rows[i]["fecha"].ToString();
                            //fecha toma tambien la hora, lo voy a parsear para solo tomar la fecha en dia.
                            DateTime auxiliarFecha = new DateTime();
                            auxiliarFecha = DateTime.Parse(diaAux.Fecha);
                            diaAux.Fecha = auxiliarFecha.ToString("yyyy-MM-dd");
                            string test = auxiliarFecha.ToString("yyyy-MM-dd");
                            diaAux.Asistencia = datos.Rows[i]["asistencia"].ToString();
                            diaAux.Retardo = datos.Rows[i]["retardo"].ToString();
                            diaAux.Salida = datos.Rows[i]["salida"].ToString();
                            diaAux.TurnoExtra = datos.Rows[i]["turno_extra"].ToString();
                            diaAux.Comida = int.Parse(datos.Rows[i]["comida"].ToString());
                            diaAux.TurnoExtraPaga = float.Parse(datos.Rows[i]["turno_extra_paga"].ToString());
                            diaAux.Total = float.Parse(datos.Rows[i]["total"].ToString());
                            diaAux.Incidencia = datos.Rows[i]["incidencia"].ToString();
                            diaAux.DescansoTrabajado = datos.Rows[i]["descanso_trabajado"].ToString();
                            diaAux.Anotaciones = datos.Rows[i]["anotaciones"].ToString();
                            diaAux.HorasTrabajadas = datos.Rows[i]["horas_trabajadas"].ToString();
                            diaAux.HoraLlegada = datos.Rows[i]["hora_llegada"].ToString();
                            diaAux.HoraSalida = datos.Rows[i]["hora_salida"].ToString();
                            diaAux.SueldoDiario = float.Parse(datos.Rows[i]["sueldo_diario"].ToString());

                            if(diaAux.Fecha == fechas[0].ToString("yyyy-MM-dd"))
                            {
                                viernes.Add(diaAux);
                            }
                            if (diaAux.Fecha == fechas[1].ToString("yyyy-MM-dd"))
                            {
                                sabado.Add(diaAux);
                            }
                            if (diaAux.Fecha == fechas[2].ToString("yyyy-MM-dd"))
                            {
                                domingo.Add(diaAux);
                            }
                            if (diaAux.Fecha == fechas[3].ToString("yyyy-MM-dd"))
                            {
                                lunes.Add(diaAux);
                            }
                            if (diaAux.Fecha == fechas[4].ToString("yyyy-MM-dd"))
                            {
                                martes.Add(diaAux);
                            }
                            if (diaAux.Fecha == fechas[5].ToString("yyyy-MM-dd"))
                            {
                                miercoles.Add(diaAux);
                            }
                            if (diaAux.Fecha == fechas[6].ToString("yyyy-MM-dd"))
                            {
                                jueves.Add(diaAux);
                            }

                        }

                        Aux.Add(viernes);
                        Aux.Add(sabado);
                        Aux.Add(domingo);
                        Aux.Add(lunes);
                        Aux.Add(martes);
                        Aux.Add(miercoles);
                        Aux.Add(jueves);

                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }

                return Aux;
            }


            //metodo para obtener las fechas de los dias de la semana actual
            List<DateTime> ObtenDias(){

                // Obtener la fecha actual
                DateTime fechaActual = DateTime.Today;


                // Obtener el día de la semana actual
                int diaSemanaActual = (int)fechaActual.DayOfWeek;

                // Obtener la fecha del viernes anterior
                int diaViernes = (int)DayOfWeek.Friday;

                diaViernes = convierteDia(diaViernes);
                diaSemanaActual = convierteDia(diaSemanaActual);


                int diasAvanzar = (diaViernes - diaSemanaActual);

                DateTime fechaViernesAnterior = fechaActual.AddDays(diasAvanzar);

                // Obtener las fechas para cada día de la semana
                DateTime viernes = fechaViernesAnterior;
                DateTime sabado = viernes.AddDays(1);
                DateTime domingo = sabado.AddDays(1);
                DateTime lunes = domingo.AddDays(1);
                DateTime martes = lunes.AddDays(1);
                DateTime miercoles = martes.AddDays(1);
                DateTime jueves = miercoles.AddDays(1);

                List <DateTime> aux = new List<DateTime>(); 
                aux.Add(viernes);
                aux.Add(sabado);
                aux.Add(domingo);
                aux.Add(lunes);
                aux.Add(martes);
                aux.Add(miercoles);
                aux.Add(jueves);

                return aux;


                int convierteDia(int dia)
                {
                    if (dia == 1)
                        return 4;
                    if (dia == 2)
                        return 5;
                    if (dia == 3)
                        return 6;
                    if (dia == 4)
                        return 7;
                    if (dia == 5)
                        return 1;
                    if (dia == 6)
                        return 2;
                    if (dia == 0)
                        return 3;
                    return 0;
                }
            }
        }
    }
}
