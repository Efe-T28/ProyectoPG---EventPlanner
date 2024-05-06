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

        public double montoFinal { get; set; }

        public double ingreso { get; set; }

        public double gastos { get; set; }

        public Evento evento { get; set; }
    }
}
