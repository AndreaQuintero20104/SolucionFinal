using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LogicaNegocio;
using AccesoDatos;
using PresentacionFinal.Models;

namespace PresentacionFinal.Controllers
{
    public class ProfesionalesController : ApiController
    {
        GestorProfesionales user = new GestorProfesionales(new Data());
        GestorAgendas user2 = new GestorAgendas(new Data());

        [Route("api/usuario/profesionales")]
        [HttpPost]
        public ResponseProfesional ListarEstablecimientos([FromBody] RequestProfesional user1)
        {
            
            List<string> resultado = user.CargarProfesionales(user1.nombreEst);

            ResponseProfesional resp = new ResponseProfesional();
            resp.profesionales = resultado;

            return resp;
        }

        [Route("api/usuario/fecha")]
        [HttpPost]
        public ResponseFecha ListarFechas([FromBody] RequestServiciosFechaHora user1)
        {

            List<string> resultado = user2.CargarFechas(user1.nombreprof);

            ResponseFecha resp = new ResponseFecha();
            resp.fechas = resultado;

            return resp;
        }

        [Route("api/usuario/hora")]
        [HttpPost]
        public ResponseHoras ListarHoras([FromBody] RequestServiciosFechaHora user1)
        {
            //"fecha": "5/12/2020"
            List<string> resultado = user2.CargarHoras(user1.nombreprof,user1.fecha);

            ResponseHoras resp = new ResponseHoras();
            resp.horas = resultado;

            return resp;
        }
    }
}