using Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Modelos
{
    public class Organizador : Models
    {
        public Organizador()
        {

        }

        int id { get; set; }

        string nombre { get; set; }

        string usuario { get; set; }

        string contraseña { get; set; }

        string correo { get; set; }

        public List<Evento> List { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
