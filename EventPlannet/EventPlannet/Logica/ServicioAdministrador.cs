using Dato.Archivo;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ServicioAdministrador
    {
        private readonly RepositorioAdministrador repositorioAdministrador;

        public ServicioAdministrador()
        {
            repositorioAdministrador = new RepositorioAdministrador();
        }

        public Administrador ValidarAdministrador(string usuario, string contraseña)
        {
            return repositorioAdministrador.ValidarAdministrador(usuario, contraseña);
        }
    }
}
