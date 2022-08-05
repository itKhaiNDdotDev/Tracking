﻿using Microsoft.AspNetCore.Builder;
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
            });

            services.AddDbContext<TrackingDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("TrackingDbContext")));

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}