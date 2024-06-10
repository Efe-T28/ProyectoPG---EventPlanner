using Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dato.Archivo
{
    public class RepositorioAdministrador
    {
        private readonly ConexionSQL conexionSQL;

        public RepositorioAdministrador()
        {
            conexionSQL = new ConexionSQL();
        }

        public Administrador ValidarAdministrador(string usuario, string contraseña)
        {
            Administrador administrador = null;

            try
            {
                using (SqlConnection conn = conexionSQL.GetConnection())
                {
                    string query = "SELECT * FROM Administrador WHERE usuario = @usuario AND contraseña = @contraseña";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@contraseña", contraseña);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        administrador = new Administrador
                        {
                            Id_Administrador = reader["id_administrador"].ToString(),
                            Usuario = reader["usuario"].ToString(),
                            Contraseña = reader["contraseña"].ToString()
                        };
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al validar el administrador: {ex.Message}");
            }

            return administrador;
        }
    }
}
