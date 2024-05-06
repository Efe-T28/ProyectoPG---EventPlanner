using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio
{
    public class OrganizadorService
    {
        private readonly EventoRepository eventoRepository;
        public OrganizadorService()
        {
            eventoRepository = new EventoRepository();
        }

    }
}
