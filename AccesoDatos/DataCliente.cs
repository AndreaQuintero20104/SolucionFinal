﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class DataCliente
    {
        private SqlConnection conexion;

        public DataCliente()
        {
            conexion = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=MERCHBUCK;Data Source=DESKTOP-BLIRU0I\SQLEXPRESS");
        }

        public bool iniciaSesion(string cedula, string contrasena)
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
    }
}