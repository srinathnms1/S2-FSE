namespace User.Api
{
    using System;
    using System.Text;
    using AutoMapper;
    using MediatR;
    using Microservice.Core;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using Swashbuckle.AspNetCore.Swagger;
    using Vehicle.Domain;
    using Vehicle.Domain.ViewModel;
    using Vehicle.Infrastracture;
    using Vehicle.Infrastructure;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var audienceConfig = Configuration.GetSection("Audience");

            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(audienceConfig["Secret"]));
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateIssuer = true,
                ValidIssuer = audienceConfig["Iss"],
                ValidateAudience = true,
                ValidAudience = audienceConfig["Aud"],
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                RequireExpirationTime = true,
            };

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = "TestKey";
            })
            .AddJwtBearer("TestKey", x =>
            {
                x.RequireHttpsMetadata = false;
                x.TokenValidationParameters = tokenValidationParameters;
            });

            services.AddMediatR();
            services.AddMediatR(new[] {
                typeof(Program).GetType().Assembly, typeof(VehicleViewModel).GetType().Assembly }).BuildServiceProvider();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "MicroServices - Vehicle Api", Version = "v1" });
            });

            services.AddAutoMapper(typeof(VehicleViewModel));
            services.AddDbContext<VehicleContext>(opts => opts.UseSqlServer(Configuration["ConnectionStrings:VehicleConnectionString"], builder => builder.MigrationsAssembly(typeof(Startup).Assembly.FullName)));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped(typeof(IVehicleRepository), typeof(VehicleRepository));
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vehicle Service");
            });

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
