using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using LogicaNegocio;
using AccesoDatos;
using PresentacionFinal.Models;

namespace PresentacionFinal.Controllers
{
    public class AgendasController : ApiController
    {
        [Route("api/usuario/AgendarCita")]
        [HttpPost]
        public ResponseCita registrarCliente([FromBody] RequestCita user1)
        {
            GestorCitas citas = new GestorCitas(new Data());
            
            string cedula = user1.cedula;
            string establecimietno = user1.establecimiento;
            string profesional = user1.profesional;
            string tiposervicio = user1.tiposervicio;
            string fecha = user1.fecha;
            string hora = user1.hora;
            string observaciones = user1.observaciones;


            string resultado = citas.AgregarCita(cedula,establecimietno,profesional,tiposervicio,Convert.ToDateTime(fecha),hora,observaciones);

            ResponseCita resp = new ResponseCita();
            resp.result = resultado;

            return resp;
        }
    }
}