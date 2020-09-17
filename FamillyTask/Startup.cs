using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FamillyTask.DAL.Interface;
using FamillyTask.DAL.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;

namespace FamillyTask
{
    public class Startup
    {
        string Cnstr;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Cnstr = configuration.GetConnectionString("DbCnstr");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /*Injection de dépendance*/
            services.Add(new ServiceDescriptor(typeof(IMembreService), new MembreService(Cnstr)));
            services.Add(new ServiceDescriptor(typeof(ITacheService), new TacheService(Cnstr)));

            /*Swagger*/
            services.AddSwaggerGenNewtonsoftSupport();
            services.AddSwaggerGen(swagger =>
            {
                swagger.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                swagger.DescribeAllParametersInCamelCase(); 
                swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "Family Task API" });
                swagger.IncludeXmlComments(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "FamillyTask.xml"));
                
            });


            services.AddControllers().AddNewtonsoftJson(); 
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Family Task API");
                
            });


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
