using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CSBC.Core.Repositories;
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
using csbc_server.Data;
using csbc_server.Interfaces;
using csbc_server.Repositories;

namespace csbc_server
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Environment = env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDbContext<CsbcContext>(options =>
                    options
                        .UseSqlServer(Configuration
                            .GetConnectionString("CsbcContext")));
            if (Environment.IsDevelopment())
            {
                services
                    .AddDbContext<CsbcContext>(options =>
                        options
                            .UseSqlServer(Configuration
                                .GetConnectionString("CsbcContext")));
            }
            else
            {
                services
                    .AddDbContext<CsbcContext>(options =>
                        options
                            .UseSqlServer(Configuration
                                .GetConnectionString("CsbcContext")));
            }
            services.AddScoped<ISeasonRepository, SeasonRepository>();
            services.AddScoped<IWebContentRepository, WebContentRepository>();

            services.AddControllers();
            services
                .AddSwaggerGen(c =>
                {
                    c
                        .SwaggerDoc("v1",
                        new OpenApiInfo {
                            Version = "v1",
                            Title = "CSBC Server API",
                            Description = "CSBC web site back end",
                            TermsOfService =
                                new Uri("https://example.com/terms"),
                            Contact =
                                new OpenApiContact {
                                    Name = "Richard Salit",
                                    Email = string.Empty,
                                    Url = new Uri("https://twitter.com/rsalit")
                                },
                            License =
                                new OpenApiLicense {
                                    Name = "Use under LICX",
                                    Url = new Uri("https://example.com/license")
                                }
                        });

                    // services.AddSwaggerDocument();
                    // Set the comments path for the Swagger JSON and UI.
                    var xmlFile =
                        $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath =
                        Path.Combine(AppContext.BaseDirectory, xmlFile);
                    c.IncludeXmlComments (xmlPath);
                });
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app
                .UseSwaggerUI(c =>
                {
                    c
                        .SwaggerEndpoint("/swagger/v1/swagger.json",
                        "CSBC Server API V1");
                    c.RoutePrefix = string.Empty;
                });

            app.UseHttpsRedirection();
            app.UseRouting();
            app
                .UseCors(x =>
                    x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthorization();

            app
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}
