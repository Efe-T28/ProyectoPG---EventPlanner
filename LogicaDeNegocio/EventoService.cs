using Datos;
using Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio
{
    public class EventoService
    {
        private readonly EventoRepository eventoRepository;
        public EventoService()
        {
            eventoRepository = new EventoRepository();
        }

        public string Guardar(Evento evento)
        {
            try
            {
                if (eventoRepository.ConsultarPorId(evento.Id) == null)
                {
                    eventoRepository.Guardar(evento);
                    return $"Éxito, se ha guardado los datos de: {evento.Id} ";
                }
                else
                {
                    return $"Lo sentimos, el evento con la identificación {evento.Id} ya se encuentra registrado";
                }
            }
            catch (Exception e)
            {
                return $"Error de la Aplicación: {e.Message}";
            }
        }

        public string Eliminar(int idEvento)
        {
            try
            {
                Evento evento = eventoRepository.ConsultarPorId(idEvento);
                if (evento != null)
                {
                    eventoRepository.Eliminar(idEvento);
                    return $"Se ha eliminado el evento con ID: {idEvento}";
                }
                else
                {
                    return $"Lo sentimos, no se encuentra el evento identificado con el {idEvento}";
                }
            }
            catch (Exception e)
            {
                return $"Error de la Aplicación: {e.Message}";
            }
        }

        public Evento ConsultarPorId(int idEvento)
        {
            return eventoRepository.ConsultarPorId(idEvento);
        }

        public List<Evento> GetEventos()
        {
            
            throw new NotImplementedException();
        }

        public void Modificar(Evento evento)
        {
           
            throw new NotImplementedException();
        }
    }
}
