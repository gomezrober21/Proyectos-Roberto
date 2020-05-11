using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProyectoApiClinica2.Models;
using ProyectoApiClinica2.Repositories;

namespace ProyectoApiClinica2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        RepositoryClinica repo;
        public UsuariosController(RepositoryClinica repo)
        {
            this.repo = repo;
        }
       // [Authorize]
        [HttpGet]
        public ActionResult<List<Usuario>> Get()
        {
            return this.repo.GetUsuarios();
        }

        //VER PERFIL DEL CLIENTE CONECTADO
        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public ActionResult<Usuario> perfilUsuario()
        {
            List<Claim> claims = HttpContext.User.Claims.ToList();
            String json = claims.SingleOrDefault(x => x.Type == "UserData").Value;
            Usuario usr = JsonConvert.DeserializeObject<Usuario>(json);
            return usr;
        }

        [HttpGet("{nombreusu}")]
        public ActionResult<Usuario> BuscarPorUsuario(String nombreusu)
        {
            return this.repo.BuscarUsuario(nombreusu);
        }
        [HttpPost]
        public void Registrarse(Usuario usu)
        {
            this.repo.Registrarse(usu.NombreUsuario, usu.Contrasena, usu.Nombre, usu.Apellido, usu.Edad, usu.Telefono, usu.Email);
        }

        [HttpDelete("{nombreusu}")]
        public void EliminarUsuario(String nombreusu)
        {
            this.repo.EliminarUsuario(nombreusu);
        }

        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public Usuario PerfilEmpleado()
        {
            List<Claim> claims = HttpContext.User.Claims.ToList();
            String jsonempleado =
                claims.SingleOrDefault(x => x.Type == "UserData").Value;
            Usuario empleado = JsonConvert.DeserializeObject<Usuario>(jsonempleado);
            return empleado;
        }

        [HttpPut]
        [Route("Comentarios")]
        public void Comentarios(String comentario, String id)
        {
            this.repo.Comentarios(comentario, id);

        }

        [HttpPut]
        public void ModificarUsuario(Usuario usu)
        {
            this.repo.ModificarUsuario(usu.NombreUsuario, usu.Contrasena, usu.Nombre, usu.Apellido, usu.Edad, usu.Telefono, usu.Email);

        }
    }
}