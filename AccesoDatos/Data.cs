using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio;

namespace AccesoDatos
{
    public class Data : FuenteDatosRepository
    {
        private SqlConnection conexion;

        public Data()
        {
            conexion = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=MERCHBUCK;Data Source=DESKTOP-BLIRU0I\SQLEXPRESS");
        }

        public bool iniciarSesion(string cedula, string contrasena)
        {
            bool resultado = false;

            conexion.Open();

            string select = string.Format("Select Cedula FROM Clientes WHERE Cedula = {0} and Contraseña = {1}", cedula, contrasena);

            SqlCommand comando = new SqlCommand(select, conexion);
            SqlDataReader registros = comando.ExecuteReader();

            if (registros.HasRows)
            {
                resultado = true;
            }

            conexion.Close();

            return resultado;
        }

        public bool iniciarSesionAdministradores(int cedula, string contrasena)
        {
            bool resultado = false;

            conexion.Open();

            string select = string.Format("Select Cedula FROM Administradores WHERE Cedula = {0} and Contraseña = {1}", cedula, contrasena);

            SqlCommand comando = new SqlCommand(select, conexion);
            SqlDataReader registros = comando.ExecuteReader();

            if (registros.HasRows)
            {
                resultado = true;
            }

            conexion.Close();

            return resultado;
        }
    }
}
