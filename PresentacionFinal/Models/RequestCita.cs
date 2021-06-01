using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentacionFinal.Models
{
    public class RequestCita
    {
        public string cedula { get; set; }
        public string establecimiento { get; set; }
        public string profesional { get; set; }
        public string tiposervicio { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public string observaciones { get; set; }
    }
}