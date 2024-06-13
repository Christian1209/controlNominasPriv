using Irony.Parsing;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using NPOI.HSSF.Record.Chart;
using NPOI.OpenXmlFormats.Dml;
using NPOI.OpenXmlFormats.Dml.Chart;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Xml.Serialization;
using static NPOI.HSSF.Util.HSSFColor;

namespace ProcesadorNominaas
{
    public partial class Semana : Form
    {

        string conexion = ("Server=monorail.proxy.rlwy.net;Port=15455;Database=railway;Uid=root;password=HBFHC45b5A2BE4a552G-Cf13AeEA-DFE;");
        string sucursal = "";
        string anterior = "";
        bool semanaPagada = false;
        string semanaViernes = "";

        //variables de la sucursal para el calculo
        float comida = 0;
        float retardo = 0;
        float salida = 0;
        //variable para saber a partir de que sueldo cobramos mas en el retardo  omenos.
        float sueldo_alto = 0;
        float salida_baja = 0;
        float retardo_bajo = 0;

        //variable para ver cuantos dias le voy a restar o sumar al viernes.
        int dias = 0;

        //variable que controla la edicion del data grid.
        bool modifica = false;

        public Semana(string sucursal, string anterior, int dias)
        {
            InitializeComponent();
            this.sucursal = sucursal;
            this.anterior = anterior;
            this.dias = dias;
        }

        //semana auxiliar para modificar. 
        SemanaClass semanaAuxiliar = new SemanaClass();
        DataGridViewRow filaAuxiliar = new DataGridViewRow();
        //Aqui se guarda la semana de cada empleado.
        List<SemanaClass> listaDeSemanas = new List<SemanaClass>();



        private void DataGridSemana_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica si el clic ocurrió en la columna de botón
            if (e.ColumnIndex == DataGridSemana.Columns["Modificar"].Index && e.RowIndex >= 0)
            {
                semanaAuxiliar = null;
                filaAuxiliar = null;
                MessageBox.Show("Introduce la contraseña" + e.RowIndex);


                /*
                // Haz que las celdas específicas sean editables
                string[] editableColumns = { "V", "VR", "VS", "VTE", "S", "SR", "SS", "STE", "D", "DR", "DS", "DTE", "L", "LR", "LS", "LTE", "M", "MR", "MS", "MTE", "X", "XR", "XS", "XTE", "J", "JR", "JS", "JTE" }; // Índices de columnas que deseas hacer editables

     
                foreach (string columnIndex in editableColumns)
                {
                    DataGridSemana.Rows[e.RowIndex].Cells[columnIndex].ReadOnly = false;
                }
                */

                //guardo el estado de la fila por si se cancela la modificación
                GuardaSemana(DataGridSemana.Rows[e.RowIndex]);

                DataGridViewButtonCell c = (DataGridViewButtonCell)DataGridSemana.Rows[e.RowIndex].Cells["Modificar"];



                DataGridSemana.Rows[e.RowIndex].ReadOnly = false;
                modifica = true;
                c.Style.ForeColor = Color.Black;
                c.Style.BackColor = Color.Yellow;

            }
            // Verifica si el clic ocurrió en la columna de botón
            if (e.ColumnIndex == DataGridSemana.Columns["Guardar"].Index && e.RowIndex >= 0)
            {

                //verificamos que haya algo que guardar.
                if(HayModificaciones()){
                    if(Actualiza(DataGridSemana.Rows[e.RowIndex]) == false)
                        MessageBox.Show("Ocurrió un error contacta un administrador.");
                    else
                        MessageBox.Show("Se guardo correctamente.");
                    

                }
                else
                {
                    MessageBox.Show("No hay modificaciones para guardar.");
                }
                DataGridSemana.Rows[e.RowIndex].ReadOnly = true;
                DataGridViewButtonCell c = (DataGridViewButtonCell)DataGridSemana.Rows[e.RowIndex].Cells["Modificar"];
                c.Style.ForeColor = Color.Navy;
                c.Style.BackColor = Color.Gainsboro;
                modifica = false;
                DataGridSemana.Refresh();
            }
            if (e.ColumnIndex == DataGridSemana.Columns["Cancelar"].Index && e.RowIndex >= 0)
            {
                DataGridViewButtonCell c = (DataGridViewButtonCell)DataGridSemana.Rows[e.RowIndex].Cells["Modificar"];
                c.Style.ForeColor = Color.Navy;
                c.Style.BackColor = Color.Gainsboro;
                MessageBox.Show("Se cancelaron los cambios");
                RegresaValores(DataGridSemana.Rows[e.RowIndex]);
                DataGridSemana.Rows[e.RowIndex].ReadOnly = true;
                DataGridSemana.Refresh();

            }
            if (e.ColumnIndex == DataGridSemana.Columns["Imprimir"].Index && e.RowIndex >= 0)
            {

                MessageBox.Show("Se generó el archivo");

                DataGridSemana.Rows[e.RowIndex].ReadOnly = false;
                DataGridSemana.Refresh();

            }
            if (e.ColumnIndex == DataGridSemana.Columns["Pagado"].Index && e.RowIndex >= 0)
            {

                if (FuePagado())
                {
                    MessageBox.Show("Ya fue pagado, contacta con un administrador si quieres hacer modificaciones.");
                }
                else
                {
                    MessageBox.Show("¿Seguro que quieres confirmar el pago?  Se pagara la cantidad de: " + DataGridSemana.Rows[e.RowIndex].Cells["TotalPagado2"].Value.ToString() + ". Al empleado :  " + DataGridSemana.Rows[e.RowIndex].Cells["Nombre"].Value.ToString());

                    if (InsertaEmpleado(DataGridSemana.Rows[e.RowIndex]))
                    {
                        DataGridViewButtonCell c = (DataGridViewButtonCell)DataGridSemana.Rows[e.RowIndex].Cells["Pagado"];
                        //cambiar color.
                        DataGridSemana.Rows[e.RowIndex].Cells["SemanaPagada"].Value = "SI";
                        c.Style.ForeColor = Color.Black;
                        c.Style.BackColor = Color.PaleGreen;
                    }
   
                }
 
            }
            void GuardaSemana( DataGridViewRow original)
            {
                filaAuxiliar = (DataGridViewRow)original.Clone();
                for (int i = 0; i < original.Cells.Count; i++)
                {
                    filaAuxiliar.Cells[i].Value = original.Cells[i].Value;
                }
            }


            void RegresaValores(DataGridViewRow original)
            {
                //regreso mis valores con el auxiliar
                for (int i = 0; i < original.Cells.Count; i++)
                {
                    original.Cells[i].Value = filaAuxiliar.Cells[i].Value;
                }
            }

            bool HayModificaciones()
            {
                DataGridViewButtonCell c = (DataGridViewButtonCell)DataGridSemana.Rows[e.RowIndex].Cells["Modificar"];
                if (c.Style.BackColor == Color.Yellow)
                    return true;
                else
                    return false;
            }

            bool FuePagado()
            {
                DataGridViewButtonCell c = (DataGridViewButtonCell)DataGridSemana.Rows[e.RowIndex].Cells["Pagado"];
                if (c.Style.BackColor == Color.PaleGreen)
                    return true;
                else
                    return false;
            }

