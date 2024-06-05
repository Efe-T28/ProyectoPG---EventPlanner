using Datos;
using Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio
{
    public class ClienteEventoService
    {
        private readonly ClienteEventoRepository participanteRepositorio;

        public ClienteEventoService(ClienteEventoRepository participanteRepository)
        {
            participanteRepositorio = participanteRepository;
        }

        public List<Evento> ObtenerEventos()
        {
            return participanteRepositorio.ObtenerEventos().ToList();
        }

        public void RegistrarParticipanteEnEvento(int participanteId, int eventoId)
        {
            participanteRepositorio.RegistrarParticipanteEnEvento(participanteId, eventoId);
        }

        public List<ClienteEvento> ObtenerParticipanteEventos()
        {
            return participanteRepositorio.ObtenerParticipanteEventos().ToList();
        }
    }
}
