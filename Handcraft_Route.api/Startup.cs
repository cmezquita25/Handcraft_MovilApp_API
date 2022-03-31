using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Handcraft_Route.infraestructure.Data;
using Handcraft_Route.infrastructure;
using Handcraft_Route.domain.Entities;
using Handcraft_Route.domain.Interfaces;
using Handcraft_Route.infrastructure.Repositories;
using Handcraft_Route.application.Services;
using Microsoft.AspNetCore.Http;
using FluentValidation;
using Handcraft_Route.domain.dtos.Requests;
using Handcraft_Route.infrastructure.Validators;

/*Nombre de la escuela: Universidad Tecnologica Metropolitana
Asignatura: Aplicaciones Web Orientadas a Servicios
Nombre del Maestro: Chuc Uc Joel Ivan
Nombre del Proyecto: Handcraft Ruoute
Integrantes:
- Carlos M Mezquita Alvarado
- Fabian F Aguilar Rivero
- Pedro V Ruvalcaba Novelo
Cuatrimestre: 4
Grupo: B
Parcial: 3
*/

namespace Handcraft_Route.api
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Handcraft_Route.api", Version = "v1" });
            });

            services.AddDbContext<CFPHandcraftRouteContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CFPHandcraftRoute")));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            services.AddScoped<IArtesanoCOOPService, ServiceArtesanosCoop>();
            services.AddScoped<IArtesanosSERVICE, ServiceArtesanos>();
            services.AddScoped<IProductoArtSERVICE, ServiceProductosArt>();
            

            services.AddTransient<IArtesanosCOOPRespository, ArtesanosCoopSQLrepositorys>();
            services.AddTransient<IArtesanosREPOSITORY, ArtesanosSQLrepositorys>();
            services.AddTransient<IProductosArtREPOSITORY, ProductosArtSQLrepositorys>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IValidator<ArtesanoCOOPCREATERequest>, ArtesanoCOOPCreateRequestValidator>();
            services.AddScoped<IValidator<ArtesanoCreateREQUEST>, ArtesanosCreateREQUESTValidator>();
            services.AddScoped<IValidator<ProductoArtCreateREQUEST>, ProductosArtCreateREQUESTValidator>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Handcraft_Route.api v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
