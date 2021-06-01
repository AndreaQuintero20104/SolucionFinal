using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicaNegocio;
using AccesoDatos;
using PresentacionFinal.Models;
using System.Web.Http;

namespace PresentacionFinal.Controllers
{
    public class ServiciosController : ApiController
    {
        GestorServicios user = new GestorServicios(new Data());

        [Route("api/usuario/servicios")]
        [HttpPost]
        public ResponseServicios ListarServicios([FromBody] RequestServiciosFechaHora user1)
        {

            List<string> resultado = user.CargarServicios(user1.nombreprof);

            ResponseServicios resp = new ResponseServicios();
            resp.servicios = resultado;

            return resp;
        }

    }
}