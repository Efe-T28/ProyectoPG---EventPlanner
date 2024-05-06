using Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Modelos
{
    public class Ticket : Models
    {
        public Ticket()
        {

        }

        public int id;
        public double precio { get; set; }

        public string estado { get; set; }

        public DateTime fechaRegistro { get; set; }

        public string asiento { get; set; }

        public Evento evento { get; set; }
    }
}
