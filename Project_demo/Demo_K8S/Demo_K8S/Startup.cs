using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Demo_K8S
{
     /// <summary>
     /// Startup
     /// </summary>
     public class Startup
     {
          /// <summary>
          /// Constuctor
          /// </summary>
          public Startup(IConfiguration configuration)
          {
               //Configuration = configuration;
               var builder = new ConfigurationBuilder()
                   .AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true)
                   .AddEnvironmentVariables();
               Configuration = builder.Build();
          }

          /// <summary>
          /// Configuration
          /// </summary>
          public IConfiguration Configuration { get; }

          /// <summary>
          /// ConfigureServices
          /// </summary>
          public void ConfigureServices(IServiceCollection services)
          {
                services.AddControllers();
                services.AddHttpContextAccessor();

            #region add swagger
                 services.AddSwaggerGen(cfg =>
                   {
                        cfg.SwaggerDoc("1.0.0", new OpenApiInfo
                        {
                             Version = "1.0.0",
                             Title = "K8S API Design",
                             Description = "Business Service API Design (ASP.NET Core 6.0)"
                        });
                   });
               #endregion
          }

          /// <summary>
          /// Configure
          /// </summary>
          public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
          {
               if (env.IsDevelopment())
               {
                    app.UseDeveloperExceptionPage();
               }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

               app.UseSwaggerUI(c =>
               {
                    c.SwaggerEndpoint("/swagger/1.0.0/swagger.json", "K8S API Design");
               });

          }
     }
}
