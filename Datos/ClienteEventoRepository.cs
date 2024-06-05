using Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Datos
{
    public class ClienteEventoRepository
    {
        string _eventosFilePath = "Evento.txt";
        string _participanteEventosFilePath = "ParticipanteEvento.txt";

        public List<Evento> ObtenerEventos()
        {
            var eventos = new List<Evento>();

            if (!File.Exists(_eventosFilePath))
            {
                return eventos;
            }

            var lines = File.ReadAllLines(_eventosFilePath);
            foreach (var line in lines)
            {
                var parts = line.Split('|');
                if (parts.Length == 3)
                {
                    eventos.Add(new Evento
                    {
                        Id = int.Parse(parts[0]),
                        NombreEvento = parts[1],
                        Fecha = DateTime.Parse(parts[2])
                    });
                }
            }

            return eventos;
        }

        public void RegistrarParticipanteEnEvento(int participanteId, int eventoId)
        {
            var registro = $"{participanteId}|{eventoId}";
            File.AppendAllText(_participanteEventosFilePath, registro + Environment.NewLine);
        }

        public List<ClienteEvento> ObtenerParticipanteEventos()
        {
            var participanteEvento = new List<ClienteEvento>();

            if (!File.Exists(_participanteEventosFilePath))
            {
                return participanteEvento;
            }

            var lines = File.ReadAllLines(_participanteEventosFilePath);
            foreach (var line in lines)
            {
                var parts = line.Split('|');
                if (parts.Length == 2)
                {
                    participanteEvento.Add(new ClienteEvento
                    {
                        ParticipanteId = int.Parse(parts[0]),
                        EventoId = int.Parse(parts[1])
                    });
                }
            }

            return participanteEvento;
        }
    }

    
}