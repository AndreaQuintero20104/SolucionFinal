using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using LogicaNegocio;
using AccesoDatos;
using PresentacionFinal.Models;


namespace PresentacionFinal.Controllers
{
    public class EstablecimientosController : ApiController
    {
        GestorEstablecimientos user = new GestorEstablecimientos(new Data());

        [Route("api/usuario/establecimientos")]
        [HttpPost]
        public ResponseEstablecimiento ListarEstablecimientos()
        {
            List<string> resultado = user.CargarEstablecimientos();

            ResponseEstablecimiento resp = new ResponseEstablecimiento();
            resp.establecimientos = resultado;

            return resp;
        }
    }
}
