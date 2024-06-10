using Entidad;
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
    public class RepositorioFactura
    {
        private readonly string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=DBEvent;User ID=sa;Password=root";

        private int ObtenerNuevoIdFactura(SqlConnection conn, SqlTransaction transaction)
        {
            try
            {
                string query = "SELECT ISNULL(MAX(idFactura), 0) FROM Factura";
                SqlCommand cmd = new SqlCommand(query, conn, transaction);
                object result = cmd.ExecuteScalar();
                int nuevoIdFactura = Convert.ToInt32(result) + 1;
                return nuevoIdFactura;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el nuevo ID de la factura: {ex.Message}");
                return -1; 
            }
        }

        public bool Crear(Factura factura)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();

                   
                    int nuevoIdFactura = ObtenerNuevoIdFactura(connection, transaction);
                    if (nuevoIdFactura == -1) return false; 

                    string query = "INSERT INTO Factura (idFactura, idReserva, cliente, horas, TotalAPagar, estado) VALUES (@idFactura, @idReserva, @cliente, @horas, @TotalAPagar, @estado)";
                    SqlCommand command = new SqlCommand(query, connection, transaction);
                    command.Parameters.AddWithValue("@idFactura", nuevoIdFactura);
                    command.Parameters.AddWithValue("@idReserva", factura.idReserva);
                    command.Parameters.AddWithValue("@cliente", factura.cliente);
                    command.Parameters.AddWithValue("@horas", factura.horas);
                    command.Parameters.AddWithValue("@TotalAPagar", factura.TotalAPagar);
                    command.Parameters.AddWithValue("@estado", factura.estado);

                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear la factura: {ex.Message}");
                return false;
            }
        }
        
        public Factura BuscarFactura(int idFactura)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Factura WHERE idFactura = @idFactura";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@idFactura", idFactura);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        Factura factura = new Factura
                        {
                            idFactura = (int)reader["idFactura"],
                            idReserva = (int)reader["idReserva"],
                            cliente = (string)reader["cliente"],
                            horas = (int)reader["horas"],
                            TotalAPagar = (double)reader["TotalAPagar"],
                            estado = (string)reader["estado"]
                        };
                        return factura;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar la factura: {ex.Message}");
                return null;
            }
        }

        public bool Modificar(Factura factura)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Factura SET idReserva = @idReserva, cliente = @cliente, horas = @horas, TotalAPagar = @TotalAPagar, estado = @estado WHERE idFactura = @idFactura";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@idFactura", factura.idFactura);
                    command.Parameters.AddWithValue("@idReserva", factura.idReserva);
                    command.Parameters.AddWithValue("@cliente", factura.cliente);
                    command.Parameters.AddWithValue("@horas", factura.horas);
                    command.Parameters.AddWithValue("@TotalAPagar", factura.TotalAPagar);
                    command.Parameters.AddWithValue("@estado", factura.estado);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar la factura: {ex.Message}");
                return false;
            }
        }

        public List<Factura> ListaFacturas()
        {
            List<Factura> facturas = new List<Factura>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Factura";
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Factura factura = new Factura
                        {
                            idFactura = (int)reader["idFactura"],
                            idReserva = (int)reader["idReserva"],
                            cliente = (string)reader["cliente"],
                            horas = (int)reader["horas"],
                            TotalAPagar = (double)reader["TotalAPagar"],
                            estado = (string)reader["estado"]
                        };
                        facturas.Add(factura);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al listar las facturas: {ex.Message}");
            }
            return facturas;
        }
    }
}
