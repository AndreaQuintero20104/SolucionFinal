using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Usuario
    {
        public string cedula { get; set; }
        public string contraseña { get; set; }
        public string nombre { get; set; }
        
        public string celular { get; set; }
        public string telefono { get; set; }

        public DateTime fechanac { get; set; }
        public string direccion { get; set; }
        public string email { get; set; }
       
    }
}
