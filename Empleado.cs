using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProcesadorNominaas
{
    public class Empleado
    {
        //datos que se obtienen de la base de datos
        private int id;
        private int idChecador;
        private string nombre;
        private string entrada;
        private string salidaEsperada;
        private string entradaDomingo;
        private float sueldo;
        private int bono;
        private int porcentaje;
        private string descanso;
        private string estatus;
        private string perdioDescanso;

        private float sueldoImss = 0;
        private string turno;


        //datos que se obtienen del archivo excel.
        private string nombreExcel;
        private string horaEntrada = "0";
        private string horaSalida = "0";
        private string sucursal;
        //datos que se obtienen del dia.
        private string fecha;
        private string asistencia = "";
        private string retardo = "NO";
        private string turnoExtra = "NO";
        private string turnoExtraPaga = "0";
        private string descansoTrabajado = "NO";
        private string anotaciones;
        private string incidencia;
        private string horasTrabajadas = "0";
        private string comida = "0";
        private string totalPagado = "0";
        private string salida = "NO";
        private float pagoDiario = 0;

        //variable para saber a partir de que horas se considera turno extra.
        private float horasParaTurnoExtra = 0;
        private float descuentoRetardoSalida = 0;


        public int Id { get => id; set => id = value; }
        public int IdChecador { get => idChecador; set => idChecador = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Entrada { get => entrada; set => entrada = value; }
        public string Salida { get => salida; set => salida = value; }
        public string EntradaDomingo { get => entradaDomingo; set => entradaDomingo = value; }
        public float SueldoImss { get => sueldoImss; set => sueldoImss = value; }
        public string Turno { get => turno; set => turno = value; }
        public float Sueldo { get => sueldo; set => sueldo = value; }
        public int Bono { get => bono; set => bono = value; }
        public int Porcentaje { get => porcentaje; set => porcentaje = value; }
        public string Descanso { get => descanso; set => descanso = value; }

        public string NombreExcel { get => nombreExcel; set => nombreExcel = value; }
        public string HoraEntrada { get => horaEntrada; set => horaEntrada = value; }
        public string HoraSalida { get => horaSalida; set => horaSalida = value; }
        public string Sucursal { get => sucursal; set => sucursal = value; }

        public string Fecha { get => fecha; set => fecha = value; }
        public string Asistencia { get => asistencia; set => asistencia = value; }
        public string Retardo { get => retardo; set => retardo = value; }
        public string TurnoExtra { get => turnoExtra; set => turnoExtra = value; }
        public string TurnoExtraPaga { get => turnoExtraPaga; set => turnoExtraPaga = value; }
        public string DescansoTrabajado { get => descansoTrabajado; set => descansoTrabajado = value; }
        public string Anotaciones { get => anotaciones; set => anotaciones = value; }
        public string HorasTrabajadas { get => horasTrabajadas; set => horasTrabajadas = value; }
        public string Comida { get => comida; set => comida = value; }

        public string TotalPagado { get => totalPagado; set => totalPagado = value; }   
        public string Incidencia { get => incidencia; set => incidencia = value; }  
        public string SalidaEsperada { get => salidaEsperada; set => salidaEsperada = value; }

        public string Estatus { get => estatus; set => estatus = value; }
        public string PerdioDescanso { get => perdioDescanso; set => perdioDescanso = value; }
        public float PagoDiario { get => pagoDiario; set => pagoDiario = value; }



        public Empleado( int idChecador) {
            this.idChecador = idChecador;
        }



       public Empleado() { }



    }
}
