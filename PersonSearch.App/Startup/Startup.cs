using DotNetify;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PersonSearch.Data;

namespace PersonSearch.App.Startup
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMemoryCache();
            services.AddSignalR();
            services.AddDotNetify();

            services.AddSingleton<IConfiguration>(_config);

            services.AddDbContext<ApplicationContext>(options => 
                options.UseSqlServer(_config.GetConnectionString("DefaultConnection")));
        }

        [UsedImplicitly]
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder => builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins("http://localhost:8080")
                .AllowCredentials());

            app.UseWebSockets();
            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapDotNetifyHub());
            app.UseDotNetify();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async context =>
            {
                await context.Response.WriteAsync(@"Please navigate to http://localhost:8080");
            });
        }
    }
}
