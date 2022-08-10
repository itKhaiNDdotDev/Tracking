using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tracking.Backend.Data;
using Tracking.Backend.Services.InterfaceDIServices;
using Tracking.Backend.Services;
using Microsoft.AspNetCore.Identity;
using Tracking.Backend.Models;
using Tracking.Backend.Services.Auth;
using Microsoft.OpenApi.Models;

namespace Tracking.Backend
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
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "V1",
                    Title = "Test Tracking API",
                    Description = "Test Tracking API with Swagger Ui"
                });
                s.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer. \r\n\r\n
                            Enter 'Bearer[SPACE]' and then your token in the textinput below. \r\n\r\n
                            Example: 'Bearer 123456defabc' ",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                s.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            });

            services.AddDbContext<TrackingDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("TrackingDbContext")));

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<TrackingDbContext>()
                .AddDefaultTokenProviders();
            //DI
            services.AddTransient<IAtmTechnicanService, AtmTechnicanService>();
            services.AddTransient<ICarService, CarService>();
            services.AddTransient<IDeviceService, DeviceService>();
            services.AddTransient<IDriverService, DriverService>();
            services.AddTransient<IManageUnitService, ManageUnitService>();
            services.AddTransient<IRfidService, RfidService>();
            services.AddTransient<ISampleRouteService, SampleRouteService>();
            services.AddTransient<ITransactionPointService, TransactionPointService>();
            services.AddTransient<ITreasurerService, TreasurerService>();
            services.AddTransient<UserManager<User>, UserManager<User>>();
            services.AddTransient<SignInManager<User>, SignInManager<User>>();
            services.AddTransient<RoleManager<Role>, RoleManager<Role>>();
            services.AddTransient<IUsers, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TestAPI");
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
