using System;
using System.Collections.Generic;
using System.Data;
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

        public void RegistrarCliente(string cedula, string contraseña, string nombre, string celular, string telefono,DateTime fechanac, string direccion, string email)
        {
            conexion.Open();

            string insert = string.Format("INSERT INTO [dbo].[Clientes] ([Cedula] ,[Contraseña] ,[Nombre] ,[Celular] ,[Telefono] ," +
                "[FechaNacimiento] ,[Direccion] ,[Email]) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",
                cedula, contraseña,nombre, celular,telefono, fechanac.ToShortDateString(), direccion, email);

            SqlCommand comando = new SqlCommand(insert, conexion);

            comando.ExecuteNonQuery();
            conexion.Close();
        }

        public bool iniciarSesion(string cedula, string contrasena)
        {
            bool resultado = false;

            conexion.Open();

            string select = string.Format("Select Cedula FROM Clientes WHERE Cedula = {0} and Contraseña = '{1}'", cedula, contrasena);

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

            string select = string.Format("Select Cedula FROM Administradores WHERE Cedula = {0} and Contraseña = '{1}'", cedula, contrasena);

            SqlCommand comando = new SqlCommand(select, conexion);
            SqlDataReader registros = comando.ExecuteReader();

            if (registros.HasRows)
            {
                resultado = true;
            }

            conexion.Close();

            return resultado;
        }

        public bool iniciarSesionDueños(int cedula, string contrasena)
        {
            bool resultado = false;

            conexion.Open();

            string select = string.Format("Select Cedula FROM Dueños WHERE Cedula = {0} and Contraseña = '{1}'", cedula, contrasena);

            SqlCommand comando = new SqlCommand(select, conexion);
            SqlDataReader registros = comando.ExecuteReader();

            if (registros.HasRows)
            {
                resultado = true;
            }

            conexion.Close();

            return resultado;
        }

        public List<string> MostrarEstablecimientos()
        {
            List<string> lst = new List<string>();

            conexion.Open();

            string select = string.Format("Select nombre FROM Establecimientos");

            SqlCommand comando = new SqlCommand(select, conexion);
            SqlDataReader registros = comando.ExecuteReader();

          
            while (registros.Read())
            {
                lst.Add(registros[0].ToString());
            }

            conexion.Close();

            return lst;
        }

        public List<string> MostrarProfesionales(string nombreEstab)
        {
            List<string> lst = new List<string>();

            conexion.Open();

            string select = string.Format("select Profesionales.Nombre from ProfesionalesXEstablecimientos inner join Profesionales " +
                "on IDProfesional = Profesionales.ID inner join Establecimientos on IDEstablecimiento = Establecimientos.ID" +
                " Where Establecimientos.Nombre = '{0}'", nombreEstab);

            SqlCommand comando = new SqlCommand(select, conexion);
            SqlDataReader registros = comando.ExecuteReader();


            while (registros.Read())
            {
                lst.Add(registros[0].ToString());
            }

            conexion.Close();

            return lst;
        }

        public List<string> MostrarServicios(string nombreProf)
        {
            List<string> lst = new List<string>();

            conexion.Open();

            string select = string.Format("select Servicios.Nombre from ProfesionalesXServicios inner join " +
                "Profesionales on IDProfesional = Profesionales.ID inner join Servicios on IDServicio = Servicios.ID " +
                "Where Profesionales.Nombre = '{0}'", nombreProf);

            SqlCommand comando = new SqlCommand(select, conexion);
            SqlDataReader registros = comando.ExecuteReader();


            while (registros.Read())
            {
                lst.Add(registros[0].ToString());
            }

            conexion.Close();

            return lst;
        }

        public List<string> MostrarFechas(string nombreProf)
        {
            List<string> lst = new List<string>();

            conexion.Open();

            string select = string.Format("select CONVERT(varchar, Agendas.Dia,10) from Agendas inner join Profesionales " +
                "on IDProfesional = Profesionales.ID Where Profesionales.Nombre = '{0}' " +
                "and Agendas.Estado = 1", nombreProf);

            SqlCommand comando = new SqlCommand(select, conexion);
            SqlDataReader registros = comando.ExecuteReader();


            while (registros.Read())
            {
                lst.Add(registros[0].ToString());
            }

            conexion.Close();

            return lst;
        }

        public List<string> MostrarHoras(string nombreProf, DateTime fecha)
        {
            List<string> lst = new List<string>();

            conexion.Open();

            string select = string.Format("select Agendas.Hora from Agendas inner join Profesionales " +
                "on IDProfesional = Profesionales.ID Where profesionales.Nombre = '{0}' and " +
                "Agendas.Dia = '{1}'", nombreProf, fecha.ToShortDateString());

            SqlCommand comando = new SqlCommand(select, conexion);
            SqlDataReader registros = comando.ExecuteReader();


            while (registros.Read())
            {
                lst.Add(registros[0].ToString());
            }

            conexion.Close();

            return lst;
        }

        public void AgregarCita(string idCliente, string establecimiento, string profesional, string tipoServicio, DateTime fecha, string hora, string observaciones)
        {
            conexion.Open();

            string insert = string.Format("INSERT INTO [dbo].[Citas] ([IDCliente] ,[IDEstablecimiento] ,[Profesional] ," +
                "[TipoServicio] ,[Dia] ,[Hora] ,[Observaciones]) VALUES ((select id from Clientes where Cedula = '{0}'), " +
                "(select id from Establecimientos where Nombre = '{1}'), '{2}', '{3}', '{4}', " +
                "'{5}','{6}'); " +
                "" +
                "UPDATE[dbo].[Agendas] SET[Estado] = 0 WHERE Agendas.ID = (select agendas.ID from Agendas inner " +
                "join Profesionales on Agendas.IDProfesional = Profesionales.ID where " +
                "Profesionales.Nombre = '{2}' and Dia = '{4}' and Hora = '{5}')", idCliente, establecimiento, 
                profesional, tipoServicio, fecha.ToShortDateString(), hora, observaciones );

            SqlCommand comando = new SqlCommand(insert, conexion);

            comando.ExecuteNonQuery();
            conexion.Close();
        }

        public DataTable VerMisCitas(string idCliente)
        {
            DataTable dtCitas = new DataTable();

            conexion.Open();

            string select = string.Format("SELECT Citas.ID, Establecimientos.Nombre as 'Establecimiento', Profesional, TipoServicio,Dia,Hora " +
                "FROM Citas inner join Clientes on Citas.IDCliente = Clientes.ID inner join Establecimientos on " +
                "IDEstablecimiento = Establecimientos.ID WHERE Cedula = '{0}' ", idCliente);

            SqlCommand comando = new SqlCommand(select, conexion);
            SqlDataReader registros = comando.ExecuteReader();
            dtCitas.Load(registros);

            conexion.Close();

            return dtCitas;

        }

        public void CancelarCita(int idCita, string profesional, DateTime fecha, string hora)
        {
            conexion.Open();

            string insert = string.Format("DELETE Citas WHERE ID = '{0}' " +
                "" +
                "UPDATE[dbo].[Agendas] SET[Estado] = 1 WHERE Agendas.ID = (select agendas.ID " +
                "from Agendas inner join Profesionales on Agendas.IDProfesional = Profesionales.ID where " +
                "Profesionales.Nombre = '{1}' and Dia = '{2}' and Hora = '{3}')", idCita, profesional, fecha.ToShortDateString(), hora);

            SqlCommand comando = new SqlCommand(insert, conexion);

            comando.ExecuteNonQuery();
            conexion.Close();
        }

        public List<string> EstablecimientosXAdministrador(string cedula)
        {
            List<string> lst = new List<string>();

            conexion.Open();

            string select = string.Format("select nombre from Establecimientos " +
                "where IDAdministrador = (Select id from Administradores where Cedula = '{0}')", cedula);

            SqlCommand comando = new SqlCommand(select, conexion);
            SqlDataReader registros = comando.ExecuteReader();


            while (registros.Read())
            {
                lst.Add(registros[0].ToString());
            }

            conexion.Close();

            return lst;

        }

        public DataTable VerAgendas(string nombre)
        {
            DataTable dtAgendas = new DataTable();

            conexion.Open();

            string select = string.Format("SELECT Dia,Hora FROM Agendas Where " +
                "IDProfesional = (SELECT ID FROM Profesionales WHERE Nombre = '{0}') And Estado = 1", nombre);

            SqlCommand comando = new SqlCommand(select, conexion);
            SqlDataReader registros = comando.ExecuteReader();
            dtAgendas.Load(registros);

            conexion.Close();

            return dtAgendas;

        }

        public void AgregarAgenda(string nombreProfe, DateTime fecha, string hora)
        {

            conexion.Open();

            string insert = string.Format("INSERT INTO [dbo].[Agendas] ([IDProfesional] ,[Dia] ,[Hora] ,[Estado]) " +
                "VALUES ((select ID from Profesionales where Nombre = '{0}'),'{1}','{2}',1)", nombreProfe, fecha.ToString("M-dd-yyyy"), hora);

            SqlCommand comando = new SqlCommand(insert, conexion);

            comando.ExecuteNonQuery();
            conexion.Close();
        }

        public void EliminarAgenda(string nombreProf, DateTime fecha, string hora)
        {
            conexion.Open();

            string insert = string.Format("DELETE Agendas " +
                "WHERE IDProfesional = (select id from Profesionales where Nombre = '{0}') " +
                "and Dia = '{1}' and Hora = '{2}'", nombreProf, fecha.ToString("M-dd-yyyy"), hora);

            SqlCommand comando = new SqlCommand(insert, conexion);

            comando.ExecuteNonQuery();
            conexion.Close();


        }

        public DataTable GraficaAdmin(string cedula)
        {
            DataTable dataTable = new DataTable();
            conexion.Open();

            string select = string.Format("SELECT Establecimientos.Nombre, COUNT(Citas.IDEstablecimiento) AS 'Numero de citas'" +
                "FROM Citas join Establecimientos on Establecimientos.ID = IDEstablecimiento " +
                "Where IDAdministrador = (select id from Administradores where Cedula = '{0}') " +
                "GROUP BY IDEstablecimiento, Establecimientos.Nombre", cedula);

            SqlCommand comando = new SqlCommand(select, conexion);
            SqlDataReader registros = comando.ExecuteReader();
            dataTable.Load(registros);

            conexion.Close();

            return dataTable;
        }

        public DataTable GraficaDueños(string cedula)
        {
            DataTable dataTable = new DataTable();
            conexion.Open();

            string select = string.Format("SELECT Establecimientos.Nombre, COUNT(Citas.IDEstablecimiento) AS 'Numero de citas' " +
                "FROM Citas join Establecimientos on Establecimientos.ID = IDEstablecimiento " +
                "Where IDDueño = (select id from Dueños where Cedula = '{0}') " +
                "GROUP BY IDEstablecimiento, Establecimientos.Nombre", cedula);

            SqlCommand comando = new SqlCommand(select, conexion);
            SqlDataReader registros = comando.ExecuteReader();
            dataTable.Load(registros);

            conexion.Close();

            return dataTable;
        }
    }
}
