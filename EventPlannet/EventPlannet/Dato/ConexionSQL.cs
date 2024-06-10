using System;
using Entidad;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dato
{
    public class ConexionSQL
    {

        private string conexionString;

        public ConexionSQL()
        {

            conexionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=DBEvent;User ID=sa;Password=root";
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(conexionString);
        }



    }
}
