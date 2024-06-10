using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Evento
    {
        public Evento() { }
        public string CodigoReserva {  get; set; }
        public Cliente Cliente { get; set; }
        public TipoEvento TipoEvento { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin {  get; set; }
        public DateTime FechaEvento { get; set; }
    }
}
