using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class GestorDueños
    {
        private FuenteDatosRepository fuenteDatos;

        public GestorDueños(FuenteDatosRepository fuente)
        {
            this.fuenteDatos = fuente;
        }

        public bool iniciarSesionDueños(int cedula, string contrasena)
        {
            return this.fuenteDatos.iniciarSesionDueños(cedula, contrasena);
        }
    }
}
