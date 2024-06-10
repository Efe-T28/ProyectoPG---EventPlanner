using Entidad;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dato.Archivo
{
    public class RepositorioReserva
    {
        private readonly string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=DBEvent;User ID=sa;Password=root";
        private readonly RepositorioCliente repositorioCliente;

        public RepositorioReserva()
        {

            repositorioCliente = new RepositorioCliente();
        }

        public bool Crear(Reserva r)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Reserva (idReserva, cedulaCliente, fecha, horaInicio, horaFin, CodigoTipoEvento, observaciones, estado) VALUES (@IdReserva, @CedulaCliente, @Fecha, @HoraInicio, @HoraFin, @CodigoTipoEvento, @Observaciones, @Estado)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IdReserva", r.idReserva);
                    cmd.Parameters.AddWithValue("@CedulaCliente", r.cliente.cedula);
                    cmd.Parameters.AddWithValue("@Fecha", r.fecha);
                    cmd.Parameters.AddWithValue("@HoraInicio", r.horaInicio);
                    cmd.Parameters.AddWithValue("@HoraFin", r.horaFin);
                    cmd.Parameters.AddWithValue("@CodigoTipoEvento", r.tipoEvento);
                    cmd.Parameters.AddWithValue("@Observaciones", r.observaciones);
                    cmd.Parameters.AddWithValue("@Estado", r.estado);

                    cmd.ExecuteNonQuery();
                    return true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear la reserva: {ex.Message}");
                return false;
            }
        }

        
        public Reserva buscarReserva(int idReserva)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Reserva WHERE idReserva = @IdReserva";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IdReserva", idReserva);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return new Reserva
                        {
                            idReserva = Convert.ToInt32(reader["idReserva"]),
                            cliente = repositorioCliente.buscarCliente(reader["cedulaCliente"].ToString()),
                            fecha = Convert.ToDateTime(reader["fecha"]),
                            horaInicio = TimeSpan.Parse(reader["horaInicio"].ToString()),
                            horaFin = TimeSpan.Parse(reader["horaFin"].ToString()),
                            tipoEvento = reader["CodigoTipoEvento"].ToString(),
                            observaciones = reader["observaciones"].ToString(),
                            estado = reader["estado"].ToString()
                        };
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar la reserva: {ex.Message}");
                return null;
            }
        }

        public bool Modificar(Reserva reserva)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Reserva SET cedulaCliente = @CedulaCliente, fecha = @Fecha, horaInicio = @HoraInicio, horaFin = @HoraFin, CodigoTipoEvento = @CodigoTipoEvento, observaciones = @Observaciones, estado = @Estado WHERE idReserva = @IdReserva";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CedulaCliente", reserva.cliente.cedula);
                    cmd.Parameters.AddWithValue("@Fecha", reserva.fecha);
                    cmd.Parameters.AddWithValue("@HoraInicio", reserva.horaInicio);
                    cmd.Parameters.AddWithValue("@HoraFin", reserva.horaFin);
                    cmd.Parameters.AddWithValue("@CodigoTipoEvento", reserva.tipoEvento);
                    cmd.Parameters.AddWithValue("@Observaciones", reserva.observaciones);
                    cmd.Parameters.AddWithValue("@Estado", reserva.estado);
                    cmd.Parameters.AddWithValue("@IdReserva", reserva.idReserva);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar la reserva: {ex.Message}");
                return false;
            }
        }


        public List<Reserva> listaReservas()
        {
            List<Reserva> reservas = new List<Reserva>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT Reserva.*, TipoEvento.NombreTipoEvento 
                             FROM Reserva 
                             INNER JOIN TipoEvento ON Reserva.CodigoTipoEvento = TipoEvento.CodigoTipoEvento";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        reservas.Add(new Reserva
                        {
                            idReserva = Convert.ToInt32(reader["idReserva"]),
                            cliente = repositorioCliente.buscarCliente(reader["cedulaCliente"].ToString()),
                            fecha = Convert.ToDateTime(reader["fecha"]),
                            horaInicio = TimeSpan.Parse(reader["horaInicio"].ToString()),
                            horaFin = TimeSpan.Parse(reader["horaFin"].ToString()),
                            tipoEvento = reader["CodigoTipoEvento"].ToString(),
                            observaciones = reader["observaciones"].ToString(),
                            estado = reader["estado"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al listar las reservas: {ex.Message}");
            }
            return reservas;
        }


    }
}
