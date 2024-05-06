using Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class EventoRepository
    {
        string FileName = "Evento.txt";

        public void Guardar(Evento evento)
        {
            FileStream file = new FileStream(FileName, FileMode.Append);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine($"{evento.Id};{evento.Direccion}; {evento.Descripcion}; {evento.Categoria}; {evento.NombreEvento}; {evento.Fecha}; {evento.Capacidad}; {evento.MontoTotal} ");
            writer.Close();
            file.Close();

        }

        public Evento ConsultarPorId(int id)
        {
            var eventos = LeerEventos();
            return eventos.FirstOrDefault(e => e.Id == id);
        }

        public List<Evento> ConsultarPorNombreYFecha(string nombreEvento, DateTime fecha)
        {
            var eventos = LeerEventos();
            return eventos.Where(e => e.NombreEvento == nombreEvento && e.Fecha == fecha).ToList();
        }


        public List<Evento> LeerEventos()
        {
            List<Evento> eventos = new List<Evento>();
            FileStream file = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            string linea = string.Empty;
            while ((linea = reader.ReadLine()) != null)
            {

                Evento evento = Map(linea);
                eventos.Add(evento);
            }
            reader.Close();
            file.Close();
            return eventos;
        }
        private Evento Map(string linea)
        {
            Evento evento = new Evento();
            char delimiter = ';';
            string[] matrizEvento = linea.Split(delimiter);
            evento.Id = int.Parse(matrizEvento[0]);
            evento.Direccion = matrizEvento[1];
            evento.Descripcion = matrizEvento[2];
            evento.Categoria = matrizEvento[3];
            evento.NombreEvento = matrizEvento[4];
            evento.Fecha = DateTime.Parse(matrizEvento[5]);
            evento.Capacidad = int.Parse(matrizEvento[6]);
            evento.MontoTotal = double.Parse(matrizEvento[7]);
            return evento;
        }

        public string Eliminar(Evento evento)
        {
            var eventos = LeerEventos();
            var eventoAEliminar = eventos.FirstOrDefault(e => e.Id != null);
            if (eventoAEliminar != null)
            {
                eventos.Remove(eventoAEliminar);
                GuardarEventos(eventos);
                return "evento eliminado";
            }
            return "no se encontro el evento";

        }

        private void GuardarEventos(List<Evento> eventos)
        {
            using (StreamWriter writer = new StreamWriter(FileName))
            {
                foreach (var evento in eventos)
                {
                    writer.WriteLine($"{evento.Id};{evento.Direccion};{evento.Descripcion};{evento.Categoria};{evento.NombreEvento};{evento.Fecha};{evento.Capacidad};{evento.MontoTotal}");
                }
            }
        }
        public Evento BuscarPorId(int idEvento)
        {
            throw new NotImplementedException();
        }

        public List<Evento> GetEventos()
        {
            var eventos = new List<Evento>();
            return eventos;
        }
    }
}
