using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class GestorServicios
    {
        private FuenteDatosRepository fuenteDatos;

        public GestorServicios(FuenteDatosRepository fuente)
        {
            this.fuenteDatos = fuente;
        }

        public List<string> CargarServicios(string nombreProf)
        {
            return this.fuenteDatos.MostrarServicios(nombreProf);
        }
    }
}
