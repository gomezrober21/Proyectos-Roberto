using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using ProyectoApiClinica2.Models;
using ProyectoApiClinica2.Repositories;

namespace ProyectoApiClinica2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        RepositoryClinica repo;
        IConfiguration configuration;

        public AuthController(RepositoryClinica repo, IConfiguration configuration)
        {
            this.repo = repo;
            this.configuration = configuration;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Login(LogInModel model)
        {
            Usuario clientes = this.repo.ExisteUsuario(model.NombreUsuario, model.Contrasena);
            if (clientes != null)
            {
                //ESTA ES LA INFORMACION QUE VAMOS A INCLUIR EN 
                //NUESTRO TOKEN PARA PODER RECUPERARLA POSTERIORMENTE
                Claim[] claims = new[]
                {
                    new Claim("UserData", JsonConvert.SerializeObject(clientes))
                };

                //GENERAMOS EL TOKEN CON LA INFORMACION
                JwtSecurityToken token = new JwtSecurityToken
                (
                    issuer: configuration["ApiAuth:Issuer"],
                    audience: configuration["ApiAuth:Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(60),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["ApiAuth:SecretKey"])),
                    SecurityAlgorithms.HmacSha256)
                );

                // Devolvemos el token en la respuesta
                return Ok(
                    new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        rol = clientes.Rol
                    }
                );
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}