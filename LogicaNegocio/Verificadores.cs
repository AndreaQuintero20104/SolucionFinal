using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Verificadores
    {
        public bool IsEmpty(string cedula,string contraseña)
        {
            if (cedula.Equals("") || contraseña.Equals(""))

            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public string limpiar(string campo)
        {

            return campo = "";
        }
    }
}
