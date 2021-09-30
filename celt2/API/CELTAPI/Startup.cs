/**
* @license
* Copyright Team Glare. All Rights Reserved.
*
* Use of this source code is governed by an MIT-style license that can be
* found in the LICENSE file at https://github.com/Team-Glare/CELT2/blob/main/LICENSE
*/

using CELTAPI.Model;
using CELTAPI.Services;
using CELTAPI.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace CELTAPI
{
    /// <summary>
    /// Defines the Startup class for the project.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Constructor for Startup with injected dependencies.
        /// </summary>
        /// <param name="configuration">IConfiguration input.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// Gets called by the runtime and uses this method to add services to the container.
        /// </summary>
        /// <param name="services">IServiceCollection input.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHttpClient();
            services.AddHttpContextAccessor();

            // Register the Swagger generator
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "CELT2 API",
                    Description = "CELT2 API",
                    Version = "v1"
                });
            });

            services.AddCors(o => o.AddPolicy("CELT2Policy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.Configure<AppSettings>(Configuration);

            DependencyInjections(services);
        }

        /// <summary>
        /// Gets called by the runtime and uses this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">IApplicationBuilder</param>
        /// <param name="env">IWebHostEnvironment</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // Use the Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CELT2 API");
                c.RoutePrefix = String.Empty;
            });

            app.UseRouting();

            app.UseCors("CELT2Policy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// Adds the dependency injections.
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        private void DependencyInjections(IServiceCollection services)
        {
            // Services
            services.AddScoped<ISentimentService, SentimentService>();

            // Helpers
            services.AddSingleton<IStreamReader, FileStreamReader>();
            services.AddScoped<IServerClient, ServerClient>();
        }
    }
}
