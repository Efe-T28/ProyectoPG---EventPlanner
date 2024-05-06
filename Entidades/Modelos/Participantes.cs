using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Modelos
{
    public class Participantes
    {
        public Participantes() { }

        public int id { get; set; }

        public string cedula { get; set; }

        public string nombre { get; set; }

        public string apellidos { get; set; }

        public string telefono { get; set; }

        Ticket ticket { get; set; }
    }
}
