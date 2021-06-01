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

        
        public bool iniciarSesion(Usuario usuario)
        {
             return this.fuenteDatos.iniciarSesion(usuario.cedula, usuario.contraseña);
        }

        public string RegistrarCliente(Usuario usuario)
        {
             this.fuenteDatos.RegistrarCliente(usuario.cedula, usuario.contraseña, usuario.nombre, usuario.celular, usuario.telefono, usuario.fechanac, usuario.direccion, usuario.email);

            return "se agregó correctamente";
        }
    }
}
