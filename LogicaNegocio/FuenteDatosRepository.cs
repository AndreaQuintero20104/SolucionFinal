using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public interface FuenteDatosRepository

    {
        void RegistrarCliente(string cedula, string contraseña, string nombre, string celular, string telefono, DateTime fechanac, string direccion, string email);

        bool iniciarSesion(string cedula, string contrasena);

        bool iniciarSesionAdministradores(int cedula, string contraseña);

        bool iniciarSesionDueños(int cedula, string contraseña);

        List<string> MostrarEstablecimientos();

        List<string> MostrarProfesionales(string nombreEstab);

        List<string> MostrarServicios(string nombreProf);

        List<string> MostrarFechas(string nombreProf);

        List<string> MostrarHoras(string nombreProf, DateTime fecha);

        void AgregarCita(string idCliente, string establecimiento, string profesional, string tipoServicio, DateTime fecha, string hora, string observaciones);

        DataTable VerMisCitas(string idCliente);

        void CancelarCita(int idCita, string profesional, DateTime fecha, string hora);

        List<string> EstablecimientosXAdministrador(string cedula);

        DataTable VerAgendas(string nombre);

        void AgregarAgenda(string nombreProfe, DateTime fecha, string hora);

        DataTable GraficaAdmin(string cedula);

        DataTable GraficaDueños(string cedula);

        void EliminarAgenda(string nombreProf, DateTime fecha, string hora);
    }
}
