using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ProyectoApiClinica2.Data;
using ProyectoApiClinica2.Repositories;
using ProyectoApiClinica2.Token;

namespace ProyectoApiClinica2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            String cadena = Configuration.GetConnectionString("clinicaazure");
            services.AddTransient<RepositoryClinica>();
            services.AddDbContext<ContextoClinica>(options => options.UseSqlServer(cadena));
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    name: "v1", new OpenApiInfo
                    {
                        Title = "Api Crud Clinica",
                        Version = "v1",
                        Description = "Api de usuarios y consultas de la cl�nica"
                    });

            });
            HelperToken helper = new HelperToken(this.Configuration);
            services.AddAuthentication(helper.GetAuthOptions()).AddJwtBearer(helper.GetJwtOptions());
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(
                    url: "/swagger/v1/swagger.json",
                    name: "Api v1"
                    );
                c.RoutePrefix = "";
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
