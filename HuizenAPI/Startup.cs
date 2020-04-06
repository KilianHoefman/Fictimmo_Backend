using HuizenAPI.Data;
using HuizenAPI.Data.Repositories;
using HuizenAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using NSwag.Generation.Processors.Security;
using NSwag;
using System.Text;

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
               c.DocumentProcessors.Add(new SecurityDefinitionAppender("JWT Token", new OpenApiSecurityScheme
               {
                   Type = OpenApiSecuritySchemeType.ApiKey,
                   Name = "Authorization",
                   In = OpenApiSecurityApiKeyLocation.Header,
                   Description = "Copy 'Bearer' + valid JWT token into field"
               }));
               c.OperationProcessors.Add(new OperationSecurityScopeProcessor("JWT Token"));           
            });
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddCors(options => options.AddPolicy("AllowAllOrigins", builder =>
                builder.AllowAnyOrigin()));
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme =
                JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(Configuration["Tokens:Key"])),
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = true //Ensure token hasn't expired
                };
            });
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

            app.UseCors("AllowAllOrigins");

            app.UseOpenApi();
            app.UseSwaggerUi3();
            
            app.UseAuthentication();
           
            app.UseRouting();           
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            dataInitializer.InitializeData().Wait();
        }
    }
}
