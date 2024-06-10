﻿using Entidad;
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
    public class RepositorioCliente
    {
        private readonly string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=DBEvent;User ID=sa;Password=root";

        public bool Crear(Cliente cliente)
        {
            try
            {
                using (SqlConnection conn = new ConexionSQL().GetConnection())
                {
                    string queryPersona = "INSERT INTO Persona (Cedula, Nombre, Apellido, Telefono) VALUES (@Cedula, @Nombre, @Apellido, @Telefono)";
                    string queryCliente = "INSERT INTO Cliente (Cedula) VALUES (@Cedula)";

                    SqlCommand cmdPersona = new SqlCommand(queryPersona, conn);
                    SqlCommand cmdCliente = new SqlCommand(queryCliente, conn);

                    cmdPersona.Parameters.AddWithValue("@Cedula", cliente.cedula);
                    cmdPersona.Parameters.AddWithValue("@Nombre", cliente.nombre);
                    cmdPersona.Parameters.AddWithValue("@Apellido", cliente.apellido);
                    cmdPersona.Parameters.AddWithValue("@Telefono", cliente.telefono);

                    cmdCliente.Parameters.AddWithValue("@Cedula", cliente.cedula);

                    conn.Open();

                    SqlTransaction transaction = conn.BeginTransaction();
                    cmdPersona.Transaction = transaction;
                    cmdCliente.Transaction = transaction;

                    try
                    {
                        cmdPersona.ExecuteNonQuery();
                        cmdCliente.ExecuteNonQuery();
                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el cliente: {ex.Message}");
                return false;
            }
        }

        public Cliente buscarCliente(string cedula)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT Cedula, Nombre, Apellido, Telefono FROM Persona WHERE Cedula = @Cedula";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Cedula", cedula);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return new Cliente
                        {
                            cedula = reader["Cedula"].ToString(),
                            nombre = reader["Nombre"].ToString(),
                            apellido = reader["Apellido"].ToString(),
                            //telefono = int.Parse(reader["Telefono"].ToString())
                            telefono = reader["Telefono"].ToString(),
                        };
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar por cedula: {ex.Message}");
                return null;
            }
        }

        public bool Modificar(Cliente cliente)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Persona SET Nombre = @Nombre, Apellido = @Apellido, Telefono = @Telefono WHERE Cedula = @Cedula";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nombre", cliente.nombre);
                    cmd.Parameters.AddWithValue("@Apellido", cliente.apellido);
                    cmd.Parameters.AddWithValue("@Telefono", cliente.telefono);
                    cmd.Parameters.AddWithValue("@Cedula", cliente.cedula);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el cliente: {ex.Message}");
                return false;
            }
        }

        public bool Eliminar(string cedula)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();


                    string checkClienteQuery = "SELECT COUNT(*) FROM Cliente WHERE cedula = @Cedula";
                    SqlCommand checkClienteCmd = new SqlCommand(checkClienteQuery, conn);
                    checkClienteCmd.Parameters.AddWithValue("@Cedula", cedula);
                    int clienteCount = (int)checkClienteCmd.ExecuteScalar();

                    if (clienteCount > 0)
                    {

                        string deleteClienteQuery = "DELETE FROM Cliente WHERE cedula = @Cedula";
                        SqlCommand deleteClienteCmd = new SqlCommand(deleteClienteQuery, conn);
                        deleteClienteCmd.Parameters.AddWithValue("@Cedula", cedula);
                        deleteClienteCmd.ExecuteNonQuery();
                    }


                    string deletePersonaQuery = "DELETE FROM Persona WHERE cedula = @Cedula";
                    SqlCommand deletePersonaCmd = new SqlCommand(deletePersonaQuery, conn);
                    deletePersonaCmd.Parameters.AddWithValue("@Cedula", cedula);
                    deletePersonaCmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el cliente: {ex.Message}");
                return false;
            }
        }



        public List<Cliente> listaClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT Cedula, Nombre, Apellido, Telefono FROM Persona";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        clientes.Add(new Cliente
                        {
                            cedula = reader["Cedula"].ToString(),
                            nombre = reader["Nombre"].ToString(),
                            apellido = reader["Apellido"].ToString(),
                            //telefono = int.Parse(reader["Telefono"].ToString())
                            telefono = reader["Telefono"].ToString(),
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al listar los clientes: {ex.Message}");
            }
            return clientes;
        }
        //public class RepositorioCliente
        //{

        //    private readonly string FileName = "Clientes.txt";

        //    public bool Crear(Cliente cliente)
        //    {
        //        try
        //        {
        //            FileStream file = new FileStream(FileName, FileMode.Append);
        //            StreamWriter writer = new StreamWriter(file);
        //            writer.WriteLine($"{cliente.cedula};{cliente.nombre};{cliente.apellido};{cliente.telefono}");
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

        //    public Cliente buscarCliente(string cedula)
        //    {
        //        try
        //        {
        //            foreach (var cliente in listaClientes())
        //            {
        //                if (cedula == cliente.cedula)
        //                {
        //                    return cliente;
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
        //    public bool Modificar(Cliente cliente) 
        //    {
        //        List<Cliente> clientes = new List<Cliente>();
        //        clientes = listaClientes();

        //        try
        //        {
        //            FileStream file = new FileStream(FileName, FileMode.Create);
        //            file.Close();

        //            foreach (var ClienteAnterior in clientes)
        //            {
        //                if (ClienteAnterior.cedula != cliente.cedula)
        //                {
        //                    Crear(ClienteAnterior);
        //                }
        //                else
        //                    Crear(cliente);
        //            }
        //            return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Error al modificar el cliente: {ex.Message}");
        //            return false;
        //        }
        //    }

        //    public bool Eliminar(string cedula)
        //    {
        //        List<Cliente> clientes = new List<Cliente>();
        //        clientes = listaClientes();

        //        try
        //        {
        //            FileStream file = new FileStream(FileName, FileMode.Create);
        //            file.Close();

        //            foreach (var cliente in clientes)
        //            {
        //                if (cliente.cedula != cedula)
        //                {
        //                    Crear(cliente);
        //                }
        //            }
        //            return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Error al elminar el cliente: {ex.Message}");
        //            return false;
        //        }
        //    }

        //    public List<Cliente> listaClientes()
        //    {
        //        List<Cliente> clientes = new List<Cliente>();
        //        try
        //        {
        //            FileStream file = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Read);
        //            StreamReader reader = new StreamReader(file);
        //            string linea = string.Empty;
        //            while ((linea = reader.ReadLine()) != null)
        //            {
        //                Cliente cliente = Map(linea);
        //                clientes.Add(cliente);
        //            }
        //            reader.Close();
        //            file.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Error al listar los clientes: {ex.Message}");
        //        }
        //        return clientes;
        //    }
        //    private Cliente Map(String linea)
        //    {
        //        try
        //        {
        //            Cliente cliente = new Cliente();
        //            char delimiter = ';';
        //            string[] matrizCliente = linea.Split(delimiter);
        //            cliente.cedula = matrizCliente[0];
        //            cliente.nombre = matrizCliente[1];
        //            cliente.apellido = matrizCliente[2];
        //            cliente.telefono = int.Parse((matrizCliente[3]));

        //            return cliente;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Error al mapear: {ex.Message}");
        //            return null;
        //        }
        //    }
        //}
    }
}