using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class GestorEstablecimientos
    {
        private FuenteDatosRepository fuenteDatos;

        public GestorEstablecimientos(FuenteDatosRepository fuente)
        {
            this.fuenteDatos = fuente;
        }

        public List<string> CargarEstablecimientos()
        {
            return this.fuenteDatos.MostrarEstablecimientos();
        }

        public List<string> CargarEstablecimientosXadmin(string cedula)
        {
            return this.fuenteDatos.EstablecimientosXAdministrador(cedula);
        }

        public DataTable graficaAdmin(string cedula)
        {
            
            return this.fuenteDatos.GraficaAdmin(cedula);
        }

        public DataTable graficaDueño(string cedula)
        {

            return this.fuenteDatos.GraficaDueños(cedula);
        }
    }
}
