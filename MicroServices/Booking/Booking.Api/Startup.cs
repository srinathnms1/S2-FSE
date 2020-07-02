namespace Booking.Api
{
    using Booking.Domain.ViewModel;
    using Microservice.Core;
    using MediatR;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Text;
    using Swashbuckle.AspNetCore.Swagger;
    using AutoMapper;
    using Booking.Infrastructure;
    using Microsoft.EntityFrameworkCore;
    using Booking.Domain;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Hosting;

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
                typeof(Program).GetType().Assembly, typeof(BookingViewModel).GetType().Assembly }).BuildServiceProvider();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "MicroServices - Booking Api", Version = "v1" });
            });

            services.AddAutoMapper(typeof(BookingViewModel));
            services.AddDbContext<BookingContext>(opts => opts.UseSqlServer(Configuration["ConnectionStrings:BookingConnectionString"], builder => builder.MigrationsAssembly(typeof(Startup).Assembly.FullName)));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IBookingRepository), typeof(BookingRepository));
            services.AddScoped(typeof(ITripRepository), typeof(TripRepository));

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Booking Service");
            });

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
