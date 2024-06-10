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
                return -1; // Devuelve -1 o cualquier otro valor para indicar que hubo un error
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

                    // Obtener el nuevo idFactura
                    int nuevoIdFactura = ObtenerNuevoIdFactura(connection, transaction);
                    if (nuevoIdFactura == -1) return false; // Manejar error en la obtención del nuevo idFactura

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
        //public bool Crear(Factura factura)
        //{
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            string query = "INSERT INTO Factura (idFactura, idReserva, cliente, horas, TotalAPagar, estado) VALUES (@idFactura, @idReserva, @cliente, @horas, @TotalAPagar, @estado)";
        //            SqlCommand command = new SqlCommand(query, connection);
        //            command.Parameters.AddWithValue("@idFactura", factura.idFactura);
        //            command.Parameters.AddWithValue("@idReserva", factura.idReserva);
        //            command.Parameters.AddWithValue("@cliente", factura.cliente);
        //            command.Parameters.AddWithValue("@horas", factura.horas);
        //            command.Parameters.AddWithValue("@TotalAPagar", factura.TotalAPagar);
        //            command.Parameters.AddWithValue("@estado", factura.estado);

        //            connection.Open();
        //            command.ExecuteNonQuery();
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error al crear la factura: {ex.Message}");
        //        return false;
        //    }
        //}

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

    
    //public class RepositorioFactura
    //{
    //    private readonly string FileName = "Facturas.txt";

    //    public bool Crear(Factura factura)
    //    {
    //        try
    //        {
    //            FileStream file = new FileStream(FileName, FileMode.Append);
    //            StreamWriter writer = new StreamWriter(file);
    //            writer.WriteLine($"{factura.idFactura};{factura.idReserva};{factura.cliente};{factura.horas};{factura.TotalAPagar};{factura.estado}");
    //            writer.Close();
    //            file.Close();
    //            return true;
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show($"Error al crear El cliente: {ex.Message}");
    //            return false;

    //        }
    //    }
    //    public Factura buscarFactura(int idFactura)
    //    {
    //        try
    //        {
    //            foreach (var factura in listaFacturas())
    //            {
    //                if (factura.idFactura == idFactura)
    //                {
    //                    return factura;
    //                }
    //            }
    //            return null;
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show($"Error al buscar por cedula: {ex.Message}");
    //            return null;
    //        }
    //    }
    //    public bool Modificar(Factura factura)
    //    {
    //        List<Factura> facturas = new List<Factura>();
    //        facturas = listaFacturas();

    //        try
    //        {
    //            FileStream file = new FileStream(FileName, FileMode.Create);
    //            file.Close();

    //            foreach (var facturaAnterior in facturas)
    //            {
    //                if (facturaAnterior.idFactura != factura.idFactura)
    //                {
    //                    Crear(facturaAnterior);
    //                }
    //                else
    //                    Crear(factura);
    //            }
    //            return true;
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show($"Error al modificar la factura: {ex.Message}");
    //            return false;
    //        }
    //    }
    //    public List<Factura> listaFacturas()
    //    {
    //        List <Factura> facturas = new List<Factura>();
    //        try
    //        {
    //            FileStream file = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Read);
    //            StreamReader reader = new StreamReader(file);
    //            string linea = string.Empty;
    //            while ((linea = reader.ReadLine()) != null)
    //            {
    //                Factura factura = Map(linea);
    //                facturas.Add(factura);
    //            }
    //            reader.Close();
    //            file.Close();
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show($"Error al listar los clientes: {ex.Message}");
    //        }
    //        return facturas;
    //    }
    //    private Factura Map(String linea)
    //    {
    //        try
    //        {
    //            Factura factura = new Factura();
    //            char delimiter = ';';
    //            string[] matrizFactura = linea.Split(delimiter);
    //            factura.idFactura = int.Parse(matrizFactura[0]);
    //            factura.idReserva = int.Parse(matrizFactura[1]);
    //            factura.cliente = matrizFactura[2];
    //            factura.horas = int.Parse(matrizFactura[3]);
    //            factura.TotalAPagar = double.Parse(matrizFactura[4]);
    //            factura.estado = matrizFactura[5];
    //            return factura;
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show($"Error al mapear: {ex.Message}");
    //            return null;
    //        }
    //    }
    //}
}
