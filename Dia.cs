using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesadorNominaas
{
    public class Dia
    {
        private string nombre;
        private int id;
        private string fecha;
        private string asistencia;
        private string retardo;
        private string salida;
        private string turnoExtra;
        private int comida;
        private float turnoExtraPaga;
        private float total;
        private string incidencia;
        private string descansoTrabajado;
        private string anotaciones;
        private string horasTrabajadas;
        private string horaLlegada;
        private string horaSalida;
        private float sueldoDiario;
        private string diaSemana;

        public string DiaSemana { get => diaSemana; set => diaSemana = value; } 

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public string Asistencia
        {
            get { return asistencia; }
            set { asistencia = value; }
        }

        public string Retardo
        {
            get { return retardo; }
            set { retardo = value; }
        }

        public string Salida
        {
            get { return salida; }
            set { salida = value; }
        }
        public string TurnoExtra
        {
            get { return turnoExtra; }
            set { turnoExtra = value; }
        }
        public int Comida
        {
            get { return comida; }
            set { comida = value; }
        }

        public float TurnoExtraPaga
        {
            get { return turnoExtraPaga; }
            set { turnoExtraPaga = value; }
        }

        public float Total
        {
            get { return total; }
            set { total = value; }
        }

        public float Pago
        {
            get { return total; }
            set { total = value; }
        }


        public string Incidencia
        {
            get { return incidencia; }
            set { incidencia = value; }
        }

        public string DescansoTrabajado
        {
            get { return descansoTrabajado; }
            set { descansoTrabajado = value; }
        }
        public string Anotaciones
        {
            get { return anotaciones; }
            set { anotaciones = value; }
        }
        public string HorasTrabajadas
        {
            get { return horasTrabajadas; }
            set { horasTrabajadas = value; }
        }

        public string HoraLlegada
        {
            get { return horaLlegada; }
            set { horaLlegada = value; }
        }

        public string HoraSalida
        {
            get { return horaSalida; }
            set { horaSalida = value; }
        }

        public float SueldoDiario
        {
            get { return sueldoDiario; }
            set { sueldoDiario = value; }
        }
    }

}
