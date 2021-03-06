using DotNetify;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PersonSearch.App.ViewModels;
using PersonSearch.App.ViewModels.WiringTest;
using PersonSearch.Data;
using PersonSearch.Domain;
using PersonSearch.Service.Contracts;
using PersonSearch.Service.Services;

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
            services.AddSignalR().AddNewtonsoftJsonProtocol();
            services.AddDotNetify();

            services.AddSingleton(_config);

            services.AddTransient<IApplicationDbContextFactory, ApplicationDbContextFactory>();
            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(_config.GetConnectionString("DefaultConnection")), 
                ServiceLifetime.Transient);

            services.AddScoped<IRepository<Person>, Repository<Person>>();
            services.AddScoped<IRepository<Group>, Repository<Group>>();

            services.AddScoped<RandomData>();
            services.AddScoped<ServerDateTime>();
            services.AddScoped<ButtonTest>();
            services.AddScoped<ButtonTestCounter>();
            services.AddScoped<ButtonTestHandler>();

            services.AddScoped<PersonsScope>();
            services.AddScoped<PersonList>();
            services.AddScoped<SearchBar>();

            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IPersonNameBuilder, PersonNameBuilder>();
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
