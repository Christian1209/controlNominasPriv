using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProcesadorNominaas
{
    public class SemanaClass
    {
        // Atributos
        private int id;
        private int idChecador;
        private string nombre;
        private float sueldoImss;
        private string turno;
        private string entradaDomingo;
        private string entrada;
        private string salida;
        private float sueldoBase;
        private int porcentajeTe;
        private string descanso;
        private string viernes = "-";
        private string viernesRetardo = "-";
        private string viernesSalida = "-";
        private string viernesTE = "-";
        private float viernesTotal = 0;
        private float viernesPago = 0;
        private string sabado = "-";
        private string sabadoRetardo = "-";
        private string sabadoSalida = "-";
        private string sabadoTE = "-";
        private float sabadoTotal = 0;
        private float sabadoPago = 0;
        private string domingo = "-";
        private string domingoRetardo = "-";
        private string domingoSalida = "-";
        private string domingoTE = "-";
        private float domingoTotal = 0;
        private float domingoPago = 0;
        private string lunes = "-";
        private string lunesRetardo = "-";
        private string lunesSalida = "-";
        private string lunesTE = "-";
        private float lunesPago = 0;
        private float lunesTotal = 0;
        private string martes = "-";
        private string martesRetardo = "-";
        private string martesSalida = "-";
        private string martesTE = "-";
        private float martesPago = 0;
        private float martesTotal = 0;
        private string miercoles = "-";
        private string miercolesRetardo = "-";
        private string miercolesSalida = "-";
        private string miercolesTE = "-";
        private float miercolesTotal = 0;
        private float miercolesPago = 0;
        private string jueves = "-";
        private string juevesRetardo = "-";
        private string juevesSalida = "-";
        private string juevesTE = "-";
        private float juevesTotal = 0;
        private float juevesPago = 0;
        //este descanso me sirve para saber si el empleado descanso.
        private int descanso2;
        private int descansoT;
        private int diasDescanso;
        private int diasTrabajados;
        private int incapacidad;
        private int vacaciones;
        private float totalDiasPagados;
        private float totalPagado = 0;
        private float totalDevengando = 0;
        private float descuentoIncapacidad = 0;
        private float nominaFiscal = 0;
        private float multa = 0;
        private float multa2 = 0;
        private string cantidadPrestamo = "0";
        private string cantidadAbono = "0";
        private string saldoPrestamo = "0";
        private string cantidadHerramienta = "0";
        private string abonoHerramienta = "0";
        private string gorra = "0";
        private string cubreboca = "0";
        private string trapo = "0";
        private string totalUniformes = "0";
        private float totalDeducido = 0;
        private float totalPagado2 = 0;
        private float bono;
        private int diasBono = 0;
        private float totalBono = 0;
        private float totalRetardos = 0;
        private float totalSalidas = 0;
     

        // Getters y Setters
        public int Id { get => id; set => id = value; }
        public int IdChecador { get => idChecador; set => idChecador = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public float SueldoImss { get => sueldoImss; set => sueldoImss = value; }
        public string Turno { get => turno; set => turno = value; }
        public string EntradaDomingo { get => entradaDomingo; set => entradaDomingo = value; }
        public string Entrada { get => entrada; set => entrada = value; }
        public string Salida { get => salida; set => salida = value; }
        public float SueldoBase { get => sueldoBase; set => sueldoBase = value; }
        public float Bono { get => bono; set => bono = value; }
        public int PorcentajeTe { get => porcentajeTe; set => porcentajeTe = value; }
        public String Descanso { get => descanso; set => descanso = value; }
        public string Viernes { get => viernes; set => viernes = value; }
        public string ViernesRetardo { get => viernesRetardo; set => viernesRetardo = value; }
        public string ViernesSalida { get => viernesSalida; set => viernesSalida = value; }
        public string ViernesTE { get => viernesTE; set => viernesTE = value; }

        public string Sabado { get => sabado; set => sabado = value; }
        public string SabadoRetardo { get => sabadoRetardo; set => sabadoRetardo = value; }
        public string SabadoSalida { get => sabadoSalida; set => sabadoSalida = value; }
        public string SabadoTE { get => sabadoTE; set => sabadoTE = value; }

        public string Domingo { get => domingo; set => domingo = value; }
        public string DomingoRetardo { get => domingoRetardo; set => domingoRetardo = value; }
        public string DomingoSalida { get => domingoSalida; set => domingoSalida = value; }
        public string DomingoTE { get => domingoTE; set => domingoTE = value; }

        public string Lunes { get => lunes; set => lunes = value; }
        public string LunesRetardo { get => lunesRetardo; set => lunesRetardo = value; }
        public string LunesSalida { get => lunesSalida; set => lunesSalida = value; }
        public string LunesTE { get => lunesTE; set => lunesTE = value; }

        public string Martes { get => martes; set => martes = value; }
        public string MartesRetardo { get => martesRetardo; set => martesRetardo = value; }
        public string MartesSalida { get => martesSalida; set => martesSalida = value; }
        public string MartesTE { get => martesTE; set => martesTE = value; }

        public string Miercoles { get => miercoles; set => miercoles = value; }
        public string MiercolesRetardo { get => miercolesRetardo; set => miercolesRetardo = value; }
        public string MiercolesSalida { get => miercolesSalida; set => miercolesSalida = value; }
        public string MiercolesTE { get => miercolesTE; set => miercolesTE = value; }

        public string Jueves { get => jueves; set => jueves = value; }
        public string JuevesRetardo { get => juevesRetardo; set => juevesRetardo = value; }
        public string JuevesSalida { get => juevesSalida; set => juevesSalida = value; }
        public string JuevesTE { get => juevesTE; set => juevesTE = value; }
        public int Descanso2 { get => descanso2; set => descanso2 = value; }
        public int DescansoT { get => descansoT; set => descansoT = value; }
        public int DiasDescanso { get => diasDescanso; set => diasDescanso = value; }
        public int Incapacidad { get => incapacidad; set => incapacidad = value; }
        public int Vacaciones { get => vacaciones; set => vacaciones = value; }
        public int DiasTrabajados { get => diasTrabajados; set => diasTrabajados = value; }
        public int DiasBono { get => diasBono; set => diasBono = value; }
        public float BonoTotal { get => bono; set => bono = value; }
        public float TotalDiasPagados { get => totalDiasPagados; set => totalDiasPagados = value; }
        public float LunesPago { get => lunesPago; set => lunesPago = value; }
        public float MartesPago { get => martesPago; set => martesPago = value; }
        public float MiercolesPago { get => miercolesPago; set => miercolesPago = value; }
        public float JuevesPago { get => juevesPago; set => juevesPago = value; }
        public float ViernesPago { get => viernesPago; set => viernesPago = value; }
        public float SabadoPago { get => sabadoPago; set => sabadoPago = value; }
        public float DomingoPago { get => domingoPago; set => domingoPago = value; }
        public float TotalPagado { get => totalPagado; set => totalPagado = value; }
        public float TotalDevengando { get => totalDevengando; set => totalDevengando = value; }
        public float DescuentoIncapacidad { get => descuentoIncapacidad; set => descuentoIncapacidad = value; }
        public float NominaFiscal { get => nominaFiscal; set => nominaFiscal = value; }
        public float Multa { get => multa; set => multa = value; }
        public float Multa2 { get => multa2; set => multa2 = value; }
        public string CantidadPrestamo { get => cantidadPrestamo; set => cantidadPrestamo = value; }
        public string CantidadAbono { get => cantidadAbono; set => cantidadAbono = value; }
        public string SaldoPrestamo { get => saldoPrestamo; set => saldoPrestamo = value; }
        public string CantidadHerramienta { get => cantidadHerramienta; set => cantidadHerramienta = value; }
        public string AbonoHerramienta { get => abonoHerramienta; set => abonoHerramienta = value; }
        public string Gorra { get => gorra; set => gorra = value; }
        public string Cubreboca { get => cubreboca; set => cubreboca = value; }
        public string Trapo { get => trapo; set => trapo = value; }
        public string TotalUniformes { get => totalUniformes; set => totalUniformes = value; }
        public float TotalRetardos { get => totalRetardos; set => totalRetardos = value; }
        public float TotalSalidas { get => totalSalidas; set => totalSalidas = value; }
        public float TotalDeducido { get => totalDeducido; set => totalDeducido = value; }
        public float TotalPagado2 { get => totalPagado2; set => totalPagado2 = value; }



        //no se muestran 
        public float LunesTotal { get => lunesTotal; set => lunesTotal = value; }
        public float MartesTotal { get => martesTotal; set => martesTotal = value; }
        public float MiercolesTotal { get => miercolesTotal; set => miercolesTotal = value; }
        public float JuevesTotal { get => juevesTotal; set => juevesTotal = value; }
        public float ViernesTotal { get => viernesTotal; set => viernesTotal = value; }
        public float SabadoTotal { get => sabadoTotal; set => sabadoTotal = value; }
        public float DomingoTotal { get => domingoTotal; set => domingoTotal = value; }

    }
}
