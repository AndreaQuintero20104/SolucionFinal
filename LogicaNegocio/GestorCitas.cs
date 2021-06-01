using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class GestorCitas
    {
        private FuenteDatosRepository fuenteDatos;

        public GestorCitas(FuenteDatosRepository fuente)
        {
            this.fuenteDatos = fuente;
        }

        public string AgregarCita(string idCliente, string establecimiento, string profesional, string tipoServicio, DateTime fecha, string hora, string observaciones)
        {
            this.fuenteDatos.AgregarCita(idCliente, establecimiento, profesional, tipoServicio, fecha, hora, observaciones);

            return "se insertó correctamente la cita";
        }

        public DataTable CargarCitas(string idCliente)
        {
            return this.fuenteDatos.VerMisCitas(idCliente);
        }

        public string CancelarCita(int idCita, string profesional, DateTime fecha, string hora)
        {
            this.fuenteDatos.CancelarCita(idCita, profesional, fecha, hora);

            return "se Canelo la cita";
        }
    }
}
