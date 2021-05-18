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
        Dictionary<int, string> baseDatos2;

        public DatosPruebasUnitarias()
        {
            this.baseDatos = new Dictionary<string, string>();
            this.baseDatos2 = new Dictionary<int, string>();

            this.baseDatos.Add("1001540023", "123456");
            this.baseDatos2.Add(123456789, "11111");
            this.baseDatos2.Add(292617088, "cY7R2Pnv5");

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

        public bool iniciarSesionAdministradores(int cedula, string contrasena)
        {

            if (this.baseDatos2[cedula] == contrasena)
            {

                return true;
            }
            else
            {
                return false;
            }

        }

        public bool iniciarSesionDueños(int cedula, string contrasena)
        {

            if (this.baseDatos2[cedula] == contrasena)
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
