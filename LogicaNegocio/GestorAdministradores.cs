using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class GestorAdministradores
    {
        private FuenteDatosRepository fuenteDatos;

        public GestorAdministradores(FuenteDatosRepository fuente)
        {
            this.fuenteDatos = fuente;
        }

        public bool iniciarSesionAdmin(int cedula, string contrasena)
        {
            return this.fuenteDatos.iniciarSesionAdministradores(cedula, contrasena);
        }
    }
}
