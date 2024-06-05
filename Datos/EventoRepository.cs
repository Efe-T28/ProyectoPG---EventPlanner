using Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class EventoRepository
    {
        private string connectionString = "Server=.\\SQLEXPRESS;Database=EventPlannerDB;User Id=sa;Password=root;";

        public void Guardar(Evento evento)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO EVENTO (id_evento, Fecha, Hora_inicio, Hora_fin, Cedula_cliente, Tipo_evento, id_usuario) " +
                               "VALUES (@Id, @Fecha, @HoraInicio, @HoraFin, @CedulaCliente, @TipoEvento, @IdUsuario)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", evento.Id);
                    command.Parameters.AddWithValue("@Fecha", evento.Fecha);
                    command.Parameters.AddWithValue("@HoraInicio", evento.HoraInicio);
                    command.Parameters.AddWithValue("@HoraFin", evento.HoraFin);
                    command.Parameters.AddWithValue("@CedulaCliente", evento.CedulaCliente);
                    command.Parameters.AddWithValue("@TipoEvento", evento.TipoEvento);
                    //command.Parameters.AddWithValue("@IdUsuario", evento.IdUsuario);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public Evento ConsultarPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM EVENTO WHERE id_evento = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return Map(reader);
                        }
                    }
                }
            }
            return null;
        }

        public List<Evento> ConsultarFecha(string nombreEvento, DateTime fecha)
        {
            List<Evento> eventos = new List<Evento>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM EVENTO WHERE nombre_evento = @NombreEvento AND fecha_hora = @Fecha";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    //command.Parameters.AddWithValue("@NombreEvento", nombreEvento);
                    command.Parameters.AddWithValue("@Fecha", fecha);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            eventos.Add(Map(reader));
                        }
                    }
                }
            }
            return eventos;
        }

        public string Eliminar(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM EVENTO WHERE id_evento = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0 ? "Evento eliminado" : "No se encontró el evento";
                }
            }
        }

        private Evento Map(SqlDataReader reader)
        {
            return new Evento
            {
                Id = (int)reader["id_evento"],
                Fecha = (DateTime)reader["Fecha"],
                HoraInicio = (TimeSpan)reader["Hora_inicio"],
                HoraFin = (TimeSpan)reader["Hora_fin"],
                CedulaCliente = reader["Cedula_cliente"].ToString(),
                TipoEvento = reader["Tipo_evento"].ToString(),
                //IdUsuario = (int)reader["id_usuario"]
            };
        }
    }
}