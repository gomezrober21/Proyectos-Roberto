using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoApiClinica2.Token
{
    public class HelperToken
    {
        public IConfiguration configuration;
        private String secretkey;
        private String issuer;
        private String audience;

        public HelperToken(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.audience = configuration["apiAuth:Audience"];
            this.issuer = configuration["apiAuth:Issuer"];
            this.secretkey = configuration["apiAuth:SecretKey"];
        }

        private SymmetricSecurityKey GetKeyToken()
        {
            //CONVERTIMOS A BYTES LA CLAVE
            byte[] data =
                Encoding.UTF8.GetBytes(this.secretkey);
            //DEVOLVEMOS LA CLAVE DE SEGURIDAD CON EL SECRET KEY
            return new SymmetricSecurityKey(data);
        }

        //METODO PARA CONFIGURAR LA AUTENTIFICACION
        public Action<AuthenticationOptions> GetAuthOptions()
        {
            Action<AuthenticationOptions> authoptions =
                new Action<AuthenticationOptions>(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                });
            return authoptions;
        }

        //METODO PARA CONFIGURAR LAS OPCIONES DE SEGURIDAD DEL TOKEN
        public Action<JwtBearerOptions> GetJwtOptions()
        {
            Action<JwtBearerOptions> jwtoptions =
                new Action<JwtBearerOptions>(jwtBearerOptions =>
                {
                    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateActor = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = this.issuer,
                        ValidAudience = this.audience,
                        IssuerSigningKey = this.GetKeyToken()
                    };

                    //Necesario para la autentificacion de signalR
                    jwtBearerOptions.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            var accessToken = context.Request.Query["access_token"];
                            // If the request is for our hub...
                            var path = context.HttpContext.Request.Path;
                            if (!string.IsNullOrEmpty(accessToken) &&
                                (path.StartsWithSegments("/gamehub")))
                            {
                                // Read the token out of the query string
                                context.Token = accessToken;
                            }
                            return Task.CompletedTask;
                        }
                    };
                });
            return jwtoptions;
        }
    }
}

