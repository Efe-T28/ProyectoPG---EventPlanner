using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Modelos
{
    public  class ClienteEvento:Cliente
    {
        public int ParticipanteId { get; set; }
        public int EventoId { get; set; }
    }
}
