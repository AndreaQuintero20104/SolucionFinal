using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LogicaNegocio
{
    public class GestorUsuarios
    {
        private FuenteDatosRepository fuenteDatos;

        public GestorUsuarios(FuenteDatosRepository fuente)
        {
            this.fuenteDatos = fuente;
        }

        
        public bool iniciarSesion(string cedula, string contrasena)
        {
             return this.fuenteDatos.iniciarSesion(cedula, contrasena);
        }
    }
}
