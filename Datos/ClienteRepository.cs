using Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ClienteRepository
    {
        private readonly string participantesFile = "Participantes.txt";

        public List<Cliente> ObtenerParticipantes()
        {
            var participantes = new List<Cliente>();

            if (!File.Exists(participantesFile))
            {
                return participantes;
            }

            var lines = File.ReadAllLines(participantesFile);
            foreach (var line in lines)
            {
                var parts = line.Split('|');
                if (parts.Length == 5)
                {
                    participantes.Add(new Cliente
                    {
                        Id = int.Parse(parts[0]),
                        Cedula = parts[1],
                        Nombre = parts[2],
                        Apellidos = parts[3],
                        Telefono = parts[4]
                    });
                }
            }

            return participantes;
        }

        public void RegistrarParticipante(Cliente participante)
        {
            participante.Id = ObtenerNuevoId();
            File.AppendAllText(participantesFile, participante.ToString() + Environment.NewLine);
        }

        private int ObtenerNuevoId()
        {
            var participantes = ObtenerParticipantes();
            var idMaximo = participantes.Count == 0 ? 0 : participantes.Max(p => p.Id);
            Random random = new Random();
            int nuevoId;

            do
            {
               nuevoId = random.Next(idMaximo + 1, 20001); 
            } while (participantes.Any(p => p.Id == nuevoId)); 


            return nuevoId;
        }
    }
}
