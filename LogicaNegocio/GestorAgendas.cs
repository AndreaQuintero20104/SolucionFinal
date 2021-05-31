using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class GestorAgendas
    {
        private FuenteDatosRepository fuenteDatos;

        public GestorAgendas(FuenteDatosRepository fuente)
        {
            this.fuenteDatos = fuente;
        }

        public List<string> CargarFechas(string NombreProfe)
        {
            
            return this.fuenteDatos.MostrarFechas(NombreProfe);
        }

        public List<string> CargarHoras(string NombreProfe, DateTime fecha)
        {

            return this.fuenteDatos.MostrarHoras(NombreProfe, fecha);
        }

        public DataTable CargarAgenda(string NombreProfe)
        {

            return this.fuenteDatos.VerAgendas(NombreProfe);
        }

        public string AgregarAgenda(string profesional,  DateTime fecha, string hora)
        {
            this.fuenteDatos.AgregarAgenda(profesional, fecha, hora);

            return "se insertó correctamente la agenda";
        }

        public string CancelarAgenda(string profesional, DateTime fecha, string hora)
        {
            this.fuenteDatos.EliminarAgenda(profesional, fecha, hora);

            return "se elimino correctamente la agenda";
        }
    }
}
