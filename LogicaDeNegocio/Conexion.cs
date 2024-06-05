using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LogicaDeNegocio
{
    public class Conexion
    {

        string cadenaConexion = "Data source =.\\SQLEXPRESS ;Initial Catalog=EventPlannerDB; Integrated Security = true";
        public SqlConnection conectarBD = new SqlConnection();

        public Conexion()
        {
            conectarBD.ConnectionString = cadenaConexion;

        }

        public void abrir()
        {

            try
            {
                conectarBD.Open();
                MessageBox.Show("se establecio la conexion");
            }
            catch (Exception e)
            {
                MessageBox.Show("no se pudo extablecer una conexion" + e.ToString());
            }

        } 

        public void cerrar() 
        { 
            conectarBD.Close();
        
        }
        //SqlConnection conex = new SqlConnection();

            //static string servidor = "localhost";
            //static string baseDeDatos = "BaseDeDatos";
            //static string usuario = "sa";
            //static string contraseña = "root";
            //static string puerto = "0";

            //string cadenaConexion = "Data source" + servidor + "," + puerto + ";" + "user id =" + usuario + ";" + "password =" + contraseña + ";" + "initial Catalog" + baseDeDatos + ";" + "PersistSecurity Info=true";

            //public SqlConnection establecerConexion()
            //{
            //    try
            //    {
            //        conex.ConnectionString = cadenaConexion;
            //        conex.Open();
            //        MessageBox.Show("se establcio la conexion");
            //    }
            //    catch (Exception e)
            //    {
            //        MessageBox.Show("no se pudo extablecer una conexion" + e.ToString());
            //    }



            //    return conex;
            //}
    }
}