            bool EsJueves()
            {
                DateTime fechaActual = DateTime.Today;
                if (fechaActual.DayOfWeek.ToString() == "Thursday")
                    return true;
                return false;
            }

            bool Actualiza(DataGridViewRow row)
            {
                string sqlString = "UPDATE " + sucursal + ".Semanas SET ";
                sqlString = sqlString + "id_empleado = '" + row.Cells["Id"].Value.ToString() + "', ";
                sqlString = sqlString + "nombre = '" + row.Cells["Nombre"].Value.ToString() + "', ";
                sqlString = sqlString + "sueldo_imss = '" + row.Cells["SueldoImss"].Value.ToString() + "', ";
                sqlString = sqlString + "turno = '" + row.Cells["Turno"].Value.ToString() + "', ";
                sqlString = sqlString + "entrada_domingo = '" + row.Cells["EntradaDomingo"].Value.ToString() + "', ";
                sqlString = sqlString + "entrada = '" + row.Cells["Entrada"].Value.ToString() + "', ";
                sqlString = sqlString + "salida = '" + row.Cells["Salida"].Value.ToString() + "', ";
                sqlString = sqlString + "sueldo_base = '" + row.Cells["SueldoBase"].Value.ToString() + "', ";
                sqlString = sqlString + "bono = '" + row.Cells["Bono"].Value.ToString() + "', ";
                sqlString = sqlString + "porcentaje_te = '" + row.Cells["%TE"].Value.ToString() + "', ";
                sqlString = sqlString + "dia_descanso = '" + row.Cells["Dia Descanso"].Value.ToString() + "', ";
                sqlString = sqlString + "v = '" + row.Cells["V"].Value.ToString() + "', ";
                sqlString = sqlString + "vr = '" + row.Cells["VR"].Value.ToString() + "', ";
                sqlString = sqlString + "vs = '" + row.Cells["VS"].Value.ToString() + "', ";
                sqlString = sqlString + "dte = '" + row.Cells["DTE"].Value.ToString() + "', ";
                sqlString = sqlString + "mte = '" + row.Cells["MTE"].Value.ToString() + "', ";
                sqlString = sqlString + "jte = '" + row.Cells["JTE"].Value.ToString() + "', ";
                sqlString = sqlString + "cantidad_abono = '" + row.Cells["CantidadAbono"].Value.ToString() + "', ";
                sqlString = sqlString + "vte = '" + row.Cells["VTE"].Value.ToString() + "', ";
                sqlString = sqlString + "s = '" + row.Cells["S"].Value.ToString() + "', ";
                sqlString = sqlString + "sr = '" + row.Cells["SR"].Value.ToString() + "', ";
                sqlString = sqlString + "ss = '" + row.Cells["SS"].Value.ToString() + "', ";
                sqlString = sqlString + "ste = '" + row.Cells["STE"].Value.ToString() + "', ";
                sqlString = sqlString + "d = '" + row.Cells["D"].Value.ToString() + "', ";
                sqlString = sqlString + "dr = '" + row.Cells["DR"].Value.ToString() + "', ";
                sqlString = sqlString + "ds = '" + row.Cells["DS"].Value.ToString() + "', ";
                sqlString = sqlString + "l = '" + row.Cells["L"].Value.ToString() + "', ";
                sqlString = sqlString + "lr = '" + row.Cells["LR"].Value.ToString() + "', ";
                sqlString = sqlString + "ls = '" + row.Cells["LS"].Value.ToString() + "', ";
                sqlString = sqlString + "lte = '" + row.Cells["LTE"].Value.ToString() + "', ";
                sqlString = sqlString + "m = '" + row.Cells["M"].Value.ToString() + "', ";
                sqlString = sqlString + "mr = '" + row.Cells["MR"].Value.ToString() + "', ";
                sqlString = sqlString + "ms = '" + row.Cells["MS"].Value.ToString() + "', ";
                sqlString = sqlString + "x = '" + row.Cells["X"].Value.ToString() + "', ";
                sqlString = sqlString + "xr = '" + row.Cells["XR"].Value.ToString() + "', ";
                sqlString = sqlString + "xs = '" + row.Cells["XS"].Value.ToString() + "', ";
                sqlString = sqlString + "xte = '" + row.Cells["XTE"].Value.ToString() + "', ";
                sqlString = sqlString + "j = '" + row.Cells["J"].Value.ToString() + "', ";
                sqlString = sqlString + "jr = '" + row.Cells["JR"].Value.ToString() + "', ";
                sqlString = sqlString + "js = '" + row.Cells["JS"].Value.ToString() + "', ";
                sqlString = sqlString + "descanso = '" + row.Cells["Descanso"].Value.ToString() + "', ";
                sqlString = sqlString + "descanso_t = '" + row.Cells["DescansoT"].Value.ToString() + "', ";
                sqlString = sqlString + "dias_descanso = '" + row.Cells["DiasDescanso"].Value.ToString() + "', ";
                sqlString = sqlString + "incapacidad = '" + row.Cells["Incapacidad"].Value.ToString() + "', ";
                sqlString = sqlString + "vacaciones = '" + row.Cells["Vacaciones"].Value.ToString() + "', ";
                sqlString = sqlString + "dias_trabajados = '" + row.Cells["DiasTrabajados"].Value.ToString() + "', ";
                sqlString = sqlString + "dias_bono = '" + row.Cells["DiasBono"].Value.ToString() + "', ";
                sqlString = sqlString + "bono_total = '" + row.Cells["BonoTotal"].Value.ToString() + "', ";
                sqlString = sqlString + "total_dias_pagados = '" + row.Cells["TotalDiasPagados"].Value.ToString() + "', ";
                sqlString = sqlString + "total_pagado = '" + row.Cells["TotalPagado"].Value.ToString() + "', ";
                sqlString = sqlString + "total_devengado = '" + row.Cells["TotalDevengando"].Value.ToString() + "', ";
                sqlString = sqlString + "descuento_incapacidad = '" + row.Cells["DescuentoIncapacidad"].Value.ToString() + "', ";
                sqlString = sqlString + "nomina_fiscal = '" + row.Cells["NominaFiscal"].Value.ToString() + "', ";
                sqlString = sqlString + "multa = '" + row.Cells["Multa"].Value.ToString() + "', ";
                sqlString = sqlString + "multa2 = '" + row.Cells["Multa2"].Value.ToString() + "', ";
                sqlString = sqlString + "cantidad_prestamo = '" + row.Cells["CantidadPrestamo"].Value.ToString() + "', ";
                sqlString = sqlString + "saldo_prestamo = '" + row.Cells["SaldoPrestamo"].Value.ToString() + "', ";
                sqlString = sqlString + "cantidad_herramienta = '" + row.Cells["CantidadHerramienta"].Value.ToString() + "', ";
                sqlString = sqlString + "abono_herramienta = '" + row.Cells["AbonoHerramienta"].Value.ToString() + "', ";
                sqlString = sqlString + "gorra = '" + row.Cells["Gorra"].Value.ToString() + "', ";
                sqlString = sqlString + "trapo = '" + row.Cells["Trapo"].Value.ToString() + "', ";
                sqlString = sqlString + "total_uniformes = '" + row.Cells["TotalUniformes"].Value.ToString() + "', ";
                sqlString = sqlString + "total_retardos = '" + row.Cells["TotalRetardos"].Value.ToString() + "', ";
                sqlString = sqlString + "total_salidas = '" + row.Cells["TotalSalidas"].Value.ToString() + "', ";
                sqlString = sqlString + "total_deducido = '" + row.Cells["TotalDeducido"].Value.ToString() + "', ";
                sqlString = sqlString + "total_pagado2 = '" + row.Cells["TotalPagado2"].Value.ToString() + "', ";
                sqlString = sqlString + "fecha_viernes = '" + semanaViernes + "', ";
                sqlString = sqlString + "semana_pagada = 'SI' ";
                sqlString = sqlString + "WHERE id_checador = " + row.Cells["Id_C"].Value.ToString() + " AND fecha_viernes = '" + semanaViernes + "' and id > 0;";
                using (var connection = new MySqlConnection(conexion))
                {
                    try
                    {
                        connection.Open();

                        MySqlCommand comando = new MySqlCommand(sqlString, connection);
                        comando.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrio un error al pagar, intenta de nuevo o contactate con un administrador (" + ex.ToString() + ")");
                        return false;
                    }
                }
            }
            bool InsertaEmpleado(DataGridViewRow row)
            {

                if (YaEstaEnBdd() == true)
                {
                    if (Actualiza(row))
                        return true;
                    else
                        return false;
                }
                else
                {
                    if (Inserta())
                        return true;
                    else
                        return false;
                }



                bool Inserta()
                {
                    string sqlString = "INSERT INTO " + sucursal + ".Semanas (id_checador,id_empleado,nombre,sueldo_imss,turno,entrada_domingo,entrada,salida,sueldo_base,bono,porcentaje_te,dia_descanso,v,vr,vs,dte,mte,jte,cantidad_abono,vte,s,sr,ss,ste,d,dr,ds,l,lr,ls,lte,m,mr,ms,x,xr,xs,xte,j,jr,js,descanso,descanso_t,dias_descanso,incapacidad,vacaciones,dias_trabajados,dias_bono,bono_total,total_dias_pagados,total_pagado,total_devengado,descuento_incapacidad,nomina_fiscal,multa,multa2,cantidad_prestamo,saldo_prestamo,cantidad_herramienta,abono_herramienta,gorra,trapo,total_uniformes,total_retardos,total_salidas,total_deducido,total_pagado2,fecha_viernes,semana_pagada\r\n) VALUES (";
                    sqlString = sqlString + "'" + row.Cells["Id_C"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["Id"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["Nombre"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["SueldoImss"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["Turno"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["EntradaDomingo"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["Entrada"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["Salida"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["SueldoBase"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["Bono"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["%TE"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["Dia Descanso"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["V"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["VR"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["VS"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["DTE"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["MTE"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["JTE"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["CantidadAbono"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["VTE"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["S"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["SR"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["SS"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["STE"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["D"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["DR"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["DS"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["L"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["LR"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["LS"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["LTE"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["M"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["MR"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["MS"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["X"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["XR"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["XS"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["XTE"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["J"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["JR"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["JS"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["Descanso"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["DescansoT"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["DiasDescanso"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["Incapacidad"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["Vacaciones"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["DiasTrabajados"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["DiasBono"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["BonoTotal"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["TotalDiasPagados"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["TotalPagado"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["TotalDevengando"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["DescuentoIncapacidad"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["NominaFiscal"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["Multa"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["Multa2"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["CantidadPrestamo"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["SaldoPrestamo"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["CantidadHerramienta"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["AbonoHerramienta"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["Gorra"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["Trapo"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["TotalUniformes"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["TotalRetardos"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["TotalSalidas"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["TotalDeducido"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + row.Cells["TotalPagado2"].Value.ToString() + "'" + ",";
                    sqlString = sqlString + "'" + semanaViernes + "'" + ",";
                    sqlString = sqlString + "'" + "SI" + "'"; // Último valor, no lleva coma al final
                    sqlString = sqlString + ");"; // Cerramos la sentencia SQL
                    using (var connection = new MySqlConnection(conexion))
                    {
                        try
                        {
                            connection.Open();

                            MySqlCommand comando = new MySqlCommand(sqlString, connection);
                            comando.ExecuteNonQuery();
                            connection.Close();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ocurrio un error al pagar, intenta de nuevo o contactate con un administrador (" + ex.ToString() + ")");
                            return false;
                        }
                    }
                }

                

                bool YaEstaEnBdd()
                {
                    bool recordExists = false;

                    string query = "SELECT * FROM Normandia.Semanas WHERE id_checador = @idChecador AND fecha_viernes = @fechaViernes";

                    using (MySqlConnection connection = new MySqlConnection(conexion))
                    {
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@idChecador", row.Cells["Id_C"].Value.ToString());
                            command.Parameters.AddWithValue("@fechaViernes", semanaViernes);

                            try
                            {
                                connection.Open();

                                using (MySqlDataReader reader = command.ExecuteReader())
                                {
                                    if (reader.HasRows)
                                    {
                                        recordExists = true;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                // Manejar la excepción (log, re-throw, etc.)
                                Console.WriteLine("An error occurred: " + ex.Message);
                            }
                        }
                    }
                    return recordExists;
                }

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
            c.DefaultCellStyle.BackColor = Color.Gainsboro;
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
            c = (DataGridViewButtonColumn)DataGridSemana.Columns["Imprimir"];
            c.FlatStyle = FlatStyle.Popup;
            c.DefaultCellStyle.ForeColor = Color.Navy;
            c.DefaultCellStyle.BackColor = Color.Gainsboro;
            c.Text = "I";
            c = (DataGridViewButtonColumn)DataGridSemana.Columns["Pagado"];
            c.FlatStyle = FlatStyle.Popup;
            c.DefaultCellStyle.ForeColor = Color.Navy;
            c.DefaultCellStyle.BackColor = Color.Gainsboro;
            c.Text = "P";
            //cambiar color.


            ColoresPagado();

            //colores headers.
            DataGridSemana.EnableHeadersVisualStyles = false;
            DataGridSemana.Columns["totalPagado2"].HeaderCell.Style.BackColor = Color.LimeGreen;
            DataGridSemana.Columns["totalDeducido"].HeaderCell.Style.BackColor = Color.Tomato;

            void ColoresPagado()
            {
                if (DataGridSemana.Columns[e.ColumnIndex].Name == "Pagado")
                {
                    // Obtén el valor de la columna "SemanaPagada" en la misma fila
                    var semanaPagadaValue = DataGridSemana.Rows[e.RowIndex].Cells["SemanaPagada"].Value;

                    // Verifica si el valor de "SemanaPagada" es "SI"
                    if (semanaPagadaValue != null && semanaPagadaValue.ToString() == "SI")
                    {
                        // Cambia el color del botón en la celda "Pagado"
                        DataGridViewButtonCell cAux = (DataGridViewButtonCell)DataGridSemana.Rows[e.RowIndex].Cells["Pagado"];
                        cAux.Style.ForeColor = Color.Black;
                        cAux.Style.BackColor = Color.PaleGreen;
                    }
                    else if (semanaPagadaValue != null && semanaPagadaValue.ToString() == "NO" && anterior == "anterior" )
                    {
                        // Cambia el color del botón en la celda "Pagado"
                        DataGridViewButtonCell cAux = (DataGridViewButtonCell)DataGridSemana.Rows[e.RowIndex].Cells["Pagado"];
                        cAux.Style.ForeColor = Color.Black;
                        cAux.Style.BackColor = Color.OrangeRed;
                    }
                    else
                    {
                        // Aplica un estilo por defecto si no se cumple la condición
                        e.CellStyle.BackColor = Color.Gainsboro;
                        e.CellStyle.ForeColor = Color.Navy;
                    }
                }
            }

        }

        private void Semana_Load(object sender, EventArgs e)
        {
            //aqui voy a guardar todos los dias ordenados
            List<List<Dia>> listaDeListasDias = new List<List<Dia>>();

            //aqui voy a guardar las fechas de la semana para consultarlas en la bdd
            List<DateTime> fechasDias = new List<DateTime>();



            //Aqui se guardan los empleados de la bdd
            List<Empleado> listaDeEmpleados = new List<Empleado>();


            semanaViernes = ObtenViernes(anterior, dias);



            fechasDias = ObtenDias(anterior, dias);
            listaDeListasDias = obtenDiasBDD(fechasDias);
            listaDeEmpleados = CargaEmpleadosBdd();

            CargaVariables();



            ProcesaListaSemanas(semanaViernes, anterior);

            CargaGrid();




            void CargaGrid()
            {
                DataGridSemana.DataSource = null;
                DataGridSemana.DataSource = listaDeSemanas;

                DataGridSemana.Columns["idChecador"].HeaderCell.Value = "Id_C";
                DataGridSemana.Columns["idChecador"].Name = "Id_C";

                DataGridSemana.Columns["porcentajeTe"].HeaderCell.Value = "%TE";
                DataGridSemana.Columns["porcentajeTe"].Name = "%TE";

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
                DataGridSemana.Columns["Comida"].Visible = false;
                DataGridSemana.Columns["FechaViernes"].Visible = false;
                DataGridSemana.Columns["SemanaPagada"].Visible = false;


                DataGridSemana.Columns["viernes"].HeaderCell.Value = "V";
                DataGridSemana.Columns["viernes"].Name = "V";
                DataGridSemana.Columns["viernesRetardo"].HeaderCell.Value = "VR";
                DataGridSemana.Columns["viernesRetardo"].Name = "VR";
                DataGridSemana.Columns["viernesSalida"].HeaderCell.Value = "VS";
                DataGridSemana.Columns["viernesSalida"].Name = "VS";
                DataGridSemana.Columns["viernesTE"].HeaderCell.Value = "VTE";
                DataGridSemana.Columns["viernesTE"].Name = "VTE";

                DataGridSemana.Columns["sabado"].HeaderCell.Value = "S";
                DataGridSemana.Columns["sabado"].Name = "S";
                DataGridSemana.Columns["sabadoRetardo"].HeaderCell.Value = "SR";
                DataGridSemana.Columns["sabadoRetardo"].Name = "SR";
                DataGridSemana.Columns["sabadoSalida"].HeaderCell.Value = "SS";
                DataGridSemana.Columns["sabadoSalida"].Name = "SS";
                DataGridSemana.Columns["sabadoTE"].HeaderCell.Value = "STE";
                DataGridSemana.Columns["sabadoTE"].Name = "STE";

                DataGridSemana.Columns["domingo"].HeaderCell.Value = "D";
                DataGridSemana.Columns["domingo"].Name = "D";
                DataGridSemana.Columns["domingoRetardo"].HeaderCell.Value = "DR";
                DataGridSemana.Columns["domingoRetardo"].Name = "DR";
                DataGridSemana.Columns["domingoSalida"].HeaderCell.Value = "DS";
                DataGridSemana.Columns["domingoSalida"].Name = "DS";
                DataGridSemana.Columns["domingoTE"].HeaderCell.Value = "DTE";
                DataGridSemana.Columns["domingoTE"].Name = "DTE";

                DataGridSemana.Columns["lunes"].HeaderCell.Value = "L";
                DataGridSemana.Columns["lunes"].Name = "L";
                DataGridSemana.Columns["lunesRetardo"].HeaderCell.Value = "LR";
                DataGridSemana.Columns["lunesRetardo"].Name = "LR";
                DataGridSemana.Columns["lunesSalida"].HeaderCell.Value = "LS";
                DataGridSemana.Columns["lunesSalida"].Name = "LS";
                DataGridSemana.Columns["lunesTE"].HeaderCell.Value = "LTE";
                DataGridSemana.Columns["lunesTE"].Name = "LTE";

                DataGridSemana.Columns["martes"].HeaderCell.Value = "M";
                DataGridSemana.Columns["martes"].Name = "M";
                DataGridSemana.Columns["martesRetardo"].HeaderCell.Value = "MR";
                DataGridSemana.Columns["martesRetardo"].Name = "MR";
                DataGridSemana.Columns["martesSalida"].HeaderCell.Value = "MS";
                DataGridSemana.Columns["martesSalida"].Name = "MS";
                DataGridSemana.Columns["martesTE"].HeaderCell.Value = "MTE";
                DataGridSemana.Columns["martesTE"].Name = "MTE";

                DataGridSemana.Columns["miercoles"].HeaderCell.Value = "X";
                DataGridSemana.Columns["miercoles"].Name = "X";
                DataGridSemana.Columns["miercolesRetardo"].HeaderCell.Value = "XR";
                DataGridSemana.Columns["miercolesRetardo"].Name = "XR";
                DataGridSemana.Columns["miercolesSalida"].HeaderCell.Value = "XS";
                DataGridSemana.Columns["miercolesSalida"].Name = "XS";
                DataGridSemana.Columns["miercolesTE"].HeaderCell.Value = "XTE";
                DataGridSemana.Columns["miercolesTE"].Name = "XTE";

                DataGridSemana.Columns["jueves"].HeaderCell.Value = "J";
                DataGridSemana.Columns["jueves"].Name = "J";
                DataGridSemana.Columns["juevesRetardo"].HeaderCell.Value = "JR";
                DataGridSemana.Columns["juevesRetardo"].Name = "JR";
                DataGridSemana.Columns["juevesSalida"].HeaderCell.Value = "JS";
                DataGridSemana.Columns["juevesSalida"].Name = "JS";
                DataGridSemana.Columns["juevesTE"].HeaderCell.Value = "JTE";
                DataGridSemana.Columns["juevesTE"].Name = "JTE";

                //cambio de descanso.
                DataGridSemana.Columns["Descanso"].HeaderCell.Value = "Dia Descanso";
                DataGridSemana.Columns["Descanso"].Name = "Dia Descanso";
                DataGridSemana.Columns["Descanso2"].HeaderCell.Value = "Descanso";
                DataGridSemana.Columns["Descanso2"].Name = "Descanso";




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
                col = new DataGridViewButtonColumn();
                col.UseColumnTextForButtonValue = true;
                col.Text = "";
                col.Name = "Imprimir";
                DataGridSemana.Columns.Add(col);
                col = new DataGridViewButtonColumn();
                col.UseColumnTextForButtonValue = true;
                col.Text = "";
                col.Name = "Pagado";
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



            Dia BuscaDia(int diaDeSemana, int idChecador) {
                Dia aux = new Dia();
                foreach (Dia dia in listaDeListasDias[diaDeSemana])
                {
                    if (dia.Id == idChecador)
                    {
                        aux = dia;
                        return aux;
                    }
                }


                return aux;
            }

            void ProcesaListaSemanas(string viernes, string anterior)
            {
                List<SemanaClass> semanasBdd = new List<SemanaClass>();
                semanasBdd = RecuperaSemanasBdd();

                bool incompleta = false;
                foreach (Empleado empleado in listaDeEmpleados)
                {


                    SemanaClass aux = new SemanaClass();
                    if (EmpleadoInBdd(empleado, semanasBdd, ref aux))
                    {
                        listaDeSemanas.Add(aux);
                    }
                    else
                    {
                        aux = ProcesaSemana(empleado);
                        if (anterior == "anterior")
                        {
                            if(aux.Viernes != "-")
                            {
                                InsertaSemana(aux);
                            }
                            else
                            {
                                listaDeSemanas.Clear();
                                MessageBox.Show("Semana vacía");
                                return;
                            }
                            if(aux.Jueves == "-")
                            {
                                incompleta = true;
                            }

                        }
                    }


                }
                if(incompleta)
                    MessageBox.Show("Semana incompleta, deberias procesar todos los días de la semana");

                List<SemanaClass> RecuperaSemanasBdd() {
                    List<SemanaClass> semanasBddAux = new List<SemanaClass>();
                    using (var connection = new MySqlConnection(conexion))
                    {
                        try
                        {
                            connection.Open();
                            MySqlDataAdapter adaptador = new MySqlDataAdapter("SELECT * FROM " + sucursal + ".Semanas where fecha_viernes = '" + semanaViernes + "' order by nombre", connection);
                            DataTable datos = new DataTable();
                            adaptador.Fill(datos);

                            //aqui obtenemos a los empleados de la base de datos y los almacenamos en una lista en memoria dinamica


                            for (int i = 0; i < datos.Rows.Count; i++)
                            {
                                SemanaClass auxiliar = new SemanaClass();
                                auxiliar.Id = int.Parse(datos.Rows[i]["id_empleado"].ToString());
                                auxiliar.IdChecador = int.Parse(datos.Rows[i]["id_checador"].ToString());
                                auxiliar.Nombre = datos.Rows[i]["nombre"].ToString();
                                auxiliar.SueldoImss = float.Parse(datos.Rows[i]["sueldo_imss"].ToString());
                                auxiliar.Turno = datos.Rows[i]["turno"].ToString();
                                auxiliar.EntradaDomingo = datos.Rows[i]["entrada_domingo"].ToString();
                                auxiliar.Entrada = datos.Rows[i]["entrada"].ToString();
                                auxiliar.Salida = datos.Rows[i]["salida"].ToString();
                                auxiliar.SueldoBase = float.Parse(datos.Rows[i]["sueldo_base"].ToString());
                                auxiliar.Bono = float.Parse(datos.Rows[i]["bono"].ToString());
                                auxiliar.PorcentajeTe = int.Parse(datos.Rows[i]["porcentaje_te"].ToString());
                                auxiliar.Descanso = datos.Rows[i]["dia_descanso"].ToString();
                                auxiliar.Viernes = datos.Rows[i]["v"].ToString();
                                auxiliar.ViernesRetardo = datos.Rows[i]["vr"].ToString();
                                auxiliar.ViernesSalida = datos.Rows[i]["vs"].ToString();
                                auxiliar.DomingoTE = datos.Rows[i]["dte"].ToString();
                                auxiliar.MartesTE = datos.Rows[i]["mte"].ToString();
                                auxiliar.JuevesTE = datos.Rows[i]["jte"].ToString();
                                auxiliar.CantidadAbono = float.Parse(datos.Rows[i]["cantidad_abono"].ToString());
                                auxiliar.ViernesTE = datos.Rows[i]["vte"].ToString();
                                auxiliar.Sabado = datos.Rows[i]["s"].ToString();
                                auxiliar.SabadoRetardo = datos.Rows[i]["sr"].ToString();
                                auxiliar.SabadoSalida = datos.Rows[i]["ss"].ToString();
                                auxiliar.SabadoTE = datos.Rows[i]["ste"].ToString();
                                auxiliar.Domingo = datos.Rows[i]["d"].ToString();
                                auxiliar.DomingoSalida = datos.Rows[i]["ds"].ToString();
                                auxiliar.Lunes = datos.Rows[i]["l"].ToString();
                                auxiliar.LunesRetardo = datos.Rows[i]["lr"].ToString();
                                auxiliar.LunesSalida = datos.Rows[i]["ls"].ToString();
                                auxiliar.LunesTE = datos.Rows[i]["lte"].ToString();
                                auxiliar.Martes = datos.Rows[i]["m"].ToString();
                                auxiliar.MartesRetardo = datos.Rows[i]["mr"].ToString();
                                auxiliar.MartesSalida = datos.Rows[i]["ms"].ToString();
                                auxiliar.Miercoles = datos.Rows[i]["x"].ToString();
                                auxiliar.MiercolesRetardo = datos.Rows[i]["xr"].ToString();
                                auxiliar.MiercolesSalida = datos.Rows[i]["xs"].ToString();
                                auxiliar.MiercolesTE = datos.Rows[i]["xte"].ToString();
                                auxiliar.Jueves = datos.Rows[i]["j"].ToString();
                                auxiliar.JuevesRetardo = datos.Rows[i]["jr"].ToString();
                                auxiliar.JuevesSalida = datos.Rows[i]["js"].ToString();
                                auxiliar.Descanso2 = int.Parse(datos.Rows[i]["descanso"].ToString());
                                auxiliar.DescansoT = int.Parse(datos.Rows[i]["descanso_t"].ToString());
                                auxiliar.DiasDescanso = int.Parse(datos.Rows[i]["dias_descanso"].ToString());
                                auxiliar.Incapacidad = int.Parse(datos.Rows[i]["incapacidad"].ToString());
                                auxiliar.Vacaciones = int.Parse(datos.Rows[i]["vacaciones"].ToString());
                                auxiliar.DiasTrabajados = int.Parse(datos.Rows[i]["dias_trabajados"].ToString());
                                auxiliar.DiasBono = int.Parse(datos.Rows[i]["dias_bono"].ToString());
                                auxiliar.BonoTotal = int.Parse(datos.Rows[i]["bono_total"].ToString());
                                auxiliar.TotalDiasPagados = int.Parse(datos.Rows[i]["total_dias_pagados"].ToString());
                                auxiliar.TotalDevengando = float.Parse(datos.Rows[i]["total_devengado"].ToString());
                                auxiliar.DescuentoIncapacidad = int.Parse(datos.Rows[i]["descuento_incapacidad"].ToString());
                                auxiliar.NominaFiscal = int.Parse(datos.Rows[i]["nomina_fiscal"].ToString());
                                auxiliar.Multa = int.Parse(datos.Rows[i]["multa"].ToString());
                                auxiliar.Multa2 = int.Parse(datos.Rows[i]["multa2"].ToString());
                                auxiliar.CantidadPrestamo = float.Parse(datos.Rows[i]["cantidad_prestamo"].ToString());
                                auxiliar.SaldoPrestamo = float.Parse(datos.Rows[i]["saldo_prestamo"].ToString());
                                auxiliar.CantidadHerramienta = float.Parse(datos.Rows[i]["cantidad_herramienta"].ToString());
                                auxiliar.AbonoHerramienta = float.Parse(datos.Rows[i]["abono_herramienta"].ToString());
                                auxiliar.Gorra = float.Parse(datos.Rows[i]["gorra"].ToString());
                                auxiliar.Trapo = float.Parse(datos.Rows[i]["trapo"].ToString());
                                auxiliar.TotalUniformes = float.Parse(datos.Rows[i]["total_uniformes"].ToString());
                                auxiliar.TotalRetardos = float.Parse(datos.Rows[i]["total_retardos"].ToString());
                                auxiliar.TotalSalidas = float.Parse(datos.Rows[i]["total_salidas"].ToString());
                                auxiliar.TotalDeducido = float.Parse(datos.Rows[i]["total_deducido"].ToString());
                                auxiliar.TotalPagado2 = float.Parse(datos.Rows[i]["total_pagado2"].ToString());
                                auxiliar.DomingoRetardo = datos.Rows[i]["dr"].ToString();
                                auxiliar.SemanaPagada = datos.Rows[i]["semana_pagada"].ToString();
                                DateTime aux = DateTime.Parse(datos.Rows[i]["fecha_viernes"].ToString());
                                auxiliar.FechaViernes = aux.ToString("yyyy-MM-dd");


                                semanasBddAux.Add(auxiliar);
                            }
                            connection.Close();
                            return semanasBddAux;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                    }



                    return semanasBddAux;
                }

                bool EmpleadoInBdd(Empleado empleadoAux, List<SemanaClass> semanasBddAux, ref SemanaClass semanaBddAux)
                {
                    foreach (SemanaClass semana in semanasBddAux)
                    {
                        if (semana.IdChecador == empleadoAux.IdChecador)
                        {
                            semanaBddAux = semana;
                            return true;
                        }

                    }
                    return false;
                }

            }

            SemanaClass ProcesaSemana(Empleado empleado)
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

                ProcesaDia(aux, viernes, empleado);
                ProcesaDia(aux, sabado, empleado);
                ProcesaDia(aux, domingo, empleado);
                ProcesaDia(aux, lunes, empleado);
                ProcesaDia(aux, martes, empleado);
                ProcesaDia(aux, miercoles, empleado);
                ProcesaDia(aux, jueves, empleado);
                //Falta procesar el pago semanal.
                aux.Bono = empleado.Bono;
                ProcesaPago(aux);

                listaDeSemanas.Add(aux);
                return aux;
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

                ProcesaBono();
                ProcesaComida();
                ProcesaTotalDevengado();
                ProcesaDeducido();
                DiasDescanso();
                //hacer descansos
                ProcesaTotalPagado();
                ProcesaDiasPagados();

                semana.TotalPagado2 = semana.TotalDevengando - semana.TotalDeducido;

                void ProcesaDiasPagados()
                {

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
                    if (semana.Martes == "D")
                        total += 1;

                    if (semana.Miercoles == "D")
                        total += 1;

                    if (semana.Jueves == "D")
                        total += 1;

                    if (semana.Viernes == "D")
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
                    aux = aux + semana.DomingoPago;
                    aux = aux + semana.LunesPago;
                    aux = aux + semana.MartesPago;
                    aux = aux + semana.MiercolesPago;
                    aux = aux + semana.JuevesPago;

                    semana.TotalPagado = aux + descanso;
                }
                void ProcesaTotalDevengado()
                {
                    float descanso = 0;
                    if (semana.Descanso2 == 1 || semana.DescansoT == 1)
                    {
                        descanso = ((semana.SueldoBase / 7) / 6) * semana.DiasTrabajados;
                    }
                    //hay que añadir bono y comidas

                    float aux = semana.TotalDevengando;
                    aux = aux + semana.ViernesTotal;
                    aux = aux + semana.SabadoTotal;
                    aux = aux + semana.DomingoTotal;
                    aux = aux + semana.LunesTotal;
                    aux = aux + semana.MartesTotal;
                    aux = aux + semana.MiercolesTotal;
                    aux = aux + semana.JuevesTotal;
                    semana.TotalDevengando = aux + descanso + semana.Bono + semana.TotalComida;

                }
                //FALTAN SALIDAS ETC.

                void ProcesaBono() {
                    if (Falta())
                    {
                        semana.DiasBono = 0;
                        semana.BonoTotal = 0;
                        return;
                    }
                    semana.DiasBono = semana.DiasTrabajados;
                    semana.Bono = (semana.Bono / 6) * semana.DiasBono;
                }
                void ProcesaComida()
                {
                    //PENDIENTE
                    semana.Comida = comida;
                    float aux = 0;

                    //comida por dia trabajado
                    if (semana.Viernes == "1")
                        aux = aux + semana.Comida;
                    if (semana.Lunes == "1")
                        aux = aux + semana.Comida;
                    if (semana.Martes == "1")
                        aux = aux + semana.Comida;
                    if (semana.Miercoles == "1")
                        aux = aux + semana.Comida;
                    if (semana.Jueves == "1")
                        aux = aux + semana.Comida;
                    if (semana.Viernes == "1")
                        aux = aux + semana.Comida;
                    if (semana.Sabado == "1")
                        aux = aux + semana.Comida;
                    if (semana.Domingo == "1")
                        aux = aux + semana.Comida;

                    //comida por turno extra
                    if (semana.ViernesTE == "SI")
                        aux = aux + semana.Comida;
                    if (semana.LunesTE == "SI")
                        aux = aux + semana.Comida;
                    if (semana.MartesTE == "SI")
                        aux = aux + semana.Comida;
                    if (semana.MiercolesTE == "SI")
                        aux = aux + semana.Comida;
                    if (semana.JuevesTE == "SI")
                        aux = aux + semana.Comida;
                    if (semana.ViernesTE == "SI")
                        aux = aux + semana.Comida;
                    if (semana.SabadoTE == "SI")
                        aux = aux + semana.Comida;
                    if (semana.DomingoTE == "SI")
                        aux = aux + semana.Comida;


                    semana.TotalComida = aux;
                }

                void ProcesaDeducido()
                {
                    //aqui vamos a cambiar los 100 por variables de la base de datos. tambien hacer con comidas.
                    float retardoAux = 0;
                    float salidaAux = 0;
                    if (semana.SueldoBase > sueldo_alto)
                    {
                        salidaAux = salida;
                        retardoAux = retardo;
                    }
                    else
                    {
                        salidaAux = salida_baja;
                        retardoAux = retardo_bajo;
                    }
                    float aux = 0;
                    if (semana.ViernesRetardo == "1")
                        aux = aux + retardoAux;
                    if (semana.LunesRetardo == "1")
                        aux = aux + retardoAux;
                    if (semana.MartesRetardo == "1")
                        aux = aux + retardoAux;
                    if (semana.MiercolesRetardo == "1")
                        aux = aux + retardoAux;
                    if (semana.JuevesRetardo == "1")
                        aux = aux + retardoAux;
                    if (semana.ViernesRetardo == "1")
                        aux = aux + retardoAux;
                    if (semana.SabadoRetardo == "1")
                        aux = aux + retardoAux;
                    if (semana.DomingoRetardo == "1")
                        aux = aux + retardoAux;

                    semana.TotalRetardos = aux;

                    if (semana.ViernesSalida == "1")
                        aux = aux + salidaAux;
                    if (semana.LunesSalida == "1")
                        aux = aux + salidaAux;
                    if (semana.MartesSalida == "1")
                        aux = aux + salidaAux;
                    if (semana.MiercolesSalida == "1")
                        aux = aux + salidaAux;
                    if (semana.JuevesSalida == "1")
                        aux = aux + salidaAux;
                    if (semana.ViernesSalida == "1")
                        aux = aux + salidaAux;
                    if (semana.SabadoSalida == "1")
                        aux = aux + salidaAux;
                    if (semana.DomingoSalida == "1")
                        aux = aux + salidaAux;

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

            void ProcesaDia(SemanaClass semana, Dia dia, Empleado empleado) {
                if (dia.Asistencia == null)
                {
                    return;
                }
                //validar cuando dia sea null
                DateTime fecha = new DateTime();
                fecha = DateTime.Parse(dia.Fecha);
                if (fecha.DayOfWeek.ToString() == "Friday")
                {
                    //Procesar los dias
                    semana.Viernes = ProcesaAsistencia(dia);
                    semana.ViernesRetardo = ProcesaRetardo(dia);
                    semana.ViernesSalida = ProcesaSalida(dia);
                    semana.ViernesTE = ProcesaTE(dia);
                    semana.ViernesPago = ProcesaPagoDiario(dia);
                    semana.ViernesTotal = ProcesaTotal(dia);
                }
                if (fecha.DayOfWeek.ToString() == "Saturday")
                {
                    //caso sabado
                    semana.Sabado = ProcesaAsistencia(dia);
                    semana.SabadoRetardo = ProcesaRetardo(dia);
                    semana.SabadoSalida = ProcesaSalida(dia);
                    semana.SabadoTE = ProcesaTE(dia);
                    semana.SabadoTotal = ProcesaPagoDiario(dia);
                    semana.SabadoPago = ProcesaTotal(dia);

                }
                if (fecha.DayOfWeek.ToString() == "Sunday")
                {
                    //caso domingo
                    semana.Domingo = ProcesaAsistencia(dia);
                    semana.DomingoRetardo = ProcesaRetardo(dia);
                    semana.DomingoSalida = ProcesaSalida(dia);
                    semana.DomingoTE = ProcesaTE(dia);
                    semana.DomingoTotal = ProcesaPagoDiario(dia);
                    semana.DomingoPago = ProcesaTotal(dia);
                }
                if (fecha.DayOfWeek.ToString() == "Monday")
                {
                    //caso Lunes
                    semana.Lunes = ProcesaAsistencia(dia);
                    semana.LunesRetardo = ProcesaRetardo(dia);
                    semana.LunesSalida = ProcesaSalida(dia);
                    semana.LunesTE = ProcesaTE(dia);
                    semana.LunesTotal = ProcesaPagoDiario(dia);
                    semana.LunesPago = ProcesaTotal(dia);
                }
                if (fecha.DayOfWeek.ToString() == "Tuesday")
                {
                    //caso Martes
                    semana.Martes = ProcesaAsistencia(dia);
                    semana.MartesRetardo = ProcesaRetardo(dia);
                    semana.MartesSalida = ProcesaSalida(dia);
                    semana.MartesTE = ProcesaTE(dia);
                    semana.MartesTotal = ProcesaPagoDiario(dia);
                    semana.MartesPago = ProcesaTotal(dia);
                }
                if (fecha.DayOfWeek.ToString() == "Wednesday")
                {
                    //caso Miercoles
                    semana.Miercoles = ProcesaAsistencia(dia);
                    semana.MiercolesRetardo = ProcesaRetardo(dia);
                    semana.MiercolesSalida = ProcesaSalida(dia);
                    semana.MiercolesTE = ProcesaTE(dia);
                    semana.MiercolesTotal = ProcesaPagoDiario(dia);
                    semana.MiercolesPago = ProcesaTotal(dia);
                }
                if (fecha.DayOfWeek.ToString() == "Thursday")
                {
                    //caso Jueves
                    semana.Jueves = ProcesaAsistencia(dia);
                    semana.JuevesRetardo = ProcesaRetardo(dia);
                    semana.JuevesSalida = ProcesaSalida(dia);
                    semana.JuevesTE = ProcesaTE(dia);
                    semana.JuevesTotal = ProcesaPagoDiario(dia);
                    semana.JuevesPago = ProcesaTotal(dia);
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
                float ProcesaPagoDiario(Dia diaAux)
                {
                    if (dia.DescansoTrabajado == "SI")
                    {
                        diaAux.Total = semana.SueldoBase / 7;
                        return semana.SueldoBase / 7;
                    }
                    if (dia.Asistencia == "Descansó")
                    {
                        diaAux.Total = 0;
                        return 0;
                    }
                    if (dia.Asistencia == "Asistió")
                    {
                        diaAux.Total = semana.SueldoBase / 7;
                        return semana.SueldoBase / 7;
                    }
                    if (dia.Asistencia == "Faltó")
                    {
                        diaAux.Total = 0;
                        return 0;
                    }
                    //vacaciones licencias etc.
                    return 0;
                    //semana sueldo base si asistió, etc. 
                }
                float ProcesaTotal(Dia diaAux)
                {
                    float total = 0;
                    total = diaAux.Total;

                    if (diaAux.TurnoExtra == "SI")
                    {
                        total += (semana.SueldoBase / 7) * (empleado.Porcentaje / 100);
                        total += semana.Comida;
                    }
                    if (diaAux.Asistencia == "Asistió")
                        total += semana.Comida;

                    if (diaAux.DescansoTrabajado == "SI")
                        total += semana.Comida;
                    return total;
                }

            }


            List<Empleado> CargaEmpleadosBdd()
            {
                List<Empleado> aux = new List<Empleado>();
                using (var connection = new MySqlConnection(conexion))
                {
                    try
                    {
                        connection.Open();
                        MySqlDataAdapter adaptador = new MySqlDataAdapter("SELECT * FROM " + sucursal + ".Empleados where fecha_ingreso < '" + semanaViernes + "' order by nombres", connection);
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
                            diaAux.Comida = 0;
                            diaAux.TurnoExtraPaga = float.Parse(datos.Rows[i]["turno_extra_paga"].ToString());
                            diaAux.Total = float.Parse(datos.Rows[i]["total"].ToString());
                            diaAux.Incidencia = datos.Rows[i]["incidencia"].ToString();
                            diaAux.DescansoTrabajado = datos.Rows[i]["descanso_trabajado"].ToString();
                            diaAux.Anotaciones = datos.Rows[i]["anotaciones"].ToString();
                            diaAux.HorasTrabajadas = datos.Rows[i]["horas_trabajadas"].ToString();
                            diaAux.HoraLlegada = datos.Rows[i]["hora_llegada"].ToString();
                            diaAux.HoraSalida = datos.Rows[i]["hora_salida"].ToString();
                            diaAux.SueldoDiario = float.Parse(datos.Rows[i]["sueldo_diario"].ToString());

                            if (diaAux.Fecha == fechas[0].ToString("yyyy-MM-dd"))
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
            List<DateTime> ObtenDias(string anterior, int dias) {

                // Obtener la fecha actual
                DateTime fechaActual = DateTime.Today;


                // Obtener el día de la semana actual
                int diaSemanaActual = (int)fechaActual.DayOfWeek;

                // Obtener la fecha del viernes anterior
                int diaViernes = (int)DayOfWeek.Friday;

                diaViernes = convierteDia(diaViernes);
                diaSemanaActual = convierteDia(diaSemanaActual);

                int diasAvanzar = 0;
                if (anterior == "anterior")
                {
                    diasAvanzar = (diaViernes - diaSemanaActual - dias);
                }
                else
                {
                    diasAvanzar = (diaViernes - diaSemanaActual + dias);
                }
                 

                DateTime fechaViernesAnterior = fechaActual.AddDays(diasAvanzar);

                // Obtener las fechas para cada día de la semana
                DateTime viernes = fechaViernesAnterior;
                DateTime sabado = viernes.AddDays(1);
                DateTime domingo = sabado.AddDays(1);
                DateTime lunes = domingo.AddDays(1);
                DateTime martes = lunes.AddDays(1);
                DateTime miercoles = martes.AddDays(1);
                DateTime jueves = miercoles.AddDays(1);

                List<DateTime> aux = new List<DateTime>();
                aux.Add(viernes);
                aux.Add(sabado);
                aux.Add(domingo);
                aux.Add(lunes);
                aux.Add(martes);
                aux.Add(miercoles);
                aux.Add(jueves);

                return aux;



            }

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

        public string ObtenViernes(string anterior, int dias)
        {
            // Obtener la fecha actual
            DateTime fechaActual = DateTime.Today;


            // Obtener el día de la semana actual
            int diaSemanaActual = (int)fechaActual.DayOfWeek;

            // Obtener la fecha del viernes anterior
            int diaViernes = (int)DayOfWeek.Friday;

            diaViernes = convierteDia(diaViernes);
            diaSemanaActual = convierteDia(diaSemanaActual);

            int diasAvanzar = 0;
            if (anterior == "anterior")
            {
                diasAvanzar = (diaViernes - diaSemanaActual - dias);
            }
            else
            {
                diasAvanzar = (diaViernes - diaSemanaActual + dias);
            }

            DateTime fechaViernesAnterior = fechaActual.AddDays(diasAvanzar);
            DateTime fechaJueves = fechaViernesAnterior.AddDays(6);

            //aprovecho para sacar el lbl de la semana
            lblSemanaLabel.Text = fechaViernesAnterior.ToString("dd/MM/yyyy") + " - " + fechaJueves.ToString("dd/MM/yyyy");
            if (anterior != "anterior")
                lblSemanaLabel.Text += "  (ACTUAL)";

            return fechaViernesAnterior.Year.ToString() + "-" + fechaViernesAnterior.Month.ToString() + "-" + fechaViernesAnterior.Day.ToString();
        }


        public int convierteDia(int dia)
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

        public bool InsertaSemana(SemanaClass semana)
        {
            string sqlString = "INSERT INTO " + sucursal + ".Semanas (id_checador,id_empleado,nombre,sueldo_imss,turno,entrada_domingo,entrada,salida,sueldo_base,bono,porcentaje_te,dia_descanso,v,vr,vs,dte,mte,jte,cantidad_abono,vte,s,sr,ss,ste,d,dr,ds,l,lr,ls,lte,m,mr,ms,x,xr,xs,xte,j,jr,js,descanso,descanso_t,dias_descanso,incapacidad,vacaciones,dias_trabajados,dias_bono,bono_total,total_dias_pagados,total_pagado,total_devengado,descuento_incapacidad,nomina_fiscal,multa,multa2,cantidad_prestamo,saldo_prestamo,cantidad_herramienta,abono_herramienta,gorra,trapo,total_uniformes,total_retardos,total_salidas,total_deducido,total_pagado2,fecha_viernes,semana_pagada\r\n) VALUES (";
            sqlString = sqlString + "'" + semana.IdChecador.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.Id.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.Nombre.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.SueldoImss.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.Turno.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.EntradaDomingo.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.Entrada.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.Salida.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.SueldoBase.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.Bono.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.PorcentajeTe.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.Descanso.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.Viernes.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.ViernesRetardo.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.ViernesSalida.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.DomingoTE.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.MartesTE.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.JuevesTE.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.CantidadAbono.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.ViernesTE.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.Sabado.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.SabadoRetardo.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.SabadoSalida.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.DomingoTE.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.Domingo.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.DomingoRetardo.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.DomingoSalida.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.Lunes.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.LunesRetardo.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.LunesSalida.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.LunesTE.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.Martes.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.MartesRetardo.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.MartesSalida.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.Miercoles.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.MiercolesRetardo.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.MiercolesSalida.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.MiercolesTE.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.Jueves.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.JuevesRetardo.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.JuevesSalida.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.Descanso2.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.DescansoT.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.DiasDescanso.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.Incapacidad.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.Vacaciones.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.DiasTrabajados.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.DiasBono.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.BonoTotal.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.TotalDiasPagados.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.TotalPagado.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.TotalDevengando.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.DescuentoIncapacidad.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.NominaFiscal.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.Multa.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.Multa2.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.CantidadPrestamo.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.SaldoPrestamo.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.CantidadHerramienta.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.AbonoHerramienta.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.Gorra.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.Trapo.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.TotalUniformes.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.TotalRetardos.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.TotalSalidas.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.TotalDeducido.ToString() + "'" + ",";
            sqlString = sqlString + "'" + semana.TotalPagado2.ToString() + "'" + ",";
            //revisar!!
            sqlString = sqlString + "'" + semanaViernes + "'" + ",";
            sqlString = sqlString + "'" + "NO" + "'"; // Último valor, no lleva coma al final
            sqlString = sqlString + ");"; // Cerramos la sentencia SQL
            using (var connection = new MySqlConnection(conexion))
            {
                try
                {
                    connection.Open();

                    MySqlCommand comando = new MySqlCommand(sqlString, connection);
                    comando.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error contactate con un administrador (" + ex.ToString() + ")");
                    return false;
                }
            }
        }

        private void DataGridSemana_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void DataGridSemana_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(modifica == true)
            {
                string[] editableColumns = { "V", "VR", "VS", "VTE", "S", "SR", "SS", "STE", "D", "DR", "DS", "DTE", "L", "LR", "LS", "LTE", "M", "MR", "MS", "MTE", "X", "XR", "XS", "XTE", "J", "JR", "JS", "JTE" }; 

                
                foreach (string columnIndex in editableColumns)
                {
                    if (e.ColumnIndex == DataGridSemana.Columns[columnIndex].Index && e.RowIndex >= 0)
                    {
                        //DataGridSemana.Rows[e.RowIndex].Cells["V"].Value = "5";
                        ModificaEmpleado(int.Parse(DataGridSemana.Rows[e.RowIndex].Cells["Id_C"].Value.ToString()));
                        MessageBox.Show("Valido");
                    }
                }
            }


            void ModificaEmpleado(int id)
            {

                //vamos a modificar la semana, luego a reprocesarla, y por ultimo a pasarla al datagrid.b 
                foreach (SemanaClass semana in listaDeSemanas)
                {
                    if (semana.IdChecador == id)
                    {
                        semana.Viernes = "Z";
                        break;
                    }
                }
            }
        }


    }
}
