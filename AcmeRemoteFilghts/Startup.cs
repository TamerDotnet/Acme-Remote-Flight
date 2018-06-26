using AcmeRemoteFilghts.CoreLayer.Data;
using AcmeRemoteFilghts.CoreLayer.Infrastructure;
using AcmeRemoteFilghts.CoreLayer.Parameters;
using AcmeRemoteFilghts.CoreLayer.SourceValidators;
using AcmeRemoteFilghts.DataLayer;
using AcmeRemoteFilghts.DataLayer.Entities;
using AcmeRemoteFilghts.DataLayer.Repositories;
using AcmeRemoteFilghts.PresentaionLayer.Extensions;
using AcmeRemoteFilghts.ServiceLayer.Flights;
using AutoMapper;
using ExamDesigner.Data;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace AcmeRemoteFilghts
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
             services.AddMvc()
                .AddFluentValidation();

            var connectionString = Configuration["connectionStrings:AcmeDBConnectionString"];
            services.AddDbContext<AcmeDbContext>(o => o.UseSqlServer(connectionString));

            services.AddTransient<IRepository<City>, EfRepository<City>>();
            services.AddTransient<IRepository<Booking>, EfRepository<Booking>>();
            services.AddTransient<IRepository<Flight>, EfRepository<Flight>>();

            // Register the repositories 
            services.AddScoped<IJourneyRepository, JourneyRepository>();
 
            // Register the services 
            services.AddScoped<IFlightService, FlightService>();
            services.AddTransient<IValidator<FlightResourceParameters>, FlightResourceValidators>();

            var typeFinder = new WebAppTypeFinder();
            AddAutoMapper(services, typeFinder);

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
            //2- Add CORS =========================================
             app.UseCors("CORS");
        }

        // Add auto Mapper
        protected virtual void AddAutoMapper(IServiceCollection services, ITypeFinder typeFinder)
        {
            //find mapper configurations provided by other assemblies
            var mapperConfigurations = typeFinder.FindClassesOfType<IMapperProfile>();

            //create and sort instances of mapper configurations
            var instances = mapperConfigurations
                //.Where(mapperConfiguration => PluginManager.FindPlugin(mapperConfiguration)?.Installed ?? true) //ignore not installed plugins
                .Select(mapperConfiguration => (IMapperProfile)Activator.CreateInstance(mapperConfiguration))
                .OrderBy(mapperConfiguration => mapperConfiguration.Order);

            //create AutoMapper configuration
            var config = new MapperConfiguration(cfg => {
                foreach (var instance in instances)
                {
                    cfg.AddProfile(instance.GetType());
                 }
            });

            //register AutoMapper
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            //register
            MappingExtensions.Init(config);

            //1- Add CORS =========================================
            services.AddCors(options =>
            {
                options.AddPolicy("CORS", corsPolicyBuilder => 
                    corsPolicyBuilder.AllowAnyOrigin()
                    // Apply CORS policy for any type of origin  
                    .AllowAnyMethod()
                    // Apply CORS policy for any type of http methods  
                    .AllowAnyHeader()
                    // Apply CORS policy for any headers  
                    .AllowCredentials());
                // Apply CORS policy for all users  
            });
        }
    }
}
