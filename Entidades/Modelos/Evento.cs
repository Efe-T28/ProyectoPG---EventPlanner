using Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Modelos
{
    public class Evento : Models
    {
           
        public Evento(int id, TimeSpan horaInicio, TimeSpan horaFin,string cedulaCliente,string tipoEvento, string direccion, string descripcion, string categoria, string nombreEvento, DateTime fecha, int capacidad, double montoTotal)
        {
            Id = id;
            HoraInicio = horaInicio;
            HoraFin = horaFin;
            CedulaCliente = cedulaCliente;
            TipoEvento = tipoEvento;
            Direccion = direccion;
            Descripcion = descripcion;
            Categoria = categoria;
            NombreEvento = nombreEvento;
            Fecha = fecha;
            Capacidad = capacidad;
            MontoTotal = montoTotal;
        }

        public Evento()
        {

        }

        public int Id { get; set; }
        public TimeSpan HoraInicio { get; set; }

        public TimeSpan HoraFin { get; set; }
        public string Direccion { get; set; }

        public string TipoEvento { get; set; }

        public string Descripcion { get; set; }

        public string CedulaCliente { get; set; }

        public string Categoria { get; set; }

        public string NombreEvento { get; set; }

        public DateTime Fecha { get; set; }

        public int Capacidad { get; set; }

        public double MontoTotal { get; set; }

        public List<Organizador> organizadores { get; set; }

    }
}
