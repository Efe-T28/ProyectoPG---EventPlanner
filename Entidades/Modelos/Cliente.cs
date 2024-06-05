using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Modelos
{
    public class Cliente
    {
        public Cliente() { }

        public int Id { get; set; }

        public string Cedula { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public string Telefono { get; set; }

        Ticket ticket { get; set; }

        public Cliente(int id,string cedula, string nombre, string apellidos, string telefono)
        {
            Id = Id;
            Cedula = cedula;
            Nombre = nombre;
            Apellidos = apellidos;
            Telefono = telefono;
        }
    }
}
