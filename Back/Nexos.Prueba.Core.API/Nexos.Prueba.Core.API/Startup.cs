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
using Nexos.Prueba.Domain.Core.Services;
using Nexos.Prueba.Domain.Core.Services.InterfaceRepository;
using Nexos.Prueba.Domain.Core.Services.InterfaceService;
using Nexos.Prueba.Infrastructure.Persistence;
using Nexos.Prueba.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Nexos.Prueba.Core.API
{
    public class Startup
    {
        readonly string CorsPolicy = "CorsPolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            //Add cors
            services.AddCors(o => o.AddPolicy(CorsPolicy, builder =>
            {
                builder.WithOrigins("*")
                       .WithHeaders("*")
                       .WithMethods("*");
            }));

            // Add AutoMapper
            services.AddAutoMapper(typeof(Startup));

            // Add Context
            services.AddDbContext<NexosDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ConnectionDB"),
                          sqlServerOptionsAction: sqlOptions =>
                          {
                              sqlOptions.EnableRetryOnFailure();
                          });
            });
            services.AddScoped(typeof(DbContext), typeof(NexosDBContext));

            services.AddScoped<IAutorRepository, AutorRepository>();
            services.AddScoped<IAutorService, AutorService>();
            services.AddScoped<IEditorialRepository, EditorialRepository>();
            services.AddScoped<IEditorialService, EditorialService>();
            services.AddScoped<ILibroRepository, LibroRepository>();
            services.AddScoped<ILibroService, LibroService>();

            // Register the Swagger Generator
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Nexos Prueba Core API v1",
                    Version = "1.0"
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    In = ParameterLocation.Header,
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Name = "Bearer",
                            Type = SecuritySchemeType.ApiKey,
                            In = ParameterLocation.Header,
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                         },
                         new string[] {}
                     }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Nexos.Prueba.Core.API v1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(CorsPolicy);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
