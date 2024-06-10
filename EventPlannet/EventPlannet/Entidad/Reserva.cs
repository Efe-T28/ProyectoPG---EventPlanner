using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Reserva
    {
        public const double precio = 50000;
        public int idReserva { get; set; }
        public DateTime fecha { get; set; }
        public TimeSpan horaInicio { get; set; }
        public TimeSpan horaFin { get; set; }
        public Cliente cliente { get; set; }
        public string tipoEvento { get; set; }
        public string observaciones { get; set; }
        public string estado { get; set; }

        public const double ValorHora = 2000;

        public Reserva()
        {
            estado = "Pendiente";
        }
    }
}
