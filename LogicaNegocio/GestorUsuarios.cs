using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;

namespace LogicaNegocio
{
    public class GestorUsuarios
    {
        DataCliente gestorClientes = new DataCliente();

        public bool iniciarSesion(string cedula, string contrasena)
        {
            return gestorClientes.iniciaSesion(cedula, contrasena);
        }
    }
}
