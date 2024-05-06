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
                    return $"Exito, se ha guardado los datos de: {evento.NombreEvento} ";
                }
                else
                {
                    return $"Lo sentimos, con la Identificación {evento.Id} ya se encuentra registrada";
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicacion: {e.Message}";
            }
        }
        public string Eliminar(Evento evento)
        {
            try
            {
                if (eventoRepository.ConsultarPorId(evento.Id) != null)
                {
                    eventoRepository.Eliminar(evento);
                    return ($"se han guardado los datos de:  {evento.NombreEvento} ");
                }
                else
                {
                    return ($"Lo sentimos, no se encuentra el evento identificado con el  {evento.Id}");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicacion: {e.Message}";
            }

        }

        public Evento ConsultarPorId(int idEvento)
        {

            Evento evento = eventoRepository.BuscarPorId(idEvento);
            if (evento == null)
            {
                return null;
            }
            return evento;
        }
        public List<Evento> GetEventos()
        {
            var eventos = new List<Evento>();
            return eventos;
        }
        public void Modificar(Evento evento)
        {

            var eventos = GetEventos();
            var eventoToUpdate = eventos.FirstOrDefault(e => e.Id == evento.Id);

            if (eventoToUpdate != null)
            {

                eventoToUpdate.Id = evento.Id;
                eventoToUpdate.Direccion = evento.Direccion;
                eventoToUpdate.Descripcion = evento.Descripcion;
                eventoToUpdate.Categoria = evento.Categoria;
                eventoToUpdate.NombreEvento = evento.NombreEvento;
                eventoToUpdate.Fecha = evento.Fecha;
                eventoToUpdate.Capacidad = evento.Capacidad;
                eventoToUpdate.MontoTotal = evento.MontoTotal;
            }

            else
            {
                Console.WriteLine($"No se encontró el evento con ID: {evento.Id}");
            }
            
        }
    }
}
