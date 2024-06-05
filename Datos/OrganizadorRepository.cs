using Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class OrganizadorRepository
    {
        private readonly string organizadoresFile = "Organizadores.txt";

        public List<Organizador> ObtenerOrganizadores()
        {
            var organizadores = new List<Organizador>();

            if (!File.Exists(organizadoresFile))
            {
                return organizadores;
            }

            var lines = File.ReadAllLines(organizadoresFile);
            foreach (var line in lines)
            {
                var parts = line.Split('|');
                if (parts.Length == 5)
                {
                    organizadores.Add(new Organizador
                    {
                        Id = int.Parse(parts[0]),
                        Nombre = parts[1],
                        Usuario = parts[2],
                        Contraseña = parts[3],
                        Correo = parts[4]
                    });
                }
            }

            return organizadores;
        }

        public void RegistrarOrganizador(Organizador organizador)
        {
            organizador.Id = ObtenerNuevoId();
            File.AppendAllText(organizadoresFile, organizador.ToString() + Environment.NewLine);
        }

        private int ObtenerNuevoId()
        {
            var organizadores = ObtenerOrganizadores();
            var idMaximo = organizadores.Count == 0 ? 0 : organizadores.Max(p => p.Id);
            Random random = new Random();
            int nuevoId;

            do
            {
                nuevoId = random.Next(idMaximo + 1, 20001);
            } while (organizadores.Any(p => p.Id == nuevoId));

            return nuevoId;
        }
    }
}
