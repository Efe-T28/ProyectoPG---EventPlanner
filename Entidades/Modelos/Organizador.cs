using Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Modelos
{
    public class Organizador: Models
    {
        public Organizador()
        {
        }

        public Organizador(int id, string nombre, string usuario, string contraseña, string correo) 
        {
            Id = id;
            Nombre = nombre;
            Contraseña = contraseña;
            Usuario = usuario;
            Correo = correo;
        }

        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Usuario { get; set; }

        public string Contraseña { get; set; }

        public string Correo { get; set; }

        public List<Evento> List { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
