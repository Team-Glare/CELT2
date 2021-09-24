using CELTAPI.Services;
using CELTAPI.Utilities;

namespace CELTAPI
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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CELT2 API");
                c.RoutePrefix = String.Empty;
            });

            app.UseCors("CELT2Policy");

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

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
