using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using LogicaNegocio;
using AccesoDatos;
using PresentacionApi.Models;

namespace PresentacionApi.Controllers
{
    public class UsuarioController : ApiController
    {
        GestorUsuarios user = new GestorUsuarios(new Data());
        [Route("api /usuario/inicarSesion")]
        [HttpPost]
        public Response IniciarSesion([FromBody] Request user1)
        {
             

            Usuario usuario = new Usuario();
            usuario.cedula = user1.cedula;
            usuario.contraseña =user1.contraseña;

            bool resultado = user.iniciarSesion(usuario);

            Response resp = new Response();
            resp.result = resultado;

            return resp;
        }
       
/*
        [Route("api/usuario/inicarSesion")]
        [HttpPost]
        public bool iniciarSesion(string cedula, string contrasena)
        {
            Usuario usuario = new Usuario();
            usuario.cedula = cedula;
            usuario.contraseña = contrasena;
            return user.iniciarSesion(usuario);
        }*/
    }
}