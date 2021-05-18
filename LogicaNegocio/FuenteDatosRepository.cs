using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public interface FuenteDatosRepository
    {
        bool iniciarSesion(string cedula, string contrasena);

        bool iniciarSesionAdministradores(int cedula, string contraseña);

        bool iniciarSesionDueños(int cedula, string contraseña);
    }
}
