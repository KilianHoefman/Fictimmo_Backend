using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HuizenAPI.Data;
using HuizenAPI.Data.Repositories;
using HuizenAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HuizenAPI
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
            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddOpenApiDocument(c =>
           {
               c.DocumentName = "apidocs";
               c.Title = "Huizen API";
               c.Version = "v1";
               c.Description = "De Huizen API documentatie beschrijving";
           });
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<DataInitializer>();
            services.AddScoped<IHuisRepository, HuisRepository>();
            services.AddScoped<IDetailRepository, DetailRepository>();
            services.AddScoped<IImmoBureauRepository, ImmoBureauRepository>();
            services.AddScoped<IKlantRepository, KlantRepository>();
            services.AddScoped<ILocatieRepository, LocatieRepository>();            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataInitializer dataInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            dataInitializer.InitializeData();
        }
    }
}
