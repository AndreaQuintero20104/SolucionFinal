using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using LogicaNegocio;
using AccesoDatos;
using PresentacionFinal.Models;

namespace PresentacionApi.Controllers
{
    public class UsuarioController : ApiController
    {
        GestorUsuarios user = new GestorUsuarios(new Data());

        [Route("api/usuario/inicarSesion")]
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

        [Route("api/usuario/registrarCliente")]
        [HttpPost]
        public ResponseRegistro registrarCliente([FromBody] RequestRegistro user1)
        {

            Usuario usuario = new Usuario();
            usuario.cedula = user1.cedula;
            usuario.contraseña = user1.contraseña;
            usuario.nombre = user1.nombre;
            usuario.celular = user1.celular;
            usuario.telefono = user1.telefono;
            usuario.fechanac = Convert.ToDateTime(user1.fecha);
            usuario.direccion = user1.direccion;
            usuario.email = user1.email;


            string resultado = user.RegistrarCliente(usuario);

            ResponseRegistro resp = new ResponseRegistro();
            resp.result = resultado;

            return resp;
        }
    }
}