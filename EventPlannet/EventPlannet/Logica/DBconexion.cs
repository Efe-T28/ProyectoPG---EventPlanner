using Dato;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class DBconexion
    {
        private ConexionSQL conexionSQL;

        public DBconexion()
        {
            conexionSQL = new ConexionSQL();
        }

        public DataTable ObtenerDatos()
        {
            using (SqlConnection conn = conexionSQL.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM cliente";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener datos: " + ex.Message);
                }
            }
        }

    }
}
