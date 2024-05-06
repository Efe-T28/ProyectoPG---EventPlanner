using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Modelos
{
    public class TipoEvento
    {
        public TipoEvento() { }

        public int Id { get; set; }
        public string nombre { get; set; }
        public Evento evento { get; set; }
    }
}
