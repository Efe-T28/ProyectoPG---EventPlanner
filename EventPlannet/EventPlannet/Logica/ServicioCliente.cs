using Dato.Archivo;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ServicioCliente
    {
        private readonly RepositorioCliente repositorio;

        public ServicioCliente()
        {
            repositorio = new RepositorioCliente();
        }

        public string Crear(Cliente cliente)
        {
            try
            {
                Cliente clienteAnterior = repositorio.buscarCliente(cliente.cedula);
                if (clienteAnterior != null)
                {
                    return ("No se puede crear este Cliente, debido a que ya existe uno con esta identificación");
                }

                repositorio.Crear(cliente);
                return ($"El cliente {cliente.cedula} se ha creado correctamente");
            }
            catch (Exception ex)
            {
                return ($"Error al crear el cliente: {ex.Message}");
            }
        }

        public Cliente buscarCliente(string cedula)
        {
            return repositorio.buscarCliente(cedula);
        }

        public string Modificar(Cliente cliente)
        {
            if (repositorio.Modificar(cliente))
            {
                return "Cliente modificado exitosamente";
            }
            else
            {
                return "No se pudo modificar el cliente";
            }
        }

        public string Eliminar(string cedula)
        {
            if (repositorio.Eliminar(cedula))
            {
                return "Cliente eliminado exitosamente";
            }
            else
            {
                return "Error al eliminar";
            }
        }

        public List<Cliente> listaClientes()
        {
            return repositorio.listaClientes();
        }
    }
}
