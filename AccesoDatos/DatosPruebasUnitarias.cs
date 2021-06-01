using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio;

namespace AccesoDatos
{
    public class DatosPruebasUnitarias : FuenteDatosRepository
    {
        public List<string> baseDatos1;
        public Dictionary<string, string> baseDatos;
        public Dictionary<int, string> baseDatos2;
        public List<string> baseDatos3;
        public List<string> baseDatos4;
        public List<string> baseDatos5;
        public List<string> baseDatos6;
        public Dictionary<string, DateTime> baseDatos7;
        public DataTable baseDatos8;
        public DataTable baseDatos9;



        public DatosPruebasUnitarias()
        {
            this.baseDatos1 = new List<string>();
            this.baseDatos = new Dictionary<string, string>();
            this.baseDatos2 = new Dictionary<int, string>();
            this.baseDatos3 = new List<string>();
            this.baseDatos4 = new List<string>();
            this.baseDatos5 = new List<string>();
            this.baseDatos6 = new List<string>();
            this.baseDatos7 = new Dictionary<string, DateTime>();

            this.baseDatos1.Add("1001540024");
            this.baseDatos.Add("1001540023", "123456");
            this.baseDatos2.Add(123456789, "11111");
            this.baseDatos2.Add(292617088, "cY7R2Pnv5");

            this.baseDatos3.Add("Babblestorm");
            this.baseDatos4.Add("Carlie Byrd");
            this.baseDatos4.Add("7780630366");
            this.baseDatos5.Add("Software Engineer IV");
            this.baseDatos6.Add("2020-11-11");
            this.baseDatos6.Add("01:00:00");
            this.baseDatos7.Add("Carlie Byrd", Convert.ToDateTime("2020-11-11"));

            this.baseDatos8 = new DataTable();

            baseDatos8.Columns.Add("ID", typeof(int));
            baseDatos8.Columns.Add("Establecimiento", typeof(string));
            baseDatos8.Columns.Add("Profesional", typeof(string));
            baseDatos8.Columns.Add("TipoServicio", typeof(string));
            baseDatos8.Columns.Add("Dia", typeof(DateTime));
            baseDatos8.Columns.Add("Hora", typeof(string));

            DataColumn[] keyColumns = new DataColumn[1];
            keyColumns[0] = baseDatos8.Columns["ID"];
            baseDatos8.PrimaryKey = keyColumns;

            baseDatos8.Rows.Add(20020, "Wikibox", "Garvy Thorndycraft", "Cita General", Convert.ToDateTime("8-07-2020"), "07:00:00");

            this.baseDatos9 = new DataTable();

            baseDatos9.Columns.Add("Dia", typeof(DateTime));
            baseDatos9.Columns.Add("Hora", typeof(string));
            
            keyColumns[0] = baseDatos9.Columns["Dia"];
            baseDatos9.PrimaryKey = keyColumns;

            baseDatos9.Rows.Add(Convert.ToDateTime("2020-11-11"), "01:00:00");
        }

        public void RegistrarCliente(string cedula, string contraseña, string nombre, string celular, string telefono, DateTime fechanac, string direccion, string email)
        {

            baseDatos1.Add(cedula);
        }

        public bool iniciarSesion(string cedula, string contrasena)
        {


            if (this.baseDatos[cedula] == contrasena)
            {

                return true;
            }
            else
            {
                return false;
            }

        }

        public bool iniciarSesionAdministradores(int cedula, string contrasena)
        {

            if (this.baseDatos2[cedula] == contrasena)
            {

                return true;
            }
            else
            {
                return false;
            }

        }

        public bool iniciarSesionDueños(int cedula, string contrasena)
        {

            if (this.baseDatos2[cedula] == contrasena)
            {

                return true;
            }
            else
            {
                return false;
            }

        }

        public List<string> MostrarEstablecimientos()
        {
          
            return baseDatos3;
        }

        public List<string> MostrarProfesionales(string nombreEstab)
        {
            
            return baseDatos4;
        }

        public List<string> MostrarServicios(string nombreProf)
        {
            this.baseDatos5.Add("Sales Representative");

            return baseDatos5;
        }

        public List<string> MostrarFechas(string nombreProf)
        {
            return baseDatos6;
        }

        public List<string> MostrarHoras(string nombreProf, DateTime fecha)
        {
            return baseDatos6;
        }

        public void AgregarCita(string idCliente, string establecimiento, string profesional, string tipoServicio, DateTime fecha, string hora, string observaciones)
        {
            this.baseDatos3.Add(idCliente);
            this.baseDatos3.Add(establecimiento);
            this.baseDatos3.Add(profesional);
            this.baseDatos3.Add(tipoServicio);
            this.baseDatos3.Add(fecha.ToString());
            this.baseDatos3.Add(hora);
            this.baseDatos3.Add(observaciones);
        }

        public DataTable VerMisCitas(string idCliente)
        {
            return this.baseDatos8;
        }

        public void CancelarCita(int idCita, string profesional, DateTime fecha, string hora)
        {
            this.baseDatos3.Remove(profesional);
        }

        public List<string> EstablecimientosXAdministrador(string cedula)
        {
            return baseDatos4;
        }

        public DataTable VerAgendas(string nombreprof)
        {
            return this.baseDatos9;
        }

        public void AgregarAgenda(string profesional, DateTime fecha, string hora)
        {
            this.baseDatos3.Add(profesional);
            this.baseDatos3.Add(fecha.ToString());
            this.baseDatos3.Add(hora);
        }

        public DataTable GraficaAdmin(string cedula)
        {
            throw new NotImplementedException();
        }

        public DataTable GraficaDueños(string cedula)
        {
            throw new NotImplementedException();
        }

        public void EliminarAgenda(string nombreProf, DateTime fecha, string hora)
        {
            this.baseDatos.Remove(nombreProf);
        }
    }
}
