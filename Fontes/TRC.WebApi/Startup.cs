using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;
using TRC.Data;
using TRC.Data.Implementation;
using TRC.Data.Interfaces;
using TRC.Manager.Implementation;
using TRC.Manager.Interfaces;

namespace TRC.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddDbContext<TrcContext>(options => options.EnableSensitiveDataLogging().UseSqlServer(Configuration.GetConnectionString("TrcConnection")));

            services.AddOptions();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "TRC API", Version = "V1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            //services.AddLogging(logginBuilder =>
            //{
            //    logginBuilder.AddFile(Configuration.GetSection("Logging"));
            //});

            ConfiguraInjecaoDependencia(services);
        }

        public void ConfiguraInjecaoDependencia(IServiceCollection services)
        {
            services.AddTransient<IEstadoRepository, EstadoRepository>();
            services.AddTransient<IEstadoManager, EstadoManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "post API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseMvc();
        }
    }
}
