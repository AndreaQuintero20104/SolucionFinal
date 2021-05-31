using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentacionFinal.Models
{
    public class RequestRegistro
    {
        public string cedula { get; set; }
        public string contraseña { get; set; }
        public string nombre { get; set; }
        public string celular { get; set; }
        public string telefono { get; set; }
        public string fecha { get; set; }
        public string direccion { get; set; }
        public string email { get; set; }

    }
}