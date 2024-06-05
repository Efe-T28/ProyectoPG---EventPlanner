using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Modelos
{
    public class Fianza
    {
        public Fianza() { }

        public int id { get; set; }

        public string cedula { get; set; }

        public string nombre { get; set; }

        public double precio { get; set; }

        public int cantidad_horas { get; set; }

        public double total_pagar { get; set; }

        public double ingreso { get; set; }

        public double monto_final { get; set; }
        public Evento evento { get; set; }
    }
}
