using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Administrador
    {
        public Administrador()
        {

        }

        public Administrador(string Id_Administrador, string Usuario, string Contraseña)
        {
            this.Id_Administrador = Id_Administrador;

            this.Usuario = Usuario;

            this.Contraseña = Contraseña;


        }

        public string Id_Administrador { get; set; }

        public string Usuario { get; set; }

        public string Contraseña { get; set; }
    }
}
