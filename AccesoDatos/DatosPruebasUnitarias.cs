using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio;

namespace AccesoDatos
{
    public class DatosPruebasUnitarias : FuenteDatosRepository
    {
        Dictionary<string, string> baseDatos;

        public DatosPruebasUnitarias()
        {
            this.baseDatos = new Dictionary<string, string>();

            this.baseDatos.Add("1001540023", "123456");
           

        }

        public bool iniciarSesion(string cedula, string contrasena)
        {

            
            if (this.baseDatos[cedula] == contrasena)
            {
               
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
